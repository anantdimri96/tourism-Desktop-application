using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace getout
{   
   
    public partial class Form1 : Form
    {
        public static int uid;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Dream_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            string connection = "Datasource=localhost;port=3306;username=root;password=mysql";
            
            MySqlConnection conn = null;
            MySqlDataReader rd = null;
            int maxid = 0;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                String s;
                s = "Select max(user_id) from anantneil.logindetails";
                MySqlCommand cmd = new MySqlCommand(s, conn);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                    maxid = rd.GetInt32(0);
                
               
                maxid++;
                uid = maxid;
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: ", ex.ToString());

            }
            finally
            {
                if (rd != null)
                {
                    rd.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }

            MessageBox.Show("new Generated ID : " + maxid);
            Form2 test = new Form2();
            test.Show();
            this.Hide();
        }

        private void Explore_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            AdminLogin a = new AdminLogin();
            a.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
