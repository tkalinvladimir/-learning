using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman2
{
    public class CodeTable
    {
        public const int ByteLength = 8;

        public Dictionary<byte, BitArray> dict;
        Node ROOT;

        public CodeTable(Node Root)
        {
            this.dict = new Dictionary<byte, BitArray>();
            this.ROOT = Root;
        }

        public void putIn(byte b, BitArray bits)
        {

            try
            {
                dict.Add(b, bits);
            }
            catch
            {
            }
        }

        public string getEncodeString(string originalString, CodeTable table)
        {
            string s = "";
            byte[] allBytes = File.ReadAllBytes(originalString);
            foreach (byte c in allBytes)
            {

                BitArray value;

                if (this.dict.TryGetValue(c, out value))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var b in value)
                    {
                        sb.Append((bool)b ? "1" : "0");
                    }
                    sb.ToString();
                    s = s + sb;
                }
            }
            Console.WriteLine(s);
            BitArray bt = new BitArray(s.Length);
            for (int j = 0; j < s.Length; j++)
            {
                if (s[j] == '0')
                {
                    bt.Set(j, false);
                }
                if (s[j] == '1')
                {
                    bt.Set(j, true);
                }
            }

            var res = BitUtils.BitArrayToByteArray(bt);
            byte[] ba = res.Item1;
            var bitpos = res.Item2;
            bool succes = ByteArrayToFile(originalString + "_vovrar", ba, bitpos, dict);
            if (succes)
            {
                s = originalString + "_vovrar";
            }
            else
            {
                s = "Failed";
            }

            return s;
        }

        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray, byte bitPos, Dictionary<byte, BitArray> dict)
        {
            try
            {
                FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
                int ba = _ByteArray.Length;
                byte[] _ByteArray5 = BitConverter.GetBytes(ba);
                byte[] bitPosition = new byte[1];
                bitPosition[0] = bitPos;

                _FileStream.Write(_ByteArray5, 0, 4);
                _FileStream.Write(bitPosition, 0, 1);
                _FileStream.Write(_ByteArray, 0, ba);

                foreach (var CodingByte in dict)
                {

                    var res = BitUtils.BitArrayToByteArray(CodingByte.Value);
                    byte[] CodingDictData = res.Item1;
                    int bitPosDict = res.Item2;
                    int dlina = CodingDictData.Length;
                    byte[] CodingDictHeader = new byte[3];
                    CodingDictHeader[0] = CodingByte.Key;
                    CodingDictHeader[1] = (byte)dlina;
                    CodingDictHeader[2] = (byte)bitPosDict;
                    _FileStream.Write(CodingDictHeader, 0, CodingDictHeader.Length);
                    _FileStream.Write(CodingDictData, 0, CodingDictData.Length);
                }


                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            return false;
        }

        public static bool ByteArrayToFile_decode(string _FileName, byte[] _ByteArray)
        {
            try
            {
                FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
                int ba = _ByteArray.Length;

                _FileStream.Write(_ByteArray, 0, ba);

                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }

            return false;
        }



    }
}
