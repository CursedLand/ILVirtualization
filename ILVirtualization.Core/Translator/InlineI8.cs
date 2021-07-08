
#region Usings
using AsmResolver.PE.DotNet.Cil;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineI8 : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineI8;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldc_I8:
                    info.AppendInstruction(new((int)VMCode.Ldc_I8,
                        new((long)instruction.Operand),
                        Runtime.VMOperand.I64));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}