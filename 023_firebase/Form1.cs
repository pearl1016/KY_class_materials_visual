using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;


namespace _023_firebase
{
    
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "88YQYDxdYEfO5fHY1bYfs4hUrgnM6OaQgaCUzAn3", //비밀번호
            BasePath = "https://helmet-4-information-default-rtdb.firebaseio.com/" //경로
        };  //파이어베이스에서 가져와야할 것

        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
                MessageBox.Show("Connection 성공!");

            dt.Columns.Add("Id");
            dt.Columns.Add("학번"); 
            dt.Columns.Add("이름");
            dt.Columns.Add("전화번호");

            dataGridView1.DataSource = dt;

            export();
        }

        private async void btnInsert_Click(object sender, EventArgs e) //인서트도 찝어주심
        {
            //카운터 수정
            FirebaseResponse resp =
                await client.GetAsync("VP01_Counter/nPhones");
            Counter c = resp.ResultAs<Counter>();
            MessageBox.Show(c.cnt.ToString());

            
            //비동기 프로그램(async ~ await)
            var data = new Data
            {
                //ID = txtID.Text,
                ID = (c.cnt + 1).ToString(),
                SID = txtSID.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            // SetResponse response =
            //    await client.SetAsync("VP01_Phonebook/" + txtID.Text, data); //data할때
            SetResponse response =
               await client.SetAsync("VP01_Phonebook/" + data.ID, data); //카운터값 읽을때 data.ID
            //73-74찝어주심
            Data result = response.ResultAs<Data>(); 
            MessageBox.Show("Data Inserted : Id = " + result.ID);
  

            var obj = new Counter
            {
                cnt = c.cnt + 1
            };
            SetResponse r = await client.SetAsync("VP01_Counter/nPhones", obj);

            export();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtSID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("VP01_Phonebook/" + txtID.Text);
            Data obj = response.ResultAs<Data>();
//99-100찝어주심
            txtID.Text = obj.ID;
            txtSID.Text = obj.SID;
            txtName.Text = obj.Name;
            txtPhone.Text = obj.Phone;
        }

        private async void btnRevise_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                ID = txtID.Text,
                SID = txtSID.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            FirebaseResponse response = 
                await client.UpdateAsync("VP01_Phonebook/" + txtID.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data updated at : " + result.ID);
            export();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = 
                await client.DeleteAsync("VP01_Phonebook/" + txtID.Text);
            // Data result = response.ResultAs<Data>();
            MessageBox.Show("Data updelete at : " + txtID.Text);
            export();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            export();

        }

        private async void export()
        {
            dt.Rows.Clear();

      int i = 0;
      FirebaseResponse res 
        = await client.GetAsync("VP01_Counter/nPhones");
      Counter obj = res.ResultAs<Counter>();
      int cnt = obj.cnt;

            while(i != cnt)
            {
                i++;
                FirebaseResponse resp = 
                    await client.GetAsync("VP01_Phonebook/" + i);
                Data d = resp.ResultAs<Data>();

                //체크
                if (d != null)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = d.ID;
                    row["학번"] = d.SID;
                    row["이름"] = d.Name;
                    row["전화번호"] = d.Phone;

                    dt.Rows.Add(row);
                }

            }
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //모두 삭제 (확인이 필요)
            DialogResult answer = MessageBox.Show("저장된 데이터가 모두 삭제됩니다. 계속 하시겠습니까?", "Warning!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.No)
                return;

            //firebase의 Counter/cnt 값을 0으로 바꾼다
            var obj = new Counter //객체 만듦
            {
                cnt = 0
            };

            SetResponse res = await client.SetAsync("VP01_Counter/nPhones", obj); //obj로 바꿔준다

            FirebaseResponse response =
                await client.DeleteAsync("VP01_Phonebook"); //phonebook을 통채로 delete한다. 

            dt.Rows.Clear();
            export();
            MessageBox.Show("All data deleted!\n /VP01_Phonebook deleted!");
        }

        private void btdEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender; //dgv로 변환하여 받음
            txtID.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSID.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
        } //언급 및 찝어주심

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
