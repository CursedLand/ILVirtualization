
#region Usings
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.DotNet.Code.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Runtime;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineArgument : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineArgument;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldarg: /* Load Argument. */
                    info.AppendInstruction(new VMInstruction((int)VMCode.Ldarg,
                        new(instruction.GetParameter(info.ParentMethod.Parameters).Index),
                        Runtime.VMOperand.I32));
                    break;
                case CilCode.Starg: /* Store Argument. */
                    info.AppendInstruction(new VMInstruction((int)VMCode.Starg,
                        new(instruction.GetParameter(info.ParentMethod.Parameters).Index),
                        VMOperand.I32));
                    break;
                case CilCode.Ldarga: /* Pointers ew. */
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class ShortInlineArgument : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.ShortInlineArgument;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldarg_S:
                    info.AppendInstruction(new((int)VMCode.Ldarg_S,
                        new(instruction.GetParameter(info.ParentMethod.Parameters).Index), VMOperand.I32));
                    break;
                case CilCode.Starg_S:
                    info.AppendInstruction(new((int)VMCode.Starg_S,
                        new(instruction.GetParameter(info.ParentMethod.Parameters).Index), VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}