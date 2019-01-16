using System.IO;

namespace OsuParsers.Serialization
{
    public class SerializationWriter : BinaryWriter
    {
        public SerializationWriter(Stream s) : base(s) { }

        public void WriteNullableString(string data)
        {
            if (string.IsNullOrEmpty(data))
                Write((byte)0);
            else
            {
                Write((byte)0x0B);
                Write(data);
            }
        }
    }
}
