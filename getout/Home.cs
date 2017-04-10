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
    public partial class Home : Form
    {
        
        String s;
        public static String uname;
       
        public Home()
        {
            InitializeComponent();
            
            string connection = "datasource=localhost;port=3306;username=root;password=mysql";
            
            MySqlConnection conn = null;
            MySqlDataReader rd = null;

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                s = "Select * from anantneil.user where user_id='" + login.uid + "';";
                MySqlCommand cmd = new MySqlCommand(s, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    label1.Text = rd.GetString(1) + " " + rd.GetString(3); //name set
                    label3.Text = rd.GetInt32(0).ToString();              //user id set
                    uname = label1.Text;
                    
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

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

        }
   
      

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            search s = new search();
            s.Show();
            this.Hide();

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

   

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

      

        private void updateDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Persondetails p = new Persondetails();
            p.Show();
            this.Hide();
        }

        private void previousJourneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /*prevdetails pd = new prevdetails();
            pd.Show();
            this.Hide();*/
           
           
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                Form1 obj = new Form1();
                this.Hide();
                obj.Show();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Closing application....");
            //this.Close();
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
