using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _024_TwoForms
{
    public partial class Form2 : Form
    {
        Form1 f;
        public Form2(Form1 form)
        {
            InitializeComponent();
            f= form;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //실수
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 f = new Form1();
            f.Show(); //f라는건 폼2에 넘어온 폼
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Text = textBox1.Text;
        } 

        private void button3_Click(object sender, EventArgs e)
        {
            f.label1.Text = textBox1.Text; //Form1의 label1 modifiers 수정
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Common.str = textBox1.Text;
            Common.value = 100;
        }
    }
}
