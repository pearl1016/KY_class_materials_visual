using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace _009_CheckBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string states=""; //상태

            //int a[10] = { 1, 2, 3, 4 }; C#
            //int[] a = { 1, 2, 3, 4 };
            CheckBox[] cBox = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 }; //배열만듦


            foreach(var c in cBox) //각각 foreach, var=checkBox
            {
                states += string.Format("{0} : {1}\n",
                    c.Text, c.Checked);
            }
            MessageBox.Show(states, "CheckBox States");
            

            string summary = "좋아하는 과일은 ";
            foreach(var c in cBox)
            {
                if (c.Checked == true)
                    summary += c.Text + " "; //" " : 빈칸, +=: 붙여준다 

            }
            MessageBox.Show(summary, "summary");
        }
    }
}
