
#region Usings
using AsmResolver.PE.DotNet.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
#endregion

namespace ILVirtualization.Core.Translator
{
    public interface IOperandTranslator
    {
        CilOperandType TranslationType { get; }
        public void Translate(CilInstruction instruction, ref ILVMethod info);
    }
}