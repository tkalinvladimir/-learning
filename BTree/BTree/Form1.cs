using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTree
{
    public partial class Form1 : Form
    {
        Tree MyTree;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num;
            label1.Text = "";
            label2.Text = "";
            if (textBox1.Text == "")
            {
                return;
            }
            num = rnd.Next(0, 100);
            MyTree = new Tree(num);
            label1.Text = num.ToString().PadLeft(3);
            int n = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i < n; i++)
            {
                num = rnd.Next(0, 100);
                label1.Text = label1.Text + num.ToString().PadLeft(3);
                MyTree.AddRc(num);
            }
            string teststring = "";
            MyTree.Print(null, ref teststring);
            label2.Text = teststring;
            teststring = "";
            MyTree.LCR(null,ref teststring, false);
            label3.Text = teststring;
            teststring = "";
            MyTree.CLR(null, ref teststring, false);
            label4.Text = teststring;
            teststring = "";
            MyTree.RCL(null, ref teststring, false);
            label5.Text = teststring;
            teststring = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }
    }
}
