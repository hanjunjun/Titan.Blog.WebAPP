using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Titan.Blog.Infrastructure.Utility
{
    /// <summary>
    /// Md5
    /// </summary>
    public static class Md5Helper
    {
        private static readonly char[] ToDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <returns></returns>
        public static string Md5Hex(string sourceArray)
        {
            var temp = Encoding.UTF8.GetBytes(sourceArray);
            var temp1 = ByteArray2SByteArray(temp);
            var rResult = Md5Hex(temp1);
            return rResult;
        }

        private static string Md5Hex(IEnumerable<sbyte> sourceArray)
        {
            var md5SByteArray = Md5Encode(sourceArray);
            var charArray = EncodeHex(md5SByteArray);
            var rResult = new string(charArray);
            return rResult;
        }

        private static sbyte[] Md5Encode(IEnumerable<sbyte> source)
        {
            var temp = SByteArray2ByteArray(source);
            var temp1 = new MD5CryptoServiceProvider().ComputeHash(temp);
            var rResult = ByteArray2SByteArray(temp1);
            return rResult;
        }

        private static char[] EncodeHex(IList<sbyte> data)
        {
            var l = data.Count;
            var rResult = new char[l << 1];
            for (int i = 0, j = 0; i < l; i++)
            {
                rResult[j++] = ToDigits[MoveByte((0xF0 & data[i]), 4)];
                rResult[j++] = ToDigits[0x0F & data[i]];
            }
            return rResult;
        }
        private static int MoveByte(int value, int pos)
        {
            if (value >= 0) return value >> pos;
            var s = Convert.ToString(value, 2);
            for (var i = 0; i < pos; i++)
            {
                s = "0" + s.Substring(0, 31);
            }
            return Convert.ToInt32(s, 2);
        }

        private static sbyte[] ByteArray2SByteArray(IEnumerable<byte> sourceByte)
        {
            return sourceByte.Select(Byte2SByte).ToArray();
        }
        private static byte[] SByteArray2ByteArray(IEnumerable<sbyte> sourceByte)
        {
            return sourceByte.Select(SByte2Byte).ToArray();
        }

        private static sbyte Byte2SByte(byte sourceSByte)
        {
            sbyte rResult;
            if (sourceSByte < 128)
            {
                rResult = (sbyte)sourceSByte;
            }
            else
            {
                rResult = (sbyte)(sourceSByte - 256);
            }
            return rResult;
        }

        private static byte SByte2Byte(sbyte sourceSByte)
        {
            byte rResult;
            if (sourceSByte < 0)
            {
                rResult = (byte)(sourceSByte + 256);
            }
            else
            {
                rResult = (byte)sourceSByte;
            }
            return rResult;
        }
    }
}