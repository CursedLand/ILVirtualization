
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
    public class InlineMethod : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineMethod;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            ILValue methodToken = default;
            if (instruction.Operand is MethodSpecification _spec)
                methodToken = new(_spec.MetadataToken.ToInt32());
            else if (instruction.Operand is MethodDefinition _def)
                methodToken = new(_def.MetadataToken.ToInt32());
            else if (instruction.Operand is MemberReference _ref)
                methodToken = new(_ref.MetadataToken.ToInt32());
            else // sus.
                methodToken = new(((IMethodDescriptor)instruction.Operand).MetadataToken.ToInt32());
            switch (instruction.OpCode.Code) 
            {
                case CilCode.Call:
                    info.AppendInstruction(new((int)VMCode.Call, methodToken, VMOperand.I32));
                    break;
                case CilCode.Callvirt:
                    info.AppendInstruction(new((int)VMCode.Callvirt, methodToken, VMOperand.I32));
                    break;
                case CilCode.Ldftn:
                    info.AppendInstruction(new((int)VMCode.Ldftn, methodToken, VMOperand.I32));
                    break;
                case CilCode.Ldvirtftn:
                    info.AppendInstruction(new((int)VMCode.Ldvirtftn, methodToken, VMOperand.I32));
                    break;
                case CilCode.Newobj:
                    info.AppendInstruction(new((int)VMCode.Newobj, methodToken, VMOperand.I32));
                    break;
                case CilCode.Jmp:
                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}