
#region Usings
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.CompilerServices;
using Binder = Microsoft.CSharp.RuntimeBinder.Binder;
using System.Linq.Expressions;
#endregion

namespace Runtime
{
    public delegate int SizeOfFactory();
    public static class Factory
    {
        private static Dictionary<Type, SizeOfFactory> _sizeofFactories =
            new Dictionary<Type, SizeOfFactory>();

        #region Dynamic Arithmetics
        private static CallSite<Func<CallSite, object, object, object>> _cgtBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.GreaterThan,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _cltBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.LessThan,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _addBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.Add,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _subBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.Subtract,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _mulBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.Multiply,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _divBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.Divide,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _remBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.Modulo,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _andBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.And,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _orBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.Or,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _xorBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.ExclusiveOr,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _shlBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.LeftShift,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));
        private static CallSite<Func<CallSite, object, object, object>> _shrBinder
            = CallSite<Func<CallSite, object, object, object>>
            .Create(Binder.BinaryOperation(CSharpBinderFlags.None,
                ExpressionType.RightShift,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
            }));

        private static CallSite<Func<CallSite, object, object>> _notBinder
            = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None,
                ExpressionType.OnesComplement,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                }));
        private static CallSite<Func<CallSite, object, object>> _negBinder
            = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None,
                ExpressionType.Negate,
                typeof(Factory), new CSharpArgumentInfo[] {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                }));
        private static Dictionary<ArithmeticOpKeys, object> _arithmeticFactories =
            new Dictionary<ArithmeticOpKeys, object>()
            {
                { ArithmeticOpKeys.Add, _addBinder },
                { ArithmeticOpKeys.And, _andBinder },
                { ArithmeticOpKeys.Div, _divBinder },
                { ArithmeticOpKeys.Mul, _mulBinder },
                { ArithmeticOpKeys.Neg, _negBinder },
                { ArithmeticOpKeys.Not, _notBinder },
                { ArithmeticOpKeys.Or, _orBinder },
                { ArithmeticOpKeys.Rem, _remBinder },
                { ArithmeticOpKeys.Shl, _shlBinder },
                { ArithmeticOpKeys.Shr, _shrBinder },
                { ArithmeticOpKeys.Sub, _subBinder },
                { ArithmeticOpKeys.Xor, _xorBinder },
                { ArithmeticOpKeys.Cgt, _cgtBinder },
                { ArithmeticOpKeys.Clt, _cltBinder },
            };
        #endregion

        public static int CreateSizeOfFactory(Type sizeType)
        {
            if (_sizeofFactories.ContainsKey(sizeType))
            {
                return _sizeofFactories[sizeType]();
            }
            else
            {
                var dynamicMethod = new DynamicMethod(string.Empty,
                    typeof(int), Type.EmptyTypes,
                    typeof(Factory).Module, true);
                var ilGen = dynamicMethod.GetILGenerator();
                ilGen.Emit(OpCodes.Sizeof, sizeType);
                ilGen.Emit(OpCodes.Ret);
                var sizeDelegate = (SizeOfFactory)dynamicMethod.CreateDelegate(typeof(SizeOfFactory));
                _sizeofFactories[sizeType] = sizeDelegate;
                return sizeDelegate();
            }
            throw new ArgumentOutOfRangeException();
        }

        public static object CreateBoxFactory(object obj, Type boxType)
        {
            var dyn = new DynamicMethod(string.Empty, boxType, new[] { typeof(object) }, typeof(Factory).Module, true);
            var ilgen = dyn.GetILGenerator();
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Box, boxType);
            ilgen.Emit(OpCodes.Ret);
            return dyn.Invoke(null, new[] { obj });
        }

        public static object CreateArithmethicFactory(ArithmeticOpKeys key, object[] reversedPops)
        {
            dynamic result = null;
            switch (key)
            {
                case ArithmeticOpKeys.Neg:
                case ArithmeticOpKeys.Not:
                    var unaryFactory = (CallSite<Func<CallSite, object, object>>)_arithmeticFactories[key];
                    result = unaryFactory.Target(unaryFactory, reversedPops[0]);
                    break;
                default:
                    var firstValue = reversedPops[0];
                    var secondValue = reversedPops[1];
                    var realKey = _arithmeticFactories[key];
                    var arithmeticFactory = (CallSite<Func<CallSite, object, object, object>>)realKey;
                    result = arithmeticFactory.Target(arithmeticFactory, firstValue, secondValue);
                    break;
            }
            return result;
        }
    }
    public enum ArithmeticOpKeys
    {
        Add,
        Sub,
        Mul,
        Div,
        Rem,
        And,
        Or,
        Xor,
        Shl,
        Shr,

        // UnaryOperations.

        Neg,
        Not,

        // BooleansOperations.

        Cgt,
        Clt,
    }
}