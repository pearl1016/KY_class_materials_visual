using System;
using System.Windows.Forms;

namespace _024_TwoForms
{
    public partial class Form1 : Form
    {
        Form2 f; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f == null)
                f = new Form2(this);
            f.Show();
            // this.Hide();  //Form1을 숨긴다
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = f.textBox1.Text; //f=form2
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Common.str + " " + Common.value);
        }
    }

    public static class Common
    {
        public static string str = "";
        public static int value = 0;
    }
}



//파워포인트 보고 이해하기