
#region Usings
using AsmResolver.PE.DotNet.Cil;
using Runtime;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineI : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineI;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldc_I4:
                    info.AppendInstruction(new((int)VMCode.Ldc_I4,
                        new(instruction.GetLdcI4Constant()),
                        VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class ShortInlineI : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.ShortInlineI;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldc_I4_S:
                    info.AppendInstruction(new((int)VMCode.Ldc_I4_S, new(instruction.GetLdcI4Constant()), VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}