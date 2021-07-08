
#region Usings
using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;
using Runtime;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineType : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineType;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            var mdToken = new ILValue(((ITypeDefOrRef)instruction.Operand).MetadataToken.ToInt32());
            switch (instruction.OpCode.Code)
            {
                case CilCode.Box:
                    info.AppendInstruction(new((int)VMCode.Box, mdToken, VMOperand.I32));
                    break;
                case CilCode.Castclass:
                    info.AppendInstruction(new((int)VMCode.Castclass, mdToken, VMOperand.I32));
                    break;
                case CilCode.Constrained:
                    info.AppendInstruction(new((int)VMCode.Constrained, mdToken, VMOperand.I32));
                    break;
                case CilCode.Initobj:
                    info.AppendInstruction(new((int)VMCode.Initobj, mdToken, VMOperand.I32));
                    break;
                case CilCode.Isinst:
                    info.AppendInstruction(new((int)VMCode.Isinst, mdToken, VMOperand.I32));
                    break;
                case CilCode.Ldelem:
                    info.AppendInstruction(new((int)VMCode.Ldelem, mdToken, VMOperand.I32));
                    break;
                case CilCode.Ldobj:
                    info.AppendInstruction(new((int)VMCode.Ldobj, mdToken, VMOperand.I32));
                    break;
                case CilCode.Newarr:
                    info.AppendInstruction(new((int)VMCode.Newarr, mdToken, VMOperand.I32));
                    break;
                case CilCode.Sizeof:
                    info.AppendInstruction(new((int)VMCode.Sizeof, mdToken, VMOperand.I32));
                    break;
                case CilCode.Stelem:
                    info.AppendInstruction(new((int)VMCode.Stelem, mdToken, VMOperand.I32));
                    break;
                case CilCode.Stobj:
                    info.AppendInstruction(new((int)VMCode.Stobj, mdToken, VMOperand.I32));
                    break;
                case CilCode.Unbox:
                    info.AppendInstruction(new((int)VMCode.Unbox, mdToken, VMOperand.I32));
                    break;
                case CilCode.Unbox_Any:
                    info.AppendInstruction(new((int)VMCode.Unbox_Any, mdToken, VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class InlineVar : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.ShortInlineVar;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            var index = new ILValue(instruction
                .GetLocalVariable(info.ParentMethod.CilMethodBody.LocalVariables).Index);
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldloc:
                    info.AppendInstruction(new((int)VMCode.Ldloc, index, VMOperand.I32));
                    break;
                case CilCode.Stloc:
                    info.AppendInstruction(new((int)VMCode.Stloc, index, VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class ShortInlineVar : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.ShortInlineVar;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            var index = new ILValue(instruction
                .GetLocalVariable(info.ParentMethod.CilMethodBody.LocalVariables).Index);
            switch (instruction.OpCode.Code)
            {
                case CilCode.Ldloc_S:
                    info.AppendInstruction(new((int)VMCode.Ldloc_S, index, VMOperand.I32));
                    break;
                case CilCode.Stloc_S:
                    info.AppendInstruction(new((int)VMCode.Stloc_S, index, VMOperand.I32));
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}