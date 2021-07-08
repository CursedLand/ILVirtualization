
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsmResolver.DotNet;
using AsmResolver.DotNet.Cloning;
using AsmResolver.PE.DotNet.Cil;
using Runtime;

#endregion

namespace ILVirtualization.Core.Stages
{
    public class Injection : IStage
    {
        public void Execute(Context context)
        {
            char[] chars = ("ABCDEFGHIGKLMNOPQRSTUVWXYZ" +
                            "ABCDEFGHIGKLMNOPQRSTUVWXYZ".ToLower() + 
                            "1234567890" /*+ "诶比西迪伊艾弗吉艾弗艾杰开艾勒艾马艾娜哦屁吉吾艾儿艾"*/)
                            .ToCharArray();
            var used = new List<string>();
            var memberCloner = new MemberCloner(context.Module);
            memberCloner.Include(context.RuntimeModule.TopLevelTypes
                .Where(t => t.Name != "<Module>"));
            var cloneResult = memberCloner.Clone();
            /*foreach (var m in cloneResult.ClonedMembers.Where(x => x is MetadataMember))
                context.Module.TokenAllocator.AssignNextAvailableToken((MetadataMember)m);*/
            foreach (var topType in cloneResult.ClonedTopLevelTypes)
                context.Module.TopLevelTypes.Add(topType);
            context.Log.Info($"Injected {cloneResult.ClonedMembers.Count} RTMembers Successfly.");
            var runMethod = cloneResult.ClonedMembers
                .First(x => x is MethodDefinition member &&
                       member.Name == nameof(Interpreter.Execute));
            var dRun = cloneResult.ClonedMembers
                .First(x => x is MethodDefinition member &&
                       member.Name == nameof(Interpreter.ExecuteDirect));
            context.Register(Registers.DirectExecutionMethod, dRun);
            context.Log.Info("Protecting RT...");
            //new RTProtections(cloneResult).Execute(context.Module, context);
            var setupMethod = (MethodDefinition)cloneResult.ClonedMembers
                .First(x => x is MethodDefinition member &&
                       member.Name == nameof(Interpreter.SetupVM));
            var instrs = context.Module.GetOrCreateModuleConstructor().CilMethodBody.Instructions;
                instrs.Insert(instrs.Count - 1,
                CilOpCodes.Call, 
                context.Importer.ImportMethod(setupMethod));

            foreach (var member in cloneResult.ClonedMembers)
            {
                if (member is MethodDefinition Method && Method.CilMethodBody is not null) {
                    if (!Method.IsConstructor && Method.Name != nameof(Interpreter.Execute))
                        Method.Name = GenName(2);
                    foreach (var param in Method.ParameterDefinitions)
                        param.Name = GenName();
                }
                if (member is TypeDefinition Type ) {
                    if (Type.Name != nameof(Interpreter))
                        Type.Name = GenName(1);
                    Type.Namespace = "";
                    if (Type.Name == nameof(Interpreter))
                        Type.Namespace = "ILVirtualization.Runtime";
                    foreach (var prop in Type.Properties.Where(x => x.Name != "Item")) 
                        prop.Name = GenName(2);
                }
                if (member is FieldDefinition Field && !Field.IsRuntimeSpecialName)
                    Field.Name = GenName(2);
            }
            
            

            
            context.Register(Registers.ExecutionMethod, runMethod);
            context.Register(Registers.VMTypes, cloneResult.ClonedTopLevelTypes);
            string GenName(int len = 5) // xd
            {
                var rnd = new Random();
                var sb = new StringBuilder();
                for (int x = 0; x < len; x++)
                    sb.Append(chars[rnd.Next(0, chars.Length)].ToString());
                if (used.Contains(sb.ToString())) {
                    return GenName(len);
                }
                else {
                    used.Add(sb.ToString());
                    return sb.ToString();
                }
            }
        }

        public string Name => nameof(Injection);
    }
}