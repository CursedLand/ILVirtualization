
#region Usings
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
#endregion

namespace Runtime
{
    public class ILValue
    {
        private object _valueObj;
        private Type _objType;


        public ILValue(object obj)
            : this(obj, obj != null ? obj.GetType() : typeof(object)) { }
        public ILValue(object obj, Type objType)
        {
            _valueObj = obj;
            _objType = objType;
        }

        public object Cast(Type castType) {
            if (_valueObj is null || castType is null) return null;
            //return Factory.CreateBoxFactory(_valueObj, castType);
            switch (Type.GetTypeCode(castType ?? typeof(object)))
            {
                case TypeCode.Object: return _valueObj;
                case TypeCode.Boolean: return _valueObj is int I32B ? Convert.ToBoolean(I32B) : Convert.ToBoolean(_valueObj);
                case TypeCode.Char: return (char)_valueObj;
                case TypeCode.SByte: return I8;
                case TypeCode.Byte: return B;
                case TypeCode.Int16: return I16;
                case TypeCode.UInt16: return U16;
                case TypeCode.Int32: return I32;
                case TypeCode.UInt32: return U32;
                case TypeCode.Int64: return I64;
                case TypeCode.UInt64: return U64;
                case TypeCode.Single: return F;
                case TypeCode.Double: return R8;
                case TypeCode.Decimal: return Convert.ToDecimal( _valueObj);
                case TypeCode.String: return (string)_valueObj;
                default:
                    try { return Convert.ChangeType(_valueObj, castType); }
                    catch { return Factory.CreateBoxFactory(_valueObj, castType); }
            }
        }

        #region Signed
        public short I16
        {
            get => Convert.ToInt16(_valueObj);
        }
        public int I32
        {
            get => Convert.ToInt32(_valueObj);
        }
        public long I64
        {
            get => Convert.ToInt64(_valueObj);
        }
        #endregion

        #region UnSigned
        public byte B
        {
            get => Convert.ToByte(_valueObj);
        }
        public ushort U16
        {
            get => Convert.ToUInt16(_valueObj);
        }
        public uint U32
        {
            get => Convert.ToUInt32(_valueObj);
        }
        public ulong U64
        {
            get => Convert.ToUInt64(_valueObj);
        }
        #endregion

        public sbyte I8
        {
            get => Convert.ToSByte(_valueObj);
        }
        public float F
        {
            get => Convert.ToSingle(_valueObj);
        }
        public double R8
        {
            get => Convert.ToDouble(_valueObj);
        }

        public bool IsNull
        {
            get => _valueObj is null;
        }
        public object Value
        {
            get => _valueObj;
        }
        public bool IsValueType
        {
            get => (ValueType?.IsValueType).GetValueOrDefault();
        }
        public bool IsEnum 
        {
            get => (ValueType?.IsEnum).GetValueOrDefault();
        }
        public Type ValueType 
        {
            get => _objType;
        }
    }
}