
#region Usings
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
#endregion

namespace ILVirtualization.Core
{
    public struct ILVMethod
    {

        public ILVMethod(MethodDefinition method) 
        {
            IsCompatible = true;
            ParentMethod = method;
            Writer = new(Stream = new());
            Writer.Write(ParentMethod.CilMethodBody.LocalVariables.Count);
            Writer.Write(ParentMethod.CilMethodBody.Instructions.Count);
        }

        public void AppendInstruction(in VMInstruction instruction) {
            Writer.Write(instruction.Code);
            Writer.Write((int)instruction.Operand);
            switch (instruction.Operand)
            {
                case VMOperand.String:
                    Writer.Write((string)instruction.Value.Value);
                    break;
                case VMOperand.I32:
                    Writer.Write((int)instruction.Value.Value);
                    break;
                case VMOperand.I64:
                    Writer.Write((long)instruction.Value.Value);
                    break;
                case VMOperand.Float:
                    Writer.Write((float)instruction.Value.Value);
                    break;
                case VMOperand.Double:
                    Writer.Write((double)instruction.Value.Value);
                    break;
                case VMOperand.Null:
                    break;
                case VMOperand.SWTArray:
                    var cases = (int[])instruction.Value.Value;
                    Writer.Write(cases.Length);
                    for (int x = 0; x < cases.Length; x++)
                        Writer.Write(cases[x]);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetLabelIndex(CilInstruction instruction) =>
            ParentMethod.CilMethodBody.Instructions
                .GetIndexByOffset(((ICilLabel)instruction.Operand).Offset);
        public int GetLabelIndex(ICilLabel label) =>
            ParentMethod.CilMethodBody.Instructions
                .GetIndexByOffset(label.Offset);

        public MethodDefinition ParentMethod
        {
            get;
        }
        
        public bool IsCompatible
        {
            set;
            get;
        }
        public MemoryStream Stream
        {
            get;
        }
        public BinaryWriter Writer
        {
            get;
        }

    }
}