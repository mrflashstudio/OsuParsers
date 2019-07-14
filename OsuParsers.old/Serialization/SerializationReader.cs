using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OsuParsers.Serialization
{
    internal class SerializationReader : BinaryReader
    {
        public SerializationReader(Stream s) : base(s, Encoding.UTF8) { }

        public override string ReadString()
        {
            if (0 == ReadByte()) return null;
            return base.ReadString();
        }

        public byte[] ReadByteArray()
        {
            int len = ReadInt32();
            if (len > 0) return ReadBytes(len);
            if (len < 0) return null;
            return new byte[] { };
        }

        public char[] ReadCharArray()
        {
            int len = ReadInt32();
            if (len > 0) return ReadChars(len);
            if (len < 0) return null;
            return new char[] { };
        }

        public DateTime ReadDateTime()
        {
            return new DateTime(ReadInt64(), DateTimeKind.Utc);
        }

        public List<T> ReadList<T>()
        {
            int count = ReadInt32();
            if (count < 0) return null;
            List<T> d = new List<T>(count);
            for (int i = 0; i < count; i++) d.Add((T)ReadObject());
            return d;
        }

        public Dictionary<T, U> ReadDictionary<T, U>()
        {
            int count = ReadInt32();
            if (count < 0) return null;
            Dictionary<T, U> d = new Dictionary<T, U>();
            for (int i = 0; i < count; i++) d[(T)ReadObject()] = (U)ReadObject();
            return d;
        }

        public object ReadObject()
        {
            ObjType t = (ObjType)ReadByte();
            switch (t)
            {
                case ObjType.Bool:
                    return ReadBoolean();
                case ObjType.Byte:
                    return ReadByte();
                case ObjType.UShort:
                    return ReadUInt16();
                case ObjType.UInt:
                    return ReadUInt32();
                case ObjType.ULong:
                    return ReadUInt64();
                case ObjType.SByte:
                    return ReadSByte();
                case ObjType.Short:
                    return ReadInt16();
                case ObjType.Int:
                    return ReadInt32();
                case ObjType.Long:
                    return ReadInt64();
                case ObjType.Char:
                    return ReadChar();
                case ObjType.String:
                    return base.ReadString();
                case ObjType.Float:
                    return ReadSingle();
                case ObjType.Double:
                    return ReadDouble();
                case ObjType.Decimal:
                    return ReadDecimal();
                case ObjType.DateTime:
                    return ReadDateTime();
                case ObjType.ByteArray:
                    return ReadByteArray();
                case ObjType.CharArray:
                    return ReadCharArray();
                default:
                    return null;
            }
        }
    }
}
