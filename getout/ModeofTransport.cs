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
    public partial class ModeofTransport : Form
    {
        int a;
        int b;
        int c;
        public ModeofTransport(int id)
        {
            InitializeComponent();
            String s;
            string connection = "datasource=localhost;port=3306;username=root;password=mysql";
            //in function
            MySqlConnection conn = null;
            MySqlDataReader rd = null;
           
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                s = "Select T,F,C from anantneil."+search.city+" where dest_id="+id+";";
                MySqlCommand cmd = new MySqlCommand(s, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    a = rd.GetInt32(rd.GetOrdinal("T"));
                    b = rd.GetInt32(rd.GetOrdinal("F"));
                    c = rd.GetInt32(rd.GetOrdinal("C"));
                }
                if(a==1)
                {
                    label2.Text = "TRAIN";
                    if(b==1)
                    {
                        label3.Text="FLIGHT";
                        if (c == 1)
                            label4.Text = "Car";
                        else
                            label4.Visible = false;
                    }
                    else if(c==1)
                    {
                        label3.Text = "Car";
                        label4.Visible = false;
                    }
                }
                else if( b==1)
                {
                    label4.Visible = false;
                    label2.Text = "Flight";
                    if (c == 1)
                        label3.Text = "car";
                    else
                        label3.Visible = false;
                }
                else if(c==1)
                {
                    label3.Visible = false;
                    label4.Visible = false;
                    label2.Text = "Car";
                }
                else
                {
                    label4.Visible = false;
                    label3.Visible = false;
                    label2.Text = "choose wisely live well-anant neil";
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

        private void ModeofTransport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            searchdetails obj = new searchdetails(search.cat, search.city);
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            this.Hide();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookTravel obj = new BookTravel(a, b, c);
            this.Hide();
            obj.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.irctc.co.in/eticketing/loginHome.jsf");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://makemytrip.com/");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
