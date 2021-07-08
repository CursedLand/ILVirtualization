
#region Usings
using System.IO;
using System.Collections.Generic;
using Runtime;
using System;
using System.Runtime.CompilerServices;
using System.Linq;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Metadata.Tables.Rows;
using AsmResolver;
using AsmResolver.DotNet.Signatures;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Signatures.Types;
#endregion

[assembly: InternalsVisibleTo("ILVirtualization.CLI")]

namespace ILVirtualization.Core
{    
    internal static class Utils
    {
        public static byte[] GetRawCode(this IEnumerable<VMInstruction> instructions) {
            MemoryStream stream;
            var writer = new BinaryWriter(stream = new());
            writer.Write(instructions.Count());
            foreach (var i in instructions) {
                writer.Write(i.Code);
                writer.Write((int)i.Operand);
                switch (i.Operand)
                {
                    case VMOperand.String:
                        writer.Write((string)i.Value.Value);
                        break;
                    case VMOperand.I32:
                        writer.Write((int)i.Value.Value);
                        break;
                    case VMOperand.I64:
                        writer.Write((long)i.Value.Value);
                        break;
                    case VMOperand.Float:
                        writer.Write((float)i.Value.Value);
                        break;
                    case VMOperand.Double:
                        writer.Write((double)i.Value.Value);
                        break;
                    case VMOperand.Null:
                        break;
                    case VMOperand.SWTArray:
                        var cases = (int[])i.Value.Value;
                        writer.Write(cases.Length);
                        for (int x = 0; x < cases.Length; x++)
                            writer.Write(cases[x]);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            return stream.ToArray();
        }
        public static MethodDefinition GetCorLibMethod(ModuleDefinition module, string ns, string typename, string methodname, int p = 0xFF)
        {
            var MsCorlib = module.CorLibTypeFactory.CorLibScope.GetAssembly().Resolve().ManifestModule;
            var Type = MsCorlib.GetAllTypes().Single(x => x.Name == typename && x.Namespace == ns);
            var Method = p == 0xFF
                ? Type.Methods.SingleOrDefault(x => x.Name == methodname)
                : Type.Methods.SingleOrDefault(x => x.Name == methodname && x.Parameters.Count == p);
            return Method;
        }
        public static bool IsCode(this CilInstruction i, CilCode code) =>
            i.OpCode.Code == code;
    }
}
