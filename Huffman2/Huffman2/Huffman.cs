using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman2
{

    class Node : IComparable<Node>
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

        public static string makeEncodeString(string originalString, Node ROOT)
        {
            string s = "";
            for (int i = 0; i < originalString.Length; i++)
            {
                char c = originalString[i];
                Node.Find(ROOT, (byte)c, ref s);
            }
            return s;
        }

        public static void Find(Node N, byte c, ref string s)
        {
            if (N.data.Count() == 1)
            {
                return; //нашли но тект уже прибавлен ранее при входе сюда
            }
            if (N.left != null && N.left.isFindData(c))
            {
                s = s + "0";
                Find(N.left, c, ref s);
                return;
            }
            if (N.right != null && N.right.isFindData(c))
            {
                s = s + "1";
                Find(N.right, c, ref s);
                return;
            }
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
            int[] x = Node.calcWeights(originalString);
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
                    Node.Find(root, (byte)x[i], ref s);
                    table.putIn((byte)x[i], s);
                }
            }
            return table;
                     
        }

    }
}
