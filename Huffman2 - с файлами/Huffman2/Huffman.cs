
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Huffman2
{

   public class Node : System.IComparable<Node>
    {
        public int Weight { get; set; }
        List<bool> bits; 
        public List<byte> data;
        public Node left;
        public Node right;

        public Node(int Weight, byte data, Node left, Node right)
        {
            this.Weight = Weight;
            this.data = new List<byte>();
            AddData(data);
            this.left = left;
            this.right = right;
        }

        public Node(int Weight, Node left, Node right)
        {
            this.Weight = Weight;
            this.data = new List<byte>();
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var d in data) {
                s = s + (char)d;            }
            return s;
            
        }

        public void AddData(byte data)
        {
            this.data.Add(data);
        }

        public void AddData(List<byte> data)
        {
            this.data.AddRange(data);
        }

        public bool isFindData(byte data)
        {
            return this.data.Contains(data);
        }

        public int CompareTo(Node comparePart)
        {
            if (comparePart == null)
                return 1;
            else
                return this.Weight.CompareTo(comparePart.Weight);
        }

        public static void Find(Node N, byte c, ref string s, int deep)
        {
            if (N.left != null && N.left.isFindData(c))
            {
                s = s + "0";
                Node.Find(N.left, c, ref s, deep + 1);
                return;
            }
            if (N.right != null && N.right.isFindData(c))
            {
                s = s + "1";
                Node.Find(N.right, c, ref s, deep + 1);
                return;
            }
            if (deep == 0) s = s + "0";
        }

        public static int[] calcWeights(byte[] s)
        {
            

            int[] res = new int[256];
            for (int i = 0; i< s.Length; i++)
            {
                res[s[i]]++;
            }
            return res;
        }

        public static CodeTable Encode(string originalString)
        {
            byte[] allBytes = File.ReadAllBytes(originalString);
            int[] x = calcWeights(allBytes);
            List<Node> List = new List<Node>();

            for (int i = 0; i <= 255; i++)
            {
                if (x[i] != 0)
                {
                    Node N = new Node(x[i], (byte)i, null, null);
                    List.Add(N);
                }
            }

            while (List.Count > 1)
            {
                List<Node> sorted = List.OrderBy(Node => Node.Weight).ToList<Node>();
                if (sorted.Count >= 2)
                {
                    List<Node> nodes2 = sorted.Take(2).ToList<Node>();
                    Node newN = new Node(nodes2[0].Weight + nodes2[0].Weight, nodes2[0], nodes2[1]);
                    newN.AddData(nodes2[0].data);
                    newN.AddData(nodes2[1].data);
                    List.Remove(nodes2[0]);
                    List.Remove(nodes2[1]);
                    List.Add(newN);
                    System.Console.WriteLine(nodes2[0].ToString() +" + " +nodes2[1].ToString() + " = " +newN.ToString());
                }
            }
            Node root = List.First();

            CodeTable table = new CodeTable(root);

            for (int i = 0; i <= 255; i++)
            {
                if (x[i] != 0)
                {
                    string s = "";
                    Node.Find(root, (byte)i, ref s, 0);
                    System.Console.WriteLine(i.ToString() + " = " + s);

                    BitArray bitArr = new BitArray(s.Length);
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == '0')
                        {
                            bitArr.Set(j, false);
                        }
                        if (s[j] == '1')
                        {
                            bitArr.Set(j, true);
                        }
                    }

                    table.putIn((byte)i, bitArr);
                }
            }
            return table;
        }

        public static string Decode(string CodeString, CodeTable table)
        {
            // байты в биты - по таблице найти байты и заного создать байтмассив и зафигачить в файл
            byte[] allBytes = File.ReadAllBytes(CodeString);
            StringBuilder sb = new StringBuilder();
            BitArray bCodeString2 = new BitArray(allBytes);

            foreach (var b in bCodeString2)
            {
                sb.Append((bool)b ? "1" : "0");
            }
            
            string CodeString2 = sb.ToString();


            string s = "";
            string searchString = "";
            foreach (char b in CodeString2)
            {

                if (b == '0')
                {
                    searchString = searchString + '0';
                }
                if (b == '1')
                {
                    searchString = searchString + '1';
                }


                BitArray searchArr = new BitArray(searchString.Length);
                for (int j = 0; j < searchString.Length; j++)
                {
                    if (searchString[j] == '0')
                    {
                        searchArr.Set(j, false);
                    }
                    if (searchString[j] == '1')
                    {
                        searchArr.Set(j, true);
                    }
                }

                foreach (var bt in table.dict)
                {
                    bool isMatch = true;
                    if (bt.Value.Count == searchArr.Count)
                    {
                        for (int i = 0; i < bt.Value.Count; i++)
                        {
                            if (bt.Value[i] != searchArr[i])
                            {
                                isMatch = false;
                            } 
                        }
                    }
                    if (isMatch && bt.Value.Count == searchArr.Count)
                    {
                        s = s + (char)bt.Key;
                        searchString = "";
                        break;
                    }
                }
            }

            byte[] toBytes = Encoding.ASCII.GetBytes(s);
            CodeString = CodeString.Replace("_vovrar","");
            bool succes = CodeTable.ByteArrayToFile_decode(CodeString+"1", toBytes);
            if (succes)
            {
                s = CodeString + "1";
            }
            else
            {
                s = "Failed";
            }

            return s;
        }
    }
}
