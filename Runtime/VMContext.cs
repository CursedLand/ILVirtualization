
#region Usings
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
#endregion

namespace Runtime
{
    public class VMContext
    {
        private Module _module;
        private MethodBase _baseMethod;
        private VMStack _vmStack;
        private LocalList _vmLocals;
        private VMInstruction[] _instructions;
        public VMContext(Module baseModule, MethodBase methodBase, object[] parameters, int[] x)
        {
            _module = baseModule;
            _baseMethod = methodBase;
            _vmStack = new VMStack();
            _vmLocals = new LocalList(x[0]);
            _instructions = new VMInstruction[x[1]];
            Parameters = parameters;
            Index = 0;
        }
        public VMInstruction[] Instructions
        {
            get => _instructions;
        }
        public object[] Parameters
        {
            get;
        }
        public Module Module
        {
            get => _module;
        }
        public VMStack Stack
        {
            get => _vmStack;
        }
        public LocalList Locals
        {
            get => _vmLocals;
        }
        public int Index
        {
            set;
            get;
        }

        #region Resolver
        public MemberInfo ResolveMember(int mdToken) =>
            _module.ResolveMember(mdToken);
        public object ResolveMethod(int mdToken, bool asBase = true)
        {
            /*try
            {*/
                var mBase = _module.ResolveMethod(mdToken);
                return asBase ? mBase : (MethodInfo)mBase;
            /*}
            catch {
                var m = typeof(string).Module.ResolveMethod(mdToken);
                return asBase ? m : (MethodInfo)m;
            }*/
        }
        public Type ResolveType(int mdToken) =>
            _module.ResolveType(mdToken);
        public FieldInfo ResolveField(int mdToken) =>
            _module.ResolveField(mdToken);
        #endregion
    }

    public class VMStack
    {
        private Stack<ILValue> _valueStack = new Stack<ILValue>();

        public ILValue Pop() =>
            _valueStack.Pop();

        public object DirectPop() =>
            _valueStack.Pop().Value;

        public object Peek() =>
            _valueStack.Peek().Value;

        public ILValue[] Pop(int popCount, bool reverse = true)
        {
            var retList = new List<ILValue>();
            for (int x = 0; x < popCount; x++)
                retList.Add(_valueStack.Pop());
            if (reverse) retList.Reverse();
            return retList.ToArray();
        }

        public object[] DirectPop(int popCount, bool reverse = true)
        {
            var retList = new List<object>();
            for (int x = 0; x < popCount; x++)
                retList.Add(_valueStack.Pop().Value);
            if (reverse) retList.Reverse();
            return retList.ToArray();
        }

        public void Push(ILValue value) =>
            _valueStack.Push(value);

        public void DirectPush(object obj) =>
            _valueStack.Push(new ILValue(obj));

        public int Count
        {
            get => _valueStack.Count;
        }
    }
}