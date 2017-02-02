
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
                    Node.Find(root, (byte)x[i], ref s, 0);
                    table.putIn((byte)x[i], s);
                }
            }
            return table;

        }

    }
}
