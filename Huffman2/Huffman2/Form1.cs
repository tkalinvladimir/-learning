using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huffman2
{
    public partial class Form1 : Form
    {
        CodeTable table;
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table = Node.Encode(textBox1.Text);
            textBox2.Text = table.getEncodeString(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = Node.Decode(textBox2.Text,table);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
