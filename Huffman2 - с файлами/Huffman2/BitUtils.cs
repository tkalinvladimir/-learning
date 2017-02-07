using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman2
{
    public static class BitUtils
    {
        public const int ByteLength = 8;

        public static int ConvertToInt32(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            int len = input.Length;
            int sum = 0, position = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                if (input[i] == '1')
                    sum = sum + (1 << position);
                position++;
            }

            return sum;
        }

        public static string BitArrayToString(BitArray bits)
        {
            StringBuilder sb = new StringBuilder(bits.Length);

            for (int i = bits.Length - 1; i >= 0; i--)
            {
                bool bit = bits[i];

                sb.Append(Convert.ToInt32(bit));
            }

            return sb.ToString();
        }

        public static Tuple<byte[], byte> BitArrayToByteArray(this BitArray bits)
        {
            return BitArrayToByteArray(bits, 0, bits.Length);
        }

        public static Tuple<byte[],byte> BitArrayToByteArray(this BitArray bits, int startIndex, int count)
        {
            // Get the size of bytes needed to store all bytes
            int bytesize = count / ByteLength;

            // Any bit left over another byte is necessary
            if (count % ByteLength > 0)
                bytesize++;
            byte bbitpos = (byte)(count % ByteLength);

            // For the result
            byte[] bytes = new byte[bytesize];
           

            // Must init to good value, all zero bit byte has value zero
            // Lowest significant bit has a place value of 1, each position to
            // to the left doubles the value
            byte value = 0;
            byte significance = 1;

            // Remember where in the input/output arrays
            int bytepos = 0;
            int bitpos = startIndex;

            while (bitpos - startIndex < count)
            {
                // If the bit is set add its value to the byte
                if (bits[bitpos])
                    value += significance;

                bitpos++;

                if (bitpos % ByteLength == 0)
                {
                    // A full byte has been processed, store it
                    // increase output buffer index and reset work values
                    bytes[bytepos] = value;
                    bytepos++;
                    value = 0;
                    significance = 1;
                }
                else
                {
                    // Another bit processed, next has doubled value
                    significance *= 2;
                }
            }
            if (count % ByteLength > 0)
                bytes[bytepos] = value;
            return Tuple.Create(bytes, bbitpos);
        }

       

    }
}
