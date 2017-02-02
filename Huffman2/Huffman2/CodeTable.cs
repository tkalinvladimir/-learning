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
        public Dictionary<byte, string> dict;
        Node ROOT;

        public CodeTable(Node Root)
        {
            this.dict = new Dictionary<byte, string>();
            this.ROOT = Root;
        }

        public void putIn(byte b, string bits)
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
                string value = "";
                if (this.dict.TryGetValue((byte)c, out value))
                {
                    s = s + value;
                }
            }
            return s;
        }
    }
}
