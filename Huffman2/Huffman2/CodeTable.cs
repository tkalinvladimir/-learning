using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman2
{
    class CodeTable
    {
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
            foreach (char c in originalString)
            {
                BitArray value;
                if (this.dict.TryGetValue((byte)c, out value))
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
            return s;
        }
    }
}
