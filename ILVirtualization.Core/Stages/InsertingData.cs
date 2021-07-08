using AsmResolver;
using AsmResolver.DotNet;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Tables.Rows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ILVirtualization.Core.Stages
{
    public class InsertingData : IStage
    {
        public string Name => nameof(InsertingData);

        public void Execute(Context context)
        {
            var data = context.Get<List<byte>>(Registers.VMData).ToArray();
            context.Log.Info($"Emitting {data.Length} VMBytes.");
            var ArrayStructure = new TypeDefinition("", "<Module>`CL", TypeAttributes.Sealed | TypeAttributes.Public, context.Importer.ImportType(new TypeReference(context.Module.CorLibTypeFactory.CorLibScope, "System", "ValueType")))
            {
                ClassLayout = new ClassLayout(0, (uint)data.Length),
            };
            context.Module.TopLevelTypes.Add(ArrayStructure);
            var Seg = new DataSegment(data);
            var FieldWithRVA = new FieldDefinition(Guid.Empty.ToString(), FieldAttributes.HasFieldRva | FieldAttributes.Static | FieldAttributes.InitOnly | FieldAttributes.Assembly, new FieldSignature(context.Importer.ImportTypeSignature(ArrayStructure.ToTypeSignature())))
            {
                HasFieldRva = true
            };
            FieldWithRVA.FieldRva = Seg;
            context.Log.Info($"RVA Field Created {FieldWithRVA.Name}");
            context.Module.GetOrCreateModuleType().Fields.Add(FieldWithRVA);
            var cctor = context.Module.GetModuleConstructor().CilMethodBody.Instructions;
            cctor.InsertRange(0, new CilInstruction[] {
                new(CilOpCodes.Ldc_I4, data.Length),
                new(CilOpCodes.Newarr, context.Importer.ImportType(context.Module.CorLibTypeFactory.Byte.ToTypeDefOrRef())),
                new(CilOpCodes.Dup),
                new(CilOpCodes.Ldtoken, context.Importer.ImportField(FieldWithRVA)),
                new(CilOpCodes.Call, context.Importer.ImportMethod(Utils.GetCorLibMethod(context.Module, "System.Runtime.CompilerServices", "RuntimeHelpers", "InitializeArray"))),
                new(CilOpCodes.Stsfld, context.Importer.ImportField(context.Module.TopLevelTypes.First(x=>x.Namespace == "ILVirtualization.Runtime" && x.Name == "Interpreter").Fields.First(x=>x.Signature.FieldType.FullName.Contains("Byte"))))
            });
            
        }
    }
}
