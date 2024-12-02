﻿


namespace Opc.Cpx
{
    internal struct Context
    {
        public byte[] Buffer;
        public int Index;
        public TypeDictionary Dictionary;
        public TypeDescription Type;
        public bool BigEndian;
        public int CharWidth;
        public string StringEncoding;
        public string FloatFormat;
        public const string STRING_ENCODING_ACSII = "ASCII";
        public const string STRING_ENCODING_UCS2 = "UCS-2";
        public const string FLOAT_FORMAT_IEEE754 = "IEEE-754";

        public Context(byte[] buffer)
        {
            Buffer = buffer;
            Index = 0;
            Dictionary = (TypeDictionary)null;
            Type = (TypeDescription)null;
            BigEndian = false;
            CharWidth = 2;
            StringEncoding = "UCS-2";
            FloatFormat = "IEEE-754";
        }
    }
}
