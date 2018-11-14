using SevenZip;
using SevenZip.Compression.LZMA;
using System;
using System.IO;

namespace OsuParsers.Replays.SevenZip
{
    internal class LZMAHelper
    {
        public static MemoryStream Compress(Stream inStream)
        {
            inStream.Position = 0;

            CoderPropID[] propIDs =
            {
                CoderPropID.DictionarySize,
                CoderPropID.PosStateBits,
                CoderPropID.LitContextBits,
                CoderPropID.LitPosBits,
                CoderPropID.Algorithm,
            };

            object[] properties =
            {
                (1 << 16),
                2,
                3,
                0,
                2,
            };

            var outStream = new MemoryStream();
            Encoder encoder = new Encoder();
            encoder.SetCoderProperties(propIDs, properties);
            encoder.WriteCoderProperties(outStream);
            for (int i = 0; i < 8; i++)
                outStream.WriteByte((Byte)(inStream.Length >> (8 * i)));
            encoder.Code(inStream, outStream, -1, -1, null);
            outStream.Flush();
            outStream.Position = 0;

            return outStream;
        }

        public static MemoryStream Decompress(Stream inStream)
        {
            var decoder = new Decoder();

            byte[] properties = new byte[5];
            if (inStream.Read(properties, 0, 5) != 5)
                throw new Exception("input .lzma is too short");
            decoder.SetDecoderProperties(properties);

            long outSize = 0;
            for (int i = 0; i < 8; i++)
            {
                int v = inStream.ReadByte();
                if (v < 0)
                    break;
                outSize |= ((long)(byte)v) << (8 * i);
            }
            long compressedSize = inStream.Length - inStream.Position;

            var outStream = new MemoryStream();
            decoder.Code(inStream, outStream, compressedSize, outSize, null);
            outStream.Flush();
            outStream.Position = 0;
            return outStream;
        }

        public static byte[] Compress(byte[] inBytes)
        {
            using (var ms = new MemoryStream(inBytes, false))
                return Compress(ms).ToArray();
        }

        public static byte[] Decompress(byte[] inBytes)
        {
            using (var ms = new MemoryStream(inBytes, false))
                return Decompress(ms).ToArray();
        }
    }
}
