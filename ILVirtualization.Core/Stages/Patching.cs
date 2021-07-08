using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Tables.Rows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ILVirtualization.Core.Stages
{
    public class Patching : IStage
    {
        public string Name => nameof(Patching);

        public void Execute(Context context)
        {
            var patchMethods = context.Get<List<MethodDefinition>>(Registers.PatchedMethods);
            var excuteMethod = context.Get<MethodDefinition>(Registers.ExecutionMethod);
            context.Log.Info($"Patching {patchMethods.Count} Methods.");
            foreach (var method in patchMethods)
            {
                //var gen = new ExpressionGenerator(4);
                /*var cipherGen = gen.EmitDecode(method, new CilInstruction[0]);
                cipherGen.Insert(0, CilInstruction.CreateLdcI4(gen.Encode(method,
                    method.MetadataToken.ToInt32())));*/
                method.CilMethodBody = new(method);
                var firstParams = new CilInstruction[]
                {
                    new CilInstruction(CilOpCodes.Ldtoken, context.Importer.ImportMethod(method)),
                    new(CilOpCodes.Ldc_I4,  method.MetadataToken.ToInt32()),
                    new CilInstruction(CilOpCodes.Ldc_I4, method.Signature.GetTotalParameterCount()),
                    new CilInstruction(CilOpCodes.Newarr, context.Importer.ImportType(context.Module.CorLibTypeFactory.Object.ToTypeDefOrRef())),                    
                }.ToList();
                //firstParams.InsertRange(1, cipherGen);
                var vmParams = new List<CilInstruction>();
                for (int x = 0; x < method.Signature.GetTotalParameterCount(); x++) {
                    var ldArg = method.Parameters.GetBySignatureIndex(x);
                    vmParams.AddRange(new[] {
                        new CilInstruction(CilOpCodes.Dup),
                        new CilInstruction(CilOpCodes.Ldc_I4, x),
                        new CilInstruction(CilOpCodes.Ldarg, ldArg),
                        new CilInstruction(CilOpCodes.Stelem_Ref),
                    });
                }
                vmParams.AddRange(new[] {
                    new CilInstruction(CilOpCodes.Call,
                    context.Importer.ImportMethod(new MethodSpecification(excuteMethod, new(new[]
                    {
                        method.Signature.ReturnType.ElementType == ElementType.Void
                        ? context.Module.CorLibTypeFactory.Object
                        : context.Importer.ImportTypeSignature(method.Signature.ReturnType)
                    })))),
                    method.Signature.ReturnType.ElementType == ElementType.Void
                    ? new CilInstruction(CilOpCodes.Pop)
                    : new CilInstruction(CilOpCodes.Unbox_Any, context.Importer.ImportType(method.Signature.ReturnType.ToTypeDefOrRef()))
                });

                method.CilMethodBody.Instructions.AddRange(firstParams);
                method.CilMethodBody.Instructions.AddRange(vmParams);
                method.CilMethodBody.Instructions.Add(CilOpCodes.Ret);
                method.CilMethodBody.Instructions.OptimizeMacros();
                method.CilMethodBody.Instructions.CalculateOffsets();
            }
        }
    }
}