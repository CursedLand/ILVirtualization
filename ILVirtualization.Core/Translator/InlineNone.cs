
#region Usings
using AsmResolver.PE.DotNet.Cil;
using Runtime;
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public class InlineNone : IOperandTranslator
    {
        public CilOperandType TranslationType => CilOperandType.InlineNone;

        public void Translate(CilInstruction instruction, ref ILVMethod info)
        {
            switch (instruction.OpCode.Code) 
            {                
                #region Done
                case CilCode.Add:
                case CilCode.Add_Ovf:
                case CilCode.Add_Ovf_Un:
                case CilCode.And:
                case CilCode.Ceq:
                case CilCode.Cgt:
                case CilCode.Cgt_Un:
                case CilCode.Ckfinite:
                case CilCode.Clt:
                case CilCode.Clt_Un:
                case CilCode.Conv_I:
                case CilCode.Conv_I1:
                case CilCode.Conv_I2:
                case CilCode.Conv_I4:
                case CilCode.Conv_I8:
                case CilCode.Conv_Ovf_I:
                case CilCode.Conv_Ovf_I_Un:
                case CilCode.Conv_Ovf_I1:
                case CilCode.Conv_Ovf_I1_Un:
                case CilCode.Conv_Ovf_I2:
                case CilCode.Conv_Ovf_I2_Un:
                case CilCode.Conv_Ovf_I4:
                case CilCode.Conv_Ovf_I4_Un:
                case CilCode.Conv_Ovf_I8:
                case CilCode.Conv_Ovf_I8_Un:
                case CilCode.Conv_Ovf_U:
                case CilCode.Conv_Ovf_U_Un:
                case CilCode.Conv_Ovf_U1:
                case CilCode.Conv_Ovf_U1_Un:
                case CilCode.Conv_Ovf_U2:
                case CilCode.Conv_Ovf_U2_Un:
                case CilCode.Conv_Ovf_U4:
                case CilCode.Conv_Ovf_U4_Un:
                case CilCode.Conv_Ovf_U8:
                case CilCode.Conv_Ovf_U8_Un:
                case CilCode.Conv_R_Un:
                case CilCode.Conv_R4:
                case CilCode.Conv_R8:
                case CilCode.Conv_U:
                case CilCode.Conv_U1:
                case CilCode.Conv_U2:
                case CilCode.Conv_U4:
                case CilCode.Conv_U8:
                case CilCode.Div:
                case CilCode.Div_Un:
                case CilCode.Dup:
                case CilCode.Ldarg_0:
                case CilCode.Ldarg_1:
                case CilCode.Ldarg_2:
                case CilCode.Ldarg_3:
                case CilCode.Ldc_I4_0:
                case CilCode.Ldc_I4_1:
                case CilCode.Ldc_I4_2:
                case CilCode.Ldc_I4_3:
                case CilCode.Ldc_I4_4:
                case CilCode.Ldc_I4_5:
                case CilCode.Ldc_I4_6:
                case CilCode.Ldc_I4_7:
                case CilCode.Ldc_I4_8:
                case CilCode.Ldc_I4_M1:
                case CilCode.Ldelem_I:
                case CilCode.Ldelem_I1:
                case CilCode.Ldelem_I2:
                case CilCode.Ldelem_I4:
                case CilCode.Ldelem_I8:
                case CilCode.Ldelem_R4:
                case CilCode.Ldelem_R8:
                case CilCode.Ldelem_Ref:
                case CilCode.Ldelem_U1:
                case CilCode.Ldelem_U2:
                case CilCode.Ldelem_U4:
                case CilCode.Ldind_I:
                case CilCode.Ldind_I1:
                case CilCode.Ldind_I2:
                case CilCode.Ldind_I4:
                case CilCode.Ldind_I8:
                case CilCode.Ldind_R4:
                case CilCode.Ldind_R8:

                //case CilCode.Ldind_Ref:

                case CilCode.Ldind_U1:
                case CilCode.Ldind_U2:
                case CilCode.Ldind_U4:
                case CilCode.Ldloc_0:
                case CilCode.Ldloc_1:
                case CilCode.Ldloc_2:
                case CilCode.Ldloc_3:
                case CilCode.Localloc:
                case CilCode.Ldlen:
                case CilCode.Ldnull:
                case CilCode.Mul:
                case CilCode.Mul_Ovf:
                case CilCode.Mul_Ovf_Un:
                case CilCode.Neg:
                case CilCode.Nop:
                case CilCode.Not:
                case CilCode.Or:
                case CilCode.Pop:
                case CilCode.Rem:
                case CilCode.Rem_Un:
                case CilCode.Ret:
                case CilCode.Shl:
                case CilCode.Shr:
                case CilCode.Shr_Un:
                case CilCode.Stelem_I:
                case CilCode.Stelem_I1:
                case CilCode.Stelem_I2:
                case CilCode.Stelem_I4:
                case CilCode.Stelem_I8:
                case CilCode.Stelem_R4:
                case CilCode.Stelem_R8:
                //case CilCode.Stelem_Ref:
                case CilCode.Stind_I:
                case CilCode.Stind_I1:
                case CilCode.Stind_I2:
                case CilCode.Stind_I4:
                case CilCode.Stind_I8:
                case CilCode.Stind_R4:
                case CilCode.Stind_R8:
                case CilCode.Stind_Ref:
                case CilCode.Stloc_0:
                case CilCode.Stloc_1:
                case CilCode.Stloc_2:
                case CilCode.Stloc_3:
                case CilCode.Sub:
                case CilCode.Sub_Ovf:
                case CilCode.Sub_Ovf_Un:
                case CilCode.Throw:
                case CilCode.Xor:
                    var vmCode = (VMCode?)Enum.Parse(typeof(VMCode), instruction.OpCode.Code.ToString());
                    if (vmCode.HasValue)
                        info.AppendInstruction(new((int)vmCode.Value, VMOperand.Null));
                    else
                        info.IsCompatible = false;
                    break;
                #endregion

                default:
                    info.IsCompatible = false;
                    break;
            }
        }
    }
}