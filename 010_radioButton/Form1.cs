using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _010_radioButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "국적 : "; //초기화

            if (rbKorea.Checked)
                result += "대한민국\n";
            else if (rbChina.Checked)
                result += "중국\n";
            else if (rbJapan.Checked)
                result += "일본\n";
            else if (rbOther.Checked)
                result += "그 외의 국가\n";

            if (rbMale.Checked)  //(checkedRB == rbMale)도 가능
                result += "성별 : 남성";
            else if (rbFemale.Checked)
                result += "성별 : 여성";

            MessageBox.Show(result, "제출");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //잘못
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //잘못
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            //잘못
        }
    }
}
