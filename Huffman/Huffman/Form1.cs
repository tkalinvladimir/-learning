using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huffman
{
    public partial class Form1 : Form
    {
        HuffmanTree huffmanTree;
        BitArray encoded;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(input);
            // Encode
            encoded = huffmanTree.Encode(input);
            foreach (bool bit in encoded)
            {
                textBox2.Text = textBox2.Text + (bit ? 1 : 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string decoded = huffmanTree.Decode(encoded);
            textBox3.Text = decoded;
        }

     
    }
}
