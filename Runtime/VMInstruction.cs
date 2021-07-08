namespace Runtime
{
    public struct VMInstruction
    {
        public VMInstruction(int code, VMOperand o)
            : this(code, null, o) { }
        public VMInstruction(int code, ILValue value, VMOperand o)
        {
            Code = code;
            Value = value;
            Operand = o;
        }
        public VMOperand Operand
        {
            get;
        }
        public int Code
        {
            get;
        }
        public ILValue Value
        {
            get;
        }
    }
}