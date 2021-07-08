
#region Usings
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
#endregion

namespace Runtime
{
    public sealed class Interpreter
    {
        public static byte[] ILVData;

        public static Dictionary<int, byte[]> VData = new Dictionary<int, byte[]>();

        public static void SetupVM()
        {
            var reader = new BinaryReader(new MemoryStream(ILVData));
            var count = BitConverter.ToInt32(reader.ReadBytes(4), 0); // methods count
            for (int x = 0; x < count; x++) {
                int xorKey = BitConverter.ToInt32(reader.ReadBytes(4), 0); // key
                var methodToken = BitConverter.ToInt32(reader.ReadBytes(4), 0); // methodtoken
                methodToken ^= xorKey; // xor token
                var dataCount = BitConverter.ToInt32(reader.ReadBytes(4), 0); // vmdata count
                byte[] data = reader.ReadBytes(dataCount); // data.
                for (int q = 0; q < data.Length; q++) 
                    data[q] ^= (byte)xorKey; // xoring.
                VData[methodToken] = data; // storing.
            }
        }

        public static T Execute<T>(RuntimeMethodHandle m, int i, object[] p)
        {
            var data = VData[i];
            var reader = new BinaryReader(new MemoryStream(data));
            var localCount = reader.ReadInt32();
            var instrCount = reader.ReadInt32();
            var ctx = new VMContext(typeof(Interpreter).Module,
                MethodBase.GetMethodFromHandle(m),
                p, new int[] { localCount, instrCount });
            for (int x = 0; x < instrCount; x++) {
                int behaviourIdentifier = reader.ReadInt32();
                var operandType = (VMOperand)reader.ReadInt32();
                object o = default;
                switch (operandType)
                {
                    case VMOperand.String: o = reader.ReadString(); break;
                    case VMOperand.I32: o = reader.ReadInt32(); break;
                    case VMOperand.I64: o = reader.ReadInt64(); break;
                    case VMOperand.Float: o = reader.ReadSingle(); break;
                    case VMOperand.Double: o = reader.ReadDouble(); break;
                    case VMOperand.Null: o = null; break;
                    case VMOperand.SWTArray: int len = reader.ReadInt32(); int[] arr = new int[len]; for (int q = 0; q < len; q++) arr[q] = reader.ReadInt32(); o = arr; break;
                    default: throw new NotImplementedException();
                }
                ctx.Instructions[x] = new VMInstruction(behaviourIdentifier, new ILValue(o), operandType);
            }
            while (ctx.Instructions.Length > ctx.Index) {
                var instr = ctx.Instructions[ctx.Index];
                BehavioursInfo.BehaviourInfo[instr.Code](ctx, instr.Value.Value);
            }
            return (T)ctx.Stack.DirectPop();
        }

        public static object ExecuteDirect(byte[] code)
        {
            var reader = new BinaryReader(new MemoryStream(code));
            var instrCount = reader.ReadInt32();
            var ctx = new VMContext(typeof(Interpreter).Module,
                MethodBase.GetMethodFromHandle(typeof(LocalList).GetMethods()[0].MethodHandle),
                new object[0], new int[] { 0, instrCount });
            for (int x = 0; x < instrCount; x++) {
                int behaviourIdentifier = reader.ReadInt32();
                var operandType = (VMOperand)reader.ReadInt32();
                object o = default;
                switch (operandType)
                {
                    case VMOperand.String: o = reader.ReadString(); break;
                    case VMOperand.I32: o = reader.ReadInt32(); break;
                    case VMOperand.I64: o = reader.ReadInt64(); break;
                    case VMOperand.Float: o = reader.ReadSingle(); break;
                    case VMOperand.Double: o = reader.ReadDouble(); break;
                    case VMOperand.Null: o = null; break;
                    case VMOperand.SWTArray: int len = reader.ReadInt32(); int[] arr = new int[len]; for (int q = 0; q < len; q++) arr[q] = reader.ReadInt32(); o = arr; break;
                    default: throw new NotImplementedException();
                }
                ctx.Instructions[x] = new VMInstruction(behaviourIdentifier, new ILValue(o), operandType);
            }
            while (ctx.Instructions.Length > ctx.Index) {
                var instr = ctx.Instructions[ctx.Index];
                BehavioursInfo.BehaviourInfo[instr.Code](ctx, instr.Value.Value);
            }
            return ctx.Stack.DirectPop();
        }
    }
}