
#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using AsmResolver.DotNet;
using AsmResolver.DotNet.Builder;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.IO;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Strings;
using ILVirtualization.Core.Stages;
using ILVirtualization.Core.Translator;
using Runtime;

#endregion

namespace ILVirtualization.Core
{
    public class Context
    {
        private string _filepath;
        private Dictionary<Registers, object> _registers = new();
        private ModuleDefinition _runtimeModule;
        
        private Context(Module transModule)
        {
            Translations = new();
            foreach (var trans in transModule
                .GetTypes()
                .Where(x => !x.IsInterface && typeof(IOperandTranslator).IsAssignableFrom(x))) {
                var t = Activator.CreateInstance(trans) as IOperandTranslator;
                Translations[t.TranslationType] = t;
            }
        }

        public Context(string filePath, ILogger logger) : this(typeof(Context).Module)
        {
            _filepath = filePath;
            Module = ModuleDefinition.FromFile(_filepath);
            Importer = new(Module);
            Log = logger;
        }

        public Context Execute()
        {
            var stages = new IStage[] {
                new Injection(),
                new Translation(),
                new Patching(),
                new InsertingData(),
            };
            for (int x = 0; x < stages.Length; x++)
                stages[x].Execute(this);
            return this;
        }

        public void Write() =>
            Module.Write(_filepath.Insert(_filepath.Length - 4, "-ILV"),
                new ManagedPEImageBuilder(MetadataBuilderFlags.PreserveAll));

        public void Register<T>(Registers register, T regValue) =>
            _registers[register] = regValue;

        public T Get<T>(Registers register) =>
            (T)(object)_registers[register];
        
        public ModuleDefinition Module
        {
            get;
        }

        public Dictionary<CilOperandType, IOperandTranslator> Translations
        {
            set;
            get;
        }

        public ModuleDefinition RuntimeModule =>
            _runtimeModule ?? (_runtimeModule = ModuleDefinition.FromFile(typeof(Interpreter).Assembly.Location));

        public ReferenceImporter Importer
        {
            get;
        }

        public ILogger Log
        {
            get;
        }
    }

    [Flags]
    public enum Registers // ik my code is piece of shit :) 
    {
        ExecutionMethod,
        DirectExecutionMethod,
        PatchedMethods,
        VMData,
        VMTypes,
    }
}