using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _008_Labels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            button1.Text = "라파엘로, 아테네 학당";
            this.Text = "Lable Control";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "라파엘로 산지오, 이탈리아, 르네상스 3대 거장";
            label2.Text = "르네상스시대의 거장인 라파엘로 산치오가 교황 율리오 2세의 주문으로" +
            "27세인 1509~1510년에 바티칸 사도 궁전 내부의 방들 가운데서 교황의 개인 서재인 " +
            "'서명의 방(Stanza della Segnatura)'에 그린 프레스코 벽화입니다";

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
