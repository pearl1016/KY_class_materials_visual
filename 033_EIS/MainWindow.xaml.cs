using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace _033_EIS
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private string pos = "";  //private는 class안에서만 쓸 수 있다
        private string dept = "";
        private string gender = "";
        private string dateEnter = "";
        private string dateExit = "";

        string connStr = "server=localHost; user id=root; password=0000; database=eis_db";
        MySqlConnection conn;  //DB연결을 위해서 선언

        public MainWindow()
        {
           
            InitializeComponent();
            
            conn = new MySqlConnection(connStr); //객체 conn
            //MessageBox.Show("conn 설정!");
            DisplayDataGrid();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (rbMale.IsChecked == true)
                gender = "남성";
            else if (rbFemale.IsChecked == true)
                gender = "여성";

            if (dpEnter.SelectedDate != null) //선택이 됐다면
                dateEnter = dpEnter.SelectedDate.Value.Date.ToShortDateString();
            if (dpExit.SelectedDate != null)
                dateExit = dpExit.SelectedDate.Value.Date.ToShortDateString();
            else
                dateExit = DateTime.MaxValue.ToShortDateString();

            dept = cbDept.Text;
            pos = cbPos.Text;

            MessageBox.Show(dept + " " + pos + " " + gender + " " + dateEnter + " " + dateExit);
            conn.Open();

            string sql = string.Format(
                 "INSERT INTO eis_table (name, department, position, " +
        "gender, data_enter, date_exit, contact, comment)" +
        " VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                txtName.Text, dept, pos, gender, dateEnter, dateExit, txtContact.Text, txtComment.Text);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            if (cmd.ExecuteNonQuery() == 1)
                MessageBox.Show("Inserted Successfully!");

            conn.Close();
            InitControls();
            DisplayDataGrid();

        }

        private void InitControls()
        {
            txtEid.Text = "";
            txtName.Text = "";
            txtComment.Text = "";
            txtContact.Text = "";
            cbDept.SelectedIndex = -1; // -1은 선택된 것이 없다는 뜻
            cbPos.SelectedIndex = -1; // -1은 선택된 것이 없다는 뜻
            rbMale.IsChecked = false;
            rbFemale.IsChecked = false;
            dpEnter.Text = "";
            dpExit.Text = "";

        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {

            DisplayDataGrid();

        }

        private void DisplayDataGrid()
        {
            conn.Open();

            string sql = "SELECT * FROM eis_table";

            //알아두기
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGrid.ItemsSource = ds.Tables[0].DefaultView;

            conn.Close();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // DataGrid dg = (DataGrid)sender;
            DataGrid dg = sender as DataGrid; //이벤트에서dg를 받아서 사용한것
            DataRowView rowView = dg.SelectedItem as DataRowView;

            if (rowView == null)
                return;

            txtEid.Text = rowView.Row[0].ToString();
            txtName.Text = rowView.Row[1].ToString();
            cbDept.Text = rowView.Row[0].ToString();
            cbPos.Text = rowView.Row[0].ToString();

            if (rowView.Row[4].ToString() == "남성")
            {
                rbMale.IsChecked = true;
                rbFemale.IsChecked = false;

            }
            else
            {
                rbMale.IsChecked = false;
                rbFemale.IsChecked = true;
            }

            dpEnter.Text = rowView.Row[5].ToString();
            txtName.Text = rowView.Row[6].ToString();
            txtContact.Text = rowView.Row[7].ToString();
            txtComment.Text = rowView.Row[8].ToString();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            dept = cbDept.Text;
            pos = cbPos.Text;
            if (rbMale.IsChecked == true)
                gender = "남성";
            else
                gender = "여성";

            try
            {
                string sql = string.Format(
           "UPDATE eis_table SET name='{0}', department='{1}',"
           + "position='{2}', gender='{3}', data_enter='{4}', "
           + "date_exit='{5}', contact='{6}', comment='{7}'"
           + "WHERE eid={8}",
           txtName.Text, dept, pos, gender, dpEnter.Text, dpExit.Text,
           txtContact.Text, txtComment.Text, txtEid.Text);//eid는 정수이기 때문에 '{8}' 말고 {8}로 해야한다. 

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (cmd.ExecuteNonQuery()==1)
                    MessageBox.Show("Updated Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            InitControls();
            DisplayDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            try
            {
                string sql = string.Format("DELETE FROM eis_table WHERE eid={0}", txtEid.Text);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                if (cmd.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Deleted Successfully!");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }


            conn.Close();
            InitControls();
            DisplayDataGrid();
        }
    }

         
}
