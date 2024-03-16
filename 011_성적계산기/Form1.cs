using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _011_성적계산기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //잘못
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            double kor = double.Parse(txtKor.Text);
            double math = double.Parse(txtMath.Text);
            double eng = double.Parse(txtEng.Text);

            double sum = kor + math + eng;
            double avg = sum / 3;

            txtSum.Text = sum.ToString(); //text는 string이고, sum은 double이기 때문에 sum.ToString으로 문자열을 표현하게 한다. 
            txtAvg.Text = avg.ToString("0.0"); //0.0 -> 소수점 1자리까지만 표시해준다
        }
    }
}
