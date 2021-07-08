
#region Usings
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using Runtime;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineField : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineField;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            var fieldToken = new ILValue(((IFieldDescriptor)instruction.Operand).MetadataToken.ToInt32());
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldfld: /* Load Instance Field Value. */
                    info.AppendInstruction(new((int)VMCode.Ldfld, fieldToken, VMOperand.I32));
                    break;
                case CilCode.Ldsfld: /* Load Static Field Value. */
                    info.AppendInstruction(new((int)VMCode.Ldsfld, fieldToken, VMOperand.I32));
                    break;
                case CilCode.Stfld: /* Store Instance Field Value. */
                    info.AppendInstruction(new((int)VMCode.Stfld, fieldToken, VMOperand.I32));
                    break;
                case CilCode.Stsfld: /* Store Static Field Value. */
                    info.AppendInstruction(new((int)VMCode.Stsfld, fieldToken, VMOperand.I32));
                    break;
                case CilCode.Ldflda: /* Pointers ew. */
                case CilCode.Ldsflda: /* Pointers ew. */
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}