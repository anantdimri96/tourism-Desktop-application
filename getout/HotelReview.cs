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
    public partial class HotelReview : Form
    {
        String hid;
        int hi;
        public HotelReview(String h)
        {
            InitializeComponent();
            int.TryParse(h,out hi);
            hid = h;
            string connection = "datasource=localhost;port=3306;database=anantneil;username=root;password=mysql";
            Boolean flag = true;
            MySqlConnection conn = new MySqlConnection(connection); ;
            MySqlDataReader rd1 = null;

            conn.Open();
            string abc = "select anantneil.get_review(" + hi + ");";
            MySqlCommand cmd = new MySqlCommand(abc, conn);

            rd1 = cmd.ExecuteReader();

            while (rd1.Read())
            {

                label1.Text = rd1.GetString(0);

            }
            conn.Close();
            MySqlDataReader rd2 = null;
            conn.Open();
            String s;
            s = "Select * from anantneil.manipalhotel where hotel_id='" + h + "';";
            MySqlCommand cmd2 = new MySqlCommand(s, conn);
            rd2 = cmd2.ExecuteReader();
            if (rd2.Read())
            {
                label3.Text = rd2.GetString(rd2.GetOrdinal("name"));
                label4.Text = rd2.GetString(rd2.GetOrdinal("price"));
            }
            conn.Close();
          /*  MySqlDataReader rd2 = null;
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                //MySqlConnection conn = null;
                //conn = new MySqlConnection(connection);
                conn.Open();
                cmd.Connection = conn;
                cmd.Connection = conn;
                cmd.CommandText = "DROP PROCEDURE IF EXISTS review9";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "CREATE PROCEDURE review9(IN hid VARCHAR(4), OUT review_Description varchar(500)) BEGIN select review into review_Description from anantneil.reviews where hotel_id='"+hid+"'; END";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Procedure created");
                conn.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("not created");
                conn.Close();
                MessageBox.Show(ex.ToString());
            }
            if(flag)
            {
                conn.Open();
                String qu;
                qu = "Select * from anantneil.reviews where hotel_id='"+h+"';";
                MySqlCommand cmd1 = new MySqlCommand(qu, conn);
                rd1 = cmd1.ExecuteReader();
                if(rd1.Read())
                    label1.Text = rd1.GetString(rd1.GetOrdinal("review"));
                conn.Close();

                conn.Open();
                String s;
                s = "Select * from anantneil.manipalhotel where hotel_id='"+h+"';";
                MySqlCommand cmd2 = new MySqlCommand(s, conn);
                rd2 = cmd2.ExecuteReader();
                if (rd2.Read())
                {
                    label3.Text = rd2.GetString(rd2.GetOrdinal("name"));
                    label4.Text = rd2.GetString(rd2.GetOrdinal("price"));
                }
                conn.Close();
            }
            if (flag == false)
            {
                try
                {

                    conn.Open();
                    cmd.Connection = conn;

                    cmd.CommandText = "review9";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@hid", "9001");

                    cmd.Parameters.AddWithValue("@review_Description", MySqlDbType.VarString);
                    cmd.Parameters["@review_Description"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("" + cmd.Parameters["@review_Description"].Value);

                }
                catch (MySqlException ex)
                {

                    conn.Close();
                    MessageBox.Show(ex.ToString());
                }
            }*/

        }

        private void HotelReview_Load(object sender, EventArgs e)
        {
          


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.goibibo.com/hotels/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            hotels obj = new hotels(searchdetails.d_id);
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchdetails obj = new searchdetails(search.cat, search.city);
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            this.Hide();
            obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
