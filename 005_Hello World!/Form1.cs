using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _005_Hello_World_
{
    public partial class Form1 : Form
    {
        Color defaultFormColor; //Form의 기본배경색
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == defaultFormColor)
            {
                this.BackColor = Color.Blue;
                label1.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = defaultFormColor;
                label1.ForeColor = Color.Black; //ForeColor 글씨색
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        //Form 프로그램이 시작될 때
        private void Form1_Load(object sender, EventArgs e)
        {
            defaultFormColor = this.BackColor;
        }
    }
}