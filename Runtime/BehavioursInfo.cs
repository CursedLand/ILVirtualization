
#region Usings
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
#endregion

namespace Runtime
{
    public delegate void Behaviour(VMContext c, object o);

    public static class BehavioursInfo
    {
        internal static readonly Dictionary<int, Behaviour> BehaviourInfo = new Dictionary<int, Behaviour>()
        { // All This Dictionary is auto generated btw :)
            { 0, Add },
            { 1, Add_Ovf },
            { 2, Add_Ovf_Un },
            { 3, And },
            { 4, Beq },
            { 5, Beq_S },
            { 6, Bge },
            { 7, Bge_S },
            { 8, Bge_Un },
            { 9, Bge_Un_S },
            { 10, Bgt },
            { 11, Bgt_S },
            { 12, Bgt_Un },
            { 13, Bgt_Un_S },
            { 14, Ble },
            { 15, Ble_S },
            { 16, Ble_Un },
            { 17, Ble_Un_S },
            { 18, Blt },
            { 19, Blt_S },
            { 20, Blt_Un },
            { 21, Blt_Un_S },
            { 22, Bne_Un },
            { 23, Bne_Un_S },
            { 24, Box },
            { 25, Br },
            { 26, Br_S },
            { 27, Break },
            { 28, Brfalse },
            { 29, Brfalse_S },
            { 30, Brtrue },
            { 31, Brtrue_S },
            { 32, Call },
            { 33, Calli },
            { 34, Callvirt },
            { 35, Castclass },
            { 36, Ceq },
            { 37, Cgt },
            { 38, Cgt_Un },
            { 39, Ckfinite },
            { 40, Clt },
            { 41, Clt_Un },
            { 42, Constrained },
            { 43, Conv_I },
            { 44, Conv_I1 },
            { 45, Conv_I2 },
            { 46, Conv_I4 },
            { 47, Conv_I8 },
            { 48, Conv_Ovf_I },
            { 49, Conv_Ovf_I_Un },
            { 50, Conv_Ovf_I1 },
            { 51, Conv_Ovf_I1_Un },
            { 52, Conv_Ovf_I2 },
            { 53, Conv_Ovf_I2_Un },
            { 54, Conv_Ovf_I4 },
            { 55, Conv_Ovf_I4_Un },
            { 56, Conv_Ovf_I8 },
            { 57, Conv_Ovf_I8_Un },
            { 58, Conv_Ovf_U },
            { 59, Conv_Ovf_U_Un },
            { 60, Conv_Ovf_U1 },
            { 61, Conv_Ovf_U1_Un },
            { 62, Conv_Ovf_U2 },
            { 63, Conv_Ovf_U2_Un },
            { 64, Conv_Ovf_U4 },
            { 65, Conv_Ovf_U4_Un },
            { 66, Conv_Ovf_U8 },
            { 67, Conv_Ovf_U8_Un },
            { 68, Conv_R_Un },
            { 69, Conv_R4 },
            { 70, Conv_R8 },
            { 71, Conv_U },
            { 72, Conv_U1 },
            { 73, Conv_U2 },
            { 74, Conv_U4 },
            { 75, Conv_U8 },
            { 76, Cpblk },
            { 77, Cpobj },
            { 78, Div },
            { 79, Div_Un },
            { 80, Dup },
            { 81, Initblk },
            { 82, Initobj },
            { 83, Isinst },
            { 84, Jmp },
            { 85, Ldarg },
            { 86, Ldarg_0 },
            { 87, Ldarg_1 },
            { 88, Ldarg_2 },
            { 89, Ldarg_3 },
            { 90, Ldarg_S },
            { 91, Ldc_I4 },
            { 92, Ldc_I4_0 },
            { 93, Ldc_I4_1 },
            { 94, Ldc_I4_2 },
            { 95, Ldc_I4_3 },
            { 96, Ldc_I4_4 },
            { 97, Ldc_I4_5 },
            { 98, Ldc_I4_6 },
            { 99, Ldc_I4_7 },
            { 100, Ldc_I4_8 },
            { 101, Ldc_I4_M1 },
            { 102, Ldc_I4_S },
            { 103, Ldc_I8 },
            { 104, Ldc_R4 },
            { 105, Ldc_R8 },
            { 106, Ldelem },
            { 107, Ldelem_I },
            { 108, Ldelem_I1 },
            { 109, Ldelem_I2 },
            { 110, Ldelem_I4 },
            { 111, Ldelem_I8 },
            { 112, Ldelem_R4 },
            { 113, Ldelem_R8 },
            { 114, Ldelem_Ref },
            { 115, Ldelem_U1 },
            { 116, Ldelem_U2 },
            { 117, Ldelem_U4 },
            { 118, Ldfld },
            { 119, Ldflda },
            { 120, Ldftn },
            { 121, Ldind_I },
            { 122, Ldind_I1 },
            { 123, Ldind_I2 },
            { 124, Ldind_I4 },
            { 125, Ldind_I8 },
            { 126, Ldind_R4 },
            { 127, Ldind_R8 },
            { 128, Ldind_Ref },
            { 129, Ldind_U1 },
            { 130, Ldind_U2 },
            { 131, Ldind_U4 },
            { 132, Ldlen },
            { 133, Ldloc },
            { 134, Ldloc_0 },
            { 135, Ldloc_1 },
            { 136, Ldloc_2 },
            { 137, Ldloc_3 },
            { 138, Ldloc_S },
            { 139, Ldnull },
            { 140, Ldobj },
            { 141, Ldsfld },
            { 142, Ldstr },
            { 143, Ldtoken },
            { 144, Ldvirtftn },
            { 145, Leave },
            { 146, Leave_S },
            { 147, Localloc },
            { 148, Mkrefany },
            { 149, Mul },
            { 150, Mul_Ovf },
            { 151, Mul_Ovf_Un },
            { 152, Neg },
            { 153, Newarr },
            { 154, Newobj },
            { 155, Nop },
            { 156, Not },
            { 157, Or },
            { 158, Pop },
            { 159, Rem },
            { 160, Rem_Un },
            { 161, Ret },
            { 162, Rethrow },
            { 163, Shl },
            { 164, Shr },
            { 165, Shr_Un },
            { 166, Sizeof },
            { 167, Starg },
            { 168, Starg_S },
            { 169, Stelem },
            { 170, Stelem_I },
            { 171, Stelem_I1 },
            { 172, Stelem_I2 },
            { 173, Stelem_I4 },
            { 174, Stelem_I8 },
            { 175, Stelem_R4 },
            { 176, Stelem_R8 },
            { 177, Stelem_Ref },
            { 178, Stfld },
            { 179, Stind_I },
            { 180, Stind_I1 },
            { 181, Stind_I2 },
            { 182, Stind_I4 },
            { 183, Stind_I8 },
            { 184, Stind_R4 },
            { 185, Stind_R8 },
            { 186, Stind_Ref },
            { 187, Stloc },
            { 188, Stloc_0 },
            { 189, Stloc_1 },
            { 190, Stloc_2 },
            { 191, Stloc_3 },
            { 192, Stloc_S },
            { 193, Stobj },
            { 194, Stsfld },
            { 195, Sub },
            { 196, Sub_Ovf },
            { 197, Sub_Ovf_Un },
            { 198, Switch },
            { 199, Throw },
            { 200, Unbox },
            { 201, Unbox_Any },
            { 202, Xor },
        };

        #region Operators
        private static void Add(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Add, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Add_Ovf(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Add, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Add_Ovf_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Add, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void And(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.And, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Ceq(VMContext context, object operand)
        {
            var val2 = context.Stack.DirectPop();
            var val1 = context.Stack.DirectPop();
            context.Stack.DirectPush(val1 == val2 ? 1 : 0);
            context.Index++;
        }
        private static void Cgt(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var isGreater = (bool)Factory.CreateArithmethicFactory(ArithmeticOpKeys.Cgt, values);
            context.Stack.DirectPush(isGreater ? 1 : 0);
            context.Index++;
        }
        private static void Cgt_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var isGreater = (bool)Factory.CreateArithmethicFactory(ArithmeticOpKeys.Cgt, values);
            context.Stack.DirectPush(isGreater ? 1 : 0);
            context.Index++;
        }
        private static void Clt(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var isGreater = (bool)Factory.CreateArithmethicFactory(ArithmeticOpKeys.Clt, values);
            context.Stack.DirectPush(isGreater ? 1 : 0);
            context.Index++;
        }
        private static void Clt_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var isGreater = (bool)Factory.CreateArithmethicFactory(ArithmeticOpKeys.Clt, values);
            context.Stack.DirectPush(isGreater ? 1 : 0);
            context.Index++;
        }
        private static void Div(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Div, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Div_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Div, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Mul(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Mul, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Mul_Ovf(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Mul, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Mul_Ovf_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Mul, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Neg(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop(1);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Neg, value);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Not(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop(1);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Not, value);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Or(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Or, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Rem(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Rem, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Rem_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Rem, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Shl(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Shl, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Shr(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Shr, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Shr_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Shr, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Sub(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Sub, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Sub_Ovf(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Sub, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Sub_Ovf_Un(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Sub, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        private static void Xor(VMContext context, object operand)
        {
            var values = context.Stack.DirectPop(2);
            var result = Factory.CreateArithmethicFactory(ArithmeticOpKeys.Xor, values);
            context.Stack.DirectPush(result);
            context.Index++;
        }
        #endregion

        #region InlineBrTarget
        private static void Beq(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (Values[0].Equals(Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Beq_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (Values[0].Equals(Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bge(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] >= (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bge_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] >= (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bge_Un(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) >= unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bge_Un_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) >= unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bgt(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] > (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bgt_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] > (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bgt_Un(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) > unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bgt_Un_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) > unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Ble(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] <= (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Ble_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] <= (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Ble_Un(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) <= unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Ble_Un_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) <= unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Blt(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] < (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Blt_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if ((int)Values[0] < (int)Values[1])
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Blt_Un(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) < unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Blt_Un_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) < unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bne_Un(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) != unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Bne_Un_S(VMContext context, object operand)
        {
            var Values = context.Stack.DirectPop(2);
            if (unchecked((uint)Values[0]) != unchecked((uint)Values[1]))
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Br(VMContext context, object operand) =>
            context.Index = (int)operand;
        private static void Br_S(VMContext context, object operand) =>
            context.Index = (int)operand;
        private static void Brfalse(VMContext context, object operand)
        {
            var cond = context.Stack.DirectPop();
            if (cond is int I32 && I32 == 0)
                context.Index = (int)operand;
            else if (cond is bool B32 && B32 == false)
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Brfalse_S(VMContext context, object operand)
        {
            var cond = context.Stack.DirectPop();
            if (cond is int I32 && I32 == 0)
                context.Index = (int)operand;
            else if (cond is bool B32 && B32 == false)
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Brtrue(VMContext context, object operand)
        {
            var cond = context.Stack.DirectPop();
            if (cond is int I32 && I32 == 1)
                context.Index = (int)operand;
            else if (cond is bool B32 && B32 == true)
                context.Index = (int)operand;
            else
                context.Index++;
        }
        private static void Brtrue_S(VMContext context, object operand)
        {
            var cond = context.Stack.DirectPop();
            if (cond is int I32 && I32 == 1)
                context.Index = (int)operand;
            else if (cond is bool B32 && B32 == true)
                context.Index = (int)operand;
            else
                context.Index++;
        }
        #endregion

        #region InlineMethod
        private static void Call(VMContext context, object operand)
        {
            object instance = null;
            var methodDisc = (MethodBase)context.ResolveMethod((int)operand);
            var paramsTypes = methodDisc.GetParameters();
            var pSlot = context.Stack.DirectPop(paramsTypes.Length);
            if (!methodDisc.IsStatic) instance = context.Stack.DirectPop();
            var invokeResult = methodDisc.Invoke(instance, pSlot);
            if (invokeResult != null) context.Stack.DirectPush(invokeResult);
            context.Index++;
        }
        private static void Callvirt(VMContext context, object operand)
        {
            object instance = null;
            var methodDisc = (MethodBase)context.ResolveMethod((int)operand);
            var paramsTypes = methodDisc.GetParameters();
            var pSlot = context.Stack.DirectPop(paramsTypes.Length);
            if (!methodDisc.IsStatic) instance = context.Stack.DirectPop();
            var invokeResult = methodDisc.Invoke(instance, pSlot);
            if (invokeResult != null) context.Stack.DirectPush(invokeResult);
            context.Index++;
        }
        private static void Ldftn(VMContext context, object operand)
        {
            var method = (MethodBase)context.ResolveMethod((int)operand);
            context.Stack.DirectPush(method.MethodHandle.GetFunctionPointer());
            context.Index++;
        }
        private static void Newobj(VMContext context, object operand)
        {
            var methodDisc = (ConstructorInfo)context.ResolveMethod((int)operand);
            var paramsTypes = methodDisc.GetParameters();
            var pSlot = context.Stack.DirectPop(paramsTypes.Length);
            var invokeResult = methodDisc.Invoke(pSlot);
            if (invokeResult != null) context.Stack.DirectPush(invokeResult);
            context.Index++;
        }
        private static void Ldtoken(VMContext context, object operand)
        {
            var memberHandle = context.ResolveMember((int)operand);
            if (memberHandle is Type TRef) // typeof(...)
                context.Stack.DirectPush(TRef.TypeHandle);
            else if (memberHandle is MethodBase MRef) // methodof(...)
                context.Stack.DirectPush(MRef.MethodHandle);
            else if (memberHandle is FieldInfo FRef) // fieldof(...)
                context.Stack.DirectPush(FRef.FieldHandle);
            else
                throw new NotSupportedException(); // bruh :/
            context.Index++;
        }
        private static void Ldvirtftn(VMContext context, object operand)
        {
            var instance = context.Stack.DirectPop();
            var addrMethod = (MethodBase)context.ResolveMethod((int)operand);
            if (instance is null) throw new NullReferenceException();
            context.Stack.DirectPush(addrMethod.MethodHandle.GetFunctionPointer());
            context.Index++;
        }
        #endregion

        #region Constants
        private static void Ldc_I4(VMContext context, object operand)
        {
            context.Stack.DirectPush((int)operand);
            context.Index++;
        }
        private static void Ldc_I4_0(VMContext context, object operand)
        {
            context.Stack.DirectPush(0);
            context.Index++;
        }
        private static void Ldc_I4_1(VMContext context, object operand)
        {
            context.Stack.DirectPush(1);
            context.Index++;
        }
        private static void Ldc_I4_2(VMContext context, object operand)
        {
            context.Stack.DirectPush(2);
            context.Index++;
        }
        private static void Ldc_I4_3(VMContext context, object operand)
        {
            context.Stack.DirectPush(3);
            context.Index++;
        }
        private static void Ldc_I4_4(VMContext context, object operand)
        {
            context.Stack.DirectPush(4);
            context.Index++;
        }
        private static void Ldc_I4_5(VMContext context, object operand)
        {
            context.Stack.DirectPush(5);
            context.Index++;
        }
        private static void Ldc_I4_6(VMContext context, object operand)
        {
            context.Stack.DirectPush(6);
            context.Index++;
        }
        private static void Ldc_I4_7(VMContext context, object operand)
        {
            context.Stack.DirectPush(7);
            context.Index++;
        }
        private static void Ldc_I4_8(VMContext context, object operand)
        {
            context.Stack.DirectPush(8);
            context.Index++;
        }
        private static void Ldc_I4_M1(VMContext context, object operand)
        {
            context.Stack.DirectPush(-1);
            context.Index++;
        }
        private static void Ldc_I4_S(VMContext context, object operand)
        {
            context.Stack.DirectPush((int)operand);
            context.Index++;
        }
        private static void Ldc_I8(VMContext context, object operand)
        {
            context.Stack.DirectPush((long)operand);
            context.Index++;
        }
        private static void Ldc_R4(VMContext context, object operand)
        {
            context.Stack.DirectPush((float)operand);
            context.Index++;
        }
        private static void Ldc_R8(VMContext context, object operand)
        {
            context.Stack.DirectPush((double)operand);
            context.Index++;
        }
        private static void Ldstr(VMContext context, object operand)
        {
            context.Stack.DirectPush((string)operand);
            context.Index++;
        }
        #endregion

        #region Casts
        private static void Box(VMContext context, object operand)
        {
            var value = context.Stack.Pop();
            var boxType = context.ResolveType((int)operand);
            context.Stack.DirectPush(value.Cast(boxType));
            context.Index++;
        }
        private static void Castclass(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Unbox(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Unbox_Any(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Conversations
        private static void Conv_I(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            IntPtr? nativeInt = null;
            if (value is int I32) nativeInt = new IntPtr(I32);
            if (value is long I64) nativeInt = new IntPtr(I64);
            if (nativeInt != null) context.Stack.DirectPush(nativeInt);
            context.Index++;
        }
        private static void Conv_I1(VMContext context, object operand)
        {
            var value = new sbyte?(context.Stack.Pop().I8);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_I2(VMContext context, object operand)
        {
            var value = new short?(context.Stack.Pop().I16);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_I4(VMContext context, object operand)
        {
            var value = new int?(context.Stack.Pop().I32);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_I8(VMContext context, object operand)
        {
            var value = new long?(context.Stack.Pop().I64);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }

        private static void Conv_Ovf_I(VMContext context, object operand)
        {
            checked 
            {
                var value = context.Stack.DirectPop();
                IntPtr? nativeInt = null;
                if (value is int I32) nativeInt = new IntPtr(I32);
                if (value is long I64) nativeInt = new IntPtr(I64);
                if (nativeInt != null) context.Stack.DirectPush(nativeInt);
            }
            context.Index++;
        }
        private static void Conv_Ovf_I_Un(VMContext context, object operand)
        {
            checked
            {
                var value = context.Stack.DirectPop();
                IntPtr? nativeInt = null;
                if (value is int I32) nativeInt = new IntPtr((int)(uint)unchecked(I32));
                if (value is long I64) nativeInt = new IntPtr(unchecked(I64));
                if (nativeInt != null) context.Stack.DirectPush(nativeInt);
            }
            context.Index++;
        }

        private static void Conv_Ovf_I1(VMContext context, object operand)
        {
            checked
            {
                var value = new sbyte?(context.Stack.Pop().I8);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_I1_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new sbyte?((sbyte)(uint)unchecked(context.Stack.Pop().I8));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_Ovf_I2(VMContext context, object operand)
        {
            checked
            {
                var value = new short?(context.Stack.Pop().I16);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_I2_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new short?((short)(uint)unchecked(context.Stack.Pop().I16));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_Ovf_I4(VMContext context, object operand)
        {
            checked
            {
                var value = new int?(context.Stack.Pop().I32);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_I4_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new int?((int)(uint)unchecked(context.Stack.Pop().I32));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_Ovf_I8(VMContext context, object operand)
        {
            checked
            {
                var value = new long?(context.Stack.Pop().I64);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_I8_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new long?((int)(uint)unchecked(context.Stack.Pop().I64));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_Ovf_U(VMContext context, object operand)
        {
            checked
            {
                var value = context.Stack.DirectPop();
                UIntPtr? nativeInt = null;
                if (value is uint U32) nativeInt = new UIntPtr(U32);
                if (value is ulong U64) nativeInt = new UIntPtr(U64);
                if (nativeInt != null) context.Stack.DirectPush(nativeInt);
            }
            context.Index++;
        }
        private static void Conv_Ovf_U_Un(VMContext context, object operand)
        {
            checked
            {
                var value = context.Stack.DirectPop();
                UIntPtr? nativeInt = null;
                if (value is uint U32) nativeInt = new UIntPtr(unchecked(U32));
                if (value is ulong U64) nativeInt = new UIntPtr(unchecked(U64));
                if (nativeInt != null) context.Stack.DirectPush(nativeInt);
            }
            context.Index++;
        }

        private static void Conv_Ovf_U1(VMContext context, object operand)
        {
            checked
            {
                var value = new byte?(context.Stack.Pop().B);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_U1_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new byte?(unchecked(context.Stack.Pop().B));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_Ovf_U2(VMContext context, object operand)
        {
            checked
            {
                var value = new ushort?(context.Stack.Pop().U16);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_U2_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new ushort?(unchecked(context.Stack.Pop().U16));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_Ovf_U4(VMContext context, object operand)
        {
            checked
            {
                var value = new uint?(context.Stack.Pop().U32);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
                
            }
            context.Index++;
        }
        private static void Conv_Ovf_U4_Un(VMContext context, object operand)
        {
            checked
            {
                var value = new uint?(unchecked(context.Stack.Pop().U32));
                if (value.HasValue) context.Stack.DirectPush(value.Value);

            }
            context.Index++;
        }

        private static void Conv_Ovf_U8(VMContext context, object operand)
        {
            checked
            {
                var value = new ulong?(context.Stack.Pop().U64);
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }
        private static void Conv_Ovf_U8_Un(VMContext context, object operand)
        {

            checked
            {
                var value = new ulong?(unchecked(context.Stack.Pop().U64));
                if (value.HasValue) context.Stack.DirectPush(value.Value);
            }
            context.Index++;
        }

        private static void Conv_R_Un(VMContext context, object operand)
        {
            var value = context.Stack.Pop().U32;
            context.Stack.DirectPush(Convert.ToSingle(value));
            context.Index++;
        }

        private static void Conv_R4(VMContext context, object operand)
        {
            var value = new float?(context.Stack.Pop().F);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_R8(VMContext context, object operand)
        {
            var value = new double?(context.Stack.Pop().R8);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }

        private static void Conv_U(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            UIntPtr? nativeInt = null;
            if (value is uint U32) nativeInt = new UIntPtr(U32);
            if (value is ulong U64) nativeInt = new UIntPtr(U64);
            if (nativeInt != null) context.Stack.DirectPush(nativeInt);
            context.Index++;
        }
        private static void Conv_U1(VMContext context, object operand)
        {
            var value = new byte?(context.Stack.Pop().B);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_U2(VMContext context, object operand)
        {
            var value = new ushort?(context.Stack.Pop().U16);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_U4(VMContext context, object operand)
        {
            var value = new uint?(context.Stack.Pop().U32);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        private static void Conv_U8(VMContext context, object operand)
        {
            var value = new ulong?(context.Stack.Pop().U64);
            if (value.HasValue) context.Stack.DirectPush(value.Value);
            context.Index++;
        }
        #endregion

        #region Pointers Load/Store
        /* ==[Loads]== */
        private static unsafe void Ldind_I(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush(*(IntPtr*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush(*(IntPtr*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_I1(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush((int)*(sbyte*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush((int)*(sbyte*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_I2(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush((int)*(short*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush((int)*(short*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_I4(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush(*(int*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush(*(int*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_I8(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush(*(long*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush(*(long*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_R4(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush(*(float*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush(*(float*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_R8(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush(*(double*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush(*(double*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }

        private static void Ldind_Ref(VMContext context, object operand) => throw new NotImplementedException();

        private static unsafe void Ldind_U1(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush((int)*(byte*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush((int)*(byte*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_U2(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush((int)*(ushort*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush((int)*(ushort*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Ldind_U4(VMContext context, object operand)
        {
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr)
                context.Stack.DirectPush((int)*(uint*)I32Ptr.ToPointer());
            else if (addr is UIntPtr U32Ptr)
                context.Stack.DirectPush((int)*(uint*)U32Ptr.ToPointer());
            else
                throw new NotSupportedException();
            context.Index++;
        }
        /* ==[Stores]== */
        private static unsafe void Stind_I(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as IntPtr? != null)
                *(IntPtr*)I32Ptr.ToPointer() = (IntPtr)value;
            else if (addr is UIntPtr U32Ptr && value as UIntPtr? != null)
                *(UIntPtr*)U32Ptr.ToPointer() = (UIntPtr)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Stind_I1(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as sbyte? != null)
                *(sbyte*)I32Ptr.ToPointer() = (sbyte)value;
            else if (addr is UIntPtr U32Ptr && value as sbyte? != null)
                *(sbyte*)U32Ptr.ToPointer() = (sbyte)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Stind_I2(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as short? != null)
                *(short*)I32Ptr.ToPointer() = (short)value;
            else if (addr is UIntPtr U32Ptr && value as short? != null)
                *(short*)U32Ptr.ToPointer() = (short)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Stind_I4(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as int? != null)
                *(int*)I32Ptr.ToPointer() = (int)value;
            else if (addr is UIntPtr U32Ptr && value as int? != null)
                *(int*)U32Ptr.ToPointer() = (int)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Stind_I8(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as long? != null)
                *(long*)I32Ptr.ToPointer() = (long)value;
            else if (addr is UIntPtr U32Ptr && value as long? != null)
                *(long*)U32Ptr.ToPointer() = (long)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Stind_R4(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as float? != null)
                *(float*)I32Ptr.ToPointer() = (float)value;
            else if (addr is UIntPtr U32Ptr && value as float? != null)
                *(float*)U32Ptr.ToPointer() = (float)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }
        private static unsafe void Stind_R8(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            var addr = context.Stack.DirectPop();
            if (addr is IntPtr I32Ptr && value as double? != null)
                *(double*)I32Ptr.ToPointer() = (double)value;
            else if (addr is UIntPtr U32Ptr && value as double? != null)
                *(double*)U32Ptr.ToPointer() = (double)value;
            else
                throw new NotSupportedException();
            context.Index++;
        }

        private static unsafe void Stind_Ref(VMContext context, object operand) => throw new NotImplementedException();

        #endregion

        #region Misc
        private static void Localloc(VMContext context, object operand)
        {
            context.Stack.DirectPush(Marshal.AllocHGlobal(context.Stack.Pop().I32));
            context.Index++;
        }
        private static void Ldnull(VMContext context, object operand)
        {
            context.Stack.DirectPush(null);
            context.Index++;
        }
        private static void Ckfinite(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            if (value is float F && (double.IsNaN(F) || double.IsInfinity(F)))
                throw new ArithmeticException();
            if (value is double D && (double.IsNaN(D) || double.IsInfinity(D)))
                throw new ArithmeticException();
            context.Index++;
        }
        private static void Sizeof(VMContext context, object operand)
        {
            var sizeLayout = Factory.CreateSizeOfFactory(context.ResolveType((int)operand));
            context.Stack.DirectPush(sizeLayout);
            context.Index++;
        }
        private static void Dup(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Stack.Peek());
            context.Index++;
        }
        private static void Pop(VMContext context, object operand)
        {
            context.Stack.Pop();
            context.Index++;
        }
        private static void Nop(VMContext context, object operand) =>
            context.Index++;
        private static void Ret(VMContext context, object operand)
        {
            if (context.Stack.Count is 0)
                context.Stack.DirectPush(null);
            context.Index++;
        }
        private static void Throw(VMContext context, object operand)
        {
            var exception = context.Stack.DirectPop();
            if (!(exception is Exception)) throw new NullReferenceException();
            throw (Exception)exception;
        }
        #endregion

        #region Array Load/Store/Misc
        // ==[Loads]==
        private static void Ldelem(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            var castType = context.ResolveType((int)operand);
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush(Convert.ChangeType(((Array)arraySource).GetValue(itemIndex), castType));
            context.Index++;
        }
        private static void Ldelem_I(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((IntPtr)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_I1(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)(sbyte)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_I2(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)(short)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_I4(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_I8(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)(long)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_R4(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((float)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_R8(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((float)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }

        private static void Ldelem_Ref(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush(((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }

        private static void Ldelem_U1(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)(byte)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_U2(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)(ushort)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        private static void Ldelem_U4(VMContext context, object operand)
        {
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            context.Stack.DirectPush((int)(uint)((Array)arraySource).GetValue(itemIndex));
            context.Index++;
        }
        // ==[Stores]==
        private static void Stelem(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            var castType = context.ResolveType((int)operand);
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue(Convert.ChangeType(itemValue, castType), itemIndex);
            context.Index++;
        }
        private static void Stelem_I(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((IntPtr)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_I1(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((sbyte)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_I2(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((short)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_I4(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((int)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_I8(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((long)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_R4(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((float)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_R8(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue((double)itemValue, itemIndex);
            context.Index++;
        }
        private static void Stelem_Ref(VMContext context, object operand)
        {
            var itemValue = context.Stack.DirectPop();
            var itemIndex = context.Stack.Pop().I32;
            var arraySource = context.Stack.DirectPop();
            if (arraySource as Array is null) throw new NullReferenceException();
            ((Array)arraySource).SetValue(itemValue, itemIndex);
            context.Index++;
        }
        // ==[Misc]==
        private static void Ldlen(VMContext context, object operand)
        {
            var array = context.Stack.DirectPop();
            if (array as Array != null)
                context.Stack.DirectPush(((Array)array).Length);
            else
                throw new NullReferenceException();
            context.Index++;
        }
        private static void Newarr(VMContext context, object operand)
        {
            var arrLength = context.Stack.Pop().I32;
            var arrType = context.ResolveType((int)operand);
            context.Stack.DirectPush(Array.CreateInstance(arrType, arrLength));
            context.Index++;
        }
        #endregion

        #region Arguments/Locals (Load/Store)
        // ==[Arguments/Load]==
        private static void Ldarg(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Parameters[(int)operand]);
            context.Index++;
        }
        private static void Ldarg_0(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Parameters[0]);
            context.Index++;
        }
        private static void Ldarg_1(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Parameters[1]);
            context.Index++;
        }
        private static void Ldarg_2(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Parameters[2]);
            context.Index++;
        }
        private static void Ldarg_3(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Parameters[3]);
            context.Index++;
        }
        private static void Ldarg_S(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Parameters[(int)operand]);
            context.Index++;
        }
        // ==[Arguments/Store]==
        private static void Starg(VMContext context, object operand)
        {
            context.Parameters[(int)operand] = context.Stack.DirectPop();
            context.Index++;
        }
        private static void Starg_S(VMContext context, object operand)
        {
            context.Parameters[(int)operand] = context.Stack.DirectPop();
            context.Index++;
        }
        // ==[Locals/Load]==
        private static void Ldloc(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Locals[(int)operand]);
            context.Index++;
        }
        private static void Ldloc_0(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Locals[0]);
            context.Index++;
        }
        private static void Ldloc_1(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Locals[1]);
            context.Index++;
        }
        private static void Ldloc_2(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Locals[2]);
            context.Index++;
        }
        private static void Ldloc_3(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Locals[3]);
            context.Index++;
        }
        private static void Ldloc_S(VMContext context, object operand)
        {
            context.Stack.DirectPush(context.Locals[(int)operand]);
            context.Index++;
        }
        // ==[Locals/Store]==
        private static void Stloc(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            context.Locals[(int)operand] = value;
            context.Index++;
        }
        private static void Stloc_0(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            context.Locals[0] = value;
            context.Index++;
        }
        private static void Stloc_1(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            context.Locals[1] = value;
            context.Index++;
        }
        private static void Stloc_2(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            context.Locals[2] = value;
            context.Index++;
        }
        private static void Stloc_3(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            context.Locals[3] = value;
            context.Index++;
        }
        private static void Stloc_S(VMContext context, object operand)
        {
            var value = context.Stack.DirectPop();
            context.Locals[(int)operand] = value;
            context.Index++;
        }
        #endregion

        #region Fields
        private static void Ldsfld(VMContext context, object operand)
        {
            var field = context.ResolveField((int)operand);
            context.Stack.DirectPush(field.GetValue(null));
            context.Index++;
        }
        private static void Ldfld(VMContext context, object operand)
        {
            var instance = context.Stack.DirectPop();
            var field = context.ResolveField((int)operand);
            if (field.IsStatic && instance == null)
                context.Stack.DirectPush(field.GetValue(null));
            else
                context.Stack.DirectPush(field.GetValue(instance));
            context.Index++;
        }
        private static void Stfld(VMContext context, object operand)
        {
            var value = context.Stack.Pop();
            var instance = context.Stack.DirectPop();
            var field = context.ResolveField((int)operand);
            field.SetValue(instance, value.Cast(field.FieldType));
            context.Index++;
        }
        private static void Stsfld(VMContext context, object operand)
        {
            var value = context.Stack.Pop();
            var field = context.ResolveField((int)operand);
            field.SetValue(null, value.Cast(field.FieldType));
            context.Index++;
        }
        #endregion

        #region Still Not Impelemented
        private static void Constrained(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Initobj(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Isinst(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Ldobj(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Mkrefany(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Stobj(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        private static void Switch(VMContext context, object operand)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region NoImpl :3
        private static void Initblk(VMContext context, object operand) => throw new NotImplementedException();
        private static void Cpblk(VMContext context, object operand) => throw new NotImplementedException();
        private static void Cpobj(VMContext context, object operand) => throw new NotImplementedException();
        private static void Rethrow(VMContext context, object operand) => throw new NotImplementedException();
        private static void Break(VMContext context, object operand) => throw new NotImplementedException();
        private static void Jmp(VMContext context, object operand) => throw new NotImplementedException();
        private static void Calli(VMContext context, object operand) => throw new NotImplementedException();
        private static void Ldflda(VMContext context, object operand) => throw new NotImplementedException();
        private static void Leave(VMContext context, object operand) => throw new NotImplementedException();
        private static void Leave_S(VMContext context, object operand) => throw new NotImplementedException();
        #endregion

        #region ObfuscationFunctions :)
        /*internal static IntPtr GetCalli(RuntimeMethodHandle H) {
            var token = BitConverter.GetBytes(MethodBase.GetMethodFromHandle(H).MetadataToken);
            var rawCode = new byte[0x18];
            // Count
            rawCode[0x0] = 0x2;
            rawCode[0x1] = 0;
            rawCode[0x2] = 0;
            rawCode[0x3] = 0;
            // Ldftn
            rawCode[0x4] = 0x78;
            rawCode[0x5] = 0;
            rawCode[0x6] = 0;
            rawCode[0x7] = 0;
            // I32 Operand
            rawCode[0x8] = 0x1;
            rawCode[0x9] = 0;
            rawCode[0xA] = 0;
            rawCode[0xB] = 0;
            // Token Emitting
            rawCode[0xC] = token[0x0];
            rawCode[0xD] = token[0x1];
            rawCode[0xE] = token[0x2];
            rawCode[0xF] = token[0x3];
            // Ret
            rawCode[0x10] = 0xA1;
            rawCode[0x11] = 0;
            rawCode[0x12] = 0;
            rawCode[0x13] = 0;
            // Null Operand
            rawCode[0x14] = 0x5;
            rawCode[0x15] = 0;
            rawCode[0x16] = 0;
            rawCode[0x17] = 0;
            return (IntPtr)Interpreter.ExecuteDirect(rawCode);
        }*/
        #endregion
    }
}