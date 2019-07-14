using System;
using System.Collections.Generic;
using System.IO;

namespace OsuParsers.Serialization
{
    internal class SerializationWriter : BinaryWriter
    {
        public SerializationWriter(Stream s) : base(s) { }

        public override void Write(string str)
        {
            if (str == null)
            {
                Write((byte)ObjType.Null);
            }
            else
            {
                Write((byte)ObjType.String);
                base.Write(str);
            }
        }

        public void Write(DateTime dateTime)
        {
            Write(dateTime.ToUniversalTime().Ticks);
        }

        public void Write<T, U>(IDictionary<T, U> d)
        {
            if (d == null)
            {
                Write(-1);
            }
            else
            {
                Write(d.Count);
                foreach (KeyValuePair<T, U> kvp in d)
                {
                    WriteObject(kvp.Key);
                    WriteObject(kvp.Value);
                }
            }
        }

        public void WriteObject(object obj)
        {
            if (obj == null)
            {
                Write((byte)ObjType.Null);
            }
            else
            {
                switch (obj.GetType().Name)
                {
                    case "Boolean":
                        Write((byte)ObjType.Bool);
                        Write((bool)obj);
                        break;
                    case "Byte":
                        Write((byte)ObjType.Byte);
                        Write((byte)obj);
                        break;
                    case "UInt16":
                        Write((byte)ObjType.UShort);
                        Write((ushort)obj);
                        break;
                    case "UInt32":
                        Write((byte)ObjType.UInt);
                        Write((uint)obj);
                        break;
                    case "UInt64":
                        Write((byte)ObjType.ULong);
                        Write((ulong)obj);
                        break;
                    case "SByte":
                        Write((byte)ObjType.SByte);
                        Write((sbyte)obj);
                        break;
                    case "Int16":
                        Write((byte)ObjType.Short);
                        Write((short)obj);
                        break;
                    case "Int32":
                        Write((byte)ObjType.Int);
                        Write((int)obj);
                        break;
                    case "Int64":
                        Write((byte)ObjType.Long);
                        Write((long)obj);
                        break;
                    case "Char":
                        Write((byte)ObjType.Char);
                        base.Write((char)obj);
                        break;
                    case "String":
                        Write((byte)ObjType.String);
                        base.Write((string)obj);
                        break;
                    case "Single":
                        Write((byte)ObjType.Float);
                        Write((float)obj);
                        break;
                    case "Double":
                        Write((byte)ObjType.Double);
                        Write((double)obj);
                        break;
                    case "Decimal":
                        Write((byte)ObjType.Decimal);
                        Write((decimal)obj);
                        break;
                    case "DateTime":
                        Write((byte)ObjType.DateTime);
                        Write((DateTime)obj);
                        break;
                    case "Byte[]":
                        Write((byte)ObjType.ByteArray);
                        base.Write((byte[])obj);
                        break;
                    case "Char[]":
                        Write((byte)ObjType.CharArray);
                        base.Write((char[])obj);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
