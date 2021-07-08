
#region Usings
using AsmResolver.PE.DotNet.Cil;
using Runtime;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineBrTarget : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineBrTarget;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            var toIndex = new ILValue(info.GetLabelIndex(instruction));
            switch (instruction.OpCode.Code)
            {
                case CilCode.Beq: 
                    info.AppendInstruction(new((int)VMCode.Beq,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bge:
                    info.AppendInstruction(new((int)VMCode.Bge,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bge_Un:
                    info.AppendInstruction(new((int)VMCode.Bge_Un,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bgt:
                    info.AppendInstruction(new((int)VMCode.Bgt,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bgt_Un:
                    info.AppendInstruction(new((int)VMCode.Bgt_Un,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Ble:
                    info.AppendInstruction(new((int)VMCode.Ble,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Ble_Un:
                    info.AppendInstruction(new((int)VMCode.Ble_Un,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Blt:
                    info.AppendInstruction(new((int)VMCode.Blt,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Blt_Un:
                    info.AppendInstruction(new((int)VMCode.Blt_Un,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bne_Un:
                    info.AppendInstruction(new((int)VMCode.Bne_Un,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Br:
                    info.AppendInstruction(new((int)VMCode.Br,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Brfalse:
                    info.AppendInstruction(new((int)VMCode.Brfalse,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Brtrue:
                    info.AppendInstruction(new((int)VMCode.Brtrue,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Leave:
                    /*info.AppendInstruction(new((int)VMCode.Leave,
                        toIndex,
                        VMOperand.I32));
                    break;*/
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
    public class ShortInlineBrTarget : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.ShortInlineBrTarget;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            var toIndex = new ILValue(info.GetLabelIndex(instruction));
            switch (instruction.OpCode.Code)
            {
                case CilCode.Beq_S:
                    info.AppendInstruction(new((int)VMCode.Beq_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bge_S:
                    info.AppendInstruction(new((int)VMCode.Bge_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bge_Un_S:
                    info.AppendInstruction(new((int)VMCode.Bge_Un_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bgt_S:
                    info.AppendInstruction(new((int)VMCode.Bgt_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bgt_Un_S:
                    info.AppendInstruction(new((int)VMCode.Bgt_Un_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Ble_S:
                    info.AppendInstruction(new((int)VMCode.Ble_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Ble_Un_S:
                    info.AppendInstruction(new((int)VMCode.Ble_Un_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Blt_S:
                    info.AppendInstruction(new((int)VMCode.Blt_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Blt_Un_S:
                    info.AppendInstruction(new((int)VMCode.Blt_Un_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Bne_Un_S:
                    info.AppendInstruction(new((int)VMCode.Bne_Un_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Br_S:
                    info.AppendInstruction(new((int)VMCode.Br_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Brfalse_S:
                    info.AppendInstruction(new((int)VMCode.Brfalse_S,
                        toIndex,
                        VMOperand.I32));
                    break;
                case CilCode.Brtrue_S:
                    info.AppendInstruction(new((int)VMCode.Brtrue_S,
                        toIndex,
                        VMOperand.I32));                    
                    break;
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}