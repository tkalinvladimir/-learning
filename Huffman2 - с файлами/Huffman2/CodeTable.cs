using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman2
{
    class CodeTable
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

        public string getEncodeString(string originalString)
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


            byte[] ba = BitUtils.BitArrayToByteArray(bt);
            bool succes = ByteArrayToFile(originalString + "_vovrar", ba);
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

        public static bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

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
