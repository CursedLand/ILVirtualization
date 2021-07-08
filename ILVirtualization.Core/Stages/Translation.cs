
#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using ILVirtualization.Core.Translator;

#endregion

namespace ILVirtualization.Core.Stages
{
    public class Translation : IStage
    {
        public void Execute(Context context)
        {
            var vmData = new List<byte>();
            var patchedMethods = new List<MethodDefinition>();
            foreach (var type in context.Module.TopLevelTypes.Where(t => t != context.Module.GetOrCreateModuleType() && t.GenericParameters.Count is 0 && !context.Get<ICollection<TypeDefinition>>(Registers.VMTypes).Contains(t)))
            {
                foreach (var method in type.Methods.Where(x => x.CilMethodBody is not null && !x.Signature.IsGeneric))
                {
                    if (method.CilMethodBody.ExceptionHandlers.Count is not 0) continue;
                    var vmethodInfo = new ILVMethod(method);
                    var instructions = method.CilMethodBody.Instructions;
                    for (int x = 0; x < instructions.Count; x++) {
                        var instr = instructions[x];
                        context.Translations[instr.OpCode.OperandType].Translate(instr, ref vmethodInfo);
                    }
                    if (vmethodInfo.IsCompatible) {
                        var streamData = vmethodInfo.Stream.ToArray();
                        var xorKey = new Random().Next(int.MaxValue);
                        vmData.AddRange(BitConverter.GetBytes(xorKey));
                        vmData.AddRange(BitConverter.GetBytes(method.MetadataToken.ToInt32() ^ xorKey));
                        vmData.AddRange(BitConverter.GetBytes(streamData.Length));
                        for (int q = 0; q < streamData.Length; q++)
                            streamData[q] ^= (byte)xorKey;
                        vmData.AddRange(streamData);
                        patchedMethods.Add(method);
                    }
                    else {
                        context.Log.Warn($"Can't Virtualize {vmethodInfo.ParentMethod.Name} Method.");
                    }
                }   
            }
            var count = BitConverter.GetBytes(patchedMethods.Count);
            vmData.InsertRange(0, count);
            context.Register(Registers.PatchedMethods, patchedMethods);
            context.Register(Registers.VMData, vmData);
        }

        public string Name => nameof(Translation);
    }
}