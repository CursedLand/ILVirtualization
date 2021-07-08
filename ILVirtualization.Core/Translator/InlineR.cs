
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
    public class InlineR : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineR;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldc_R8:
                    info.AppendInstruction(new((int)VMCode.Ldc_R8, 
                        new((double)instruction.Operand), 
                        VMOperand.Double));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class ShortInlineR : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.ShortInlineR;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldc_R4:
                    info.AppendInstruction(new((int)VMCode.Ldc_R4, new((float)instruction.Operand), VMOperand.Float));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class InlineString : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineString;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldstr:
                    info.AppendInstruction(new((int)VMCode.Ldstr, 
                        new((string)instruction.Operand), VMOperand.String));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class InlineSwitch : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineSwitch;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code)
            {
                case CilCode.Switch:
                    var switchHeader = instruction.Operand as IList<ICilLabel>;
                    var vmOperand = new int[switchHeader.Count];
                    for (int x = 0; x < switchHeader.Count; x++)
                        vmOperand[x] = info.GetLabelIndex(switchHeader[x]);
                    info.AppendInstruction(new((int)VMCode.Switch, new(vmOperand), VMOperand.SWTArray));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class InlineTok : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineTok;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            ILValue member = null;
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldtoken:
                    if (instruction.Operand is MethodSpecification Spec) member = new(Spec.MetadataToken.ToInt32());
                    if (instruction.Operand is IMethodDefOrRef MDR) member = new(MDR.MetadataToken.ToInt32());
                    if (instruction.Operand is ITypeDefOrRef TDR) member = new(TDR.MetadataToken.ToInt32());
                    if (instruction.Operand is TypeSpecification TSpec) member = new(TSpec.MetadataToken.ToInt32());
                    if (instruction.Operand is IFieldDescriptor Fld) member = new(Fld.MetadataToken.ToInt32());
                    info.AppendInstruction(new((int)VMCode.Ldtoken, member, VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}
