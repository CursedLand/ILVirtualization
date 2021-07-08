namespace Runtime
{
    public class LocalList
    {
        private object[] _locals;
        public LocalList(int count) =>
            FillLocals(count);

        private void FillLocals(int count) {
            _locals = new object[count];
            for (int x = 0; x < count; x++)
                _locals[x] = new object();
        }

        public object this[int index]
        {
            get => _locals[index];
            set => _locals[index] = value;
        }
    }
}