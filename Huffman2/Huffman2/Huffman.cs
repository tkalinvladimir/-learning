
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Huffman2
{

    class Node : System.IComparable<Node>
    {
        public int Weight { get; set; }
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

        public static int[] calcWeights(string s)
        {
            int[] res = new int[256];
            foreach (char c in s)
            {
                res[(byte)c]++;
            }
            return res;
        }

        public static CodeTable Encode(string originalString)
        {
            int[] x = calcWeights(originalString);
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
            string s = "";
            string searchString = "";
            foreach (char b in CodeString)
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
                    if (isMatch && bt.Value.Count != 0)
                    {
                        s = s + (char)bt.Key;
                    }
                }
            }
            return s;
        }
    }
}
