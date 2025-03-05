using Microsoft.Data.SqlClient;

namespace DATABASETEST
{


    public partial class Form1 : Form
    {
        FormOverviewPanel FormOV = new FormOverviewPanel();
        Form1 Login = new Form1();
        public Form1()
        {
            InitializeComponent();
            //string connectionString = "Server=IT\\SQLEXPRESS; Database=LIHCI; Integrated Security=True; TrustServerCertificate=True;";
            //string connectionStringlocal = "Server=192.168.18.219,1433;Database=LIHCI;User Id=Outside_User;Password=lihci2025;";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            string connectionString = "Server=IT\\SQLEXPRESS; Database=LIHCI; Integrated Security=True; TrustServerCertificate=True;";
            var con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                string stm = "SELECT COUNT(*) from User_TBL WHERE Username =@NAME and Password =@PASSWORD";
                SqlCommand cmd = new SqlCommand(stm,con);
                cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                cmd.Parameters.AddWithValue("@PASSWORD", textBox2.Text);
                int count = (int)cmd.ExecuteScalar();
                con.Close();
                if (count > 0)
                {
                    MessageBox.Show("You Are Logged In!", "Connected To The Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.ResetText();
                    textBox2.ResetText();
                    Login.Close();
                    FormOV.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username Or Wrong Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.ResetText();
                    textBox2.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error" + ex.Message, "Error", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }
    }
}
