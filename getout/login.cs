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
using System.Net.Mail;

namespace getout
{
    
    public partial class login : Form
    {
        Boolean flag;
        int t;
       public static String userid;
        public static int uid;
        public static String eid;
        int i;
        String pass;
        public login()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {string u,pass;
            string connection = "datasource=localhost;port=3306;username=root;password=mysql";
            //in function
            MySqlConnection conn = null;
            MySqlDataReader rd = null;

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                String s;
                int i;
                int.TryParse(textBox1.Text, out i);
                s = "Select * from anantneil.logindetails where id='" + i + "' and password='" + textBox2.Text + "';";

                MySqlCommand cmd = new MySqlCommand(s, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                { flag = true;


                }
                else
                    flag = false;
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


         
            Home a = new Home();
            a.Show();
            this.Hide();


            

            /*
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                int.TryParse(textBox1.Text, out i);
                string ss = "select email from anantneil_user where user_id='" + i + "';";

                MySqlCommand cm = new MySqlCommand(ss, conn);
                rdr = cm.ExecuteReader();
                if (rdr.Read())
                    eid = rdr.GetString(rdr.GetOrdinal("email"));
                //MessageBox.Show("" + eid);
            }
            catch (MySqlException ex) 
                    {
                        Console.WriteLine("Error: {0}",  ex.ToString());

                    } finally 
                    {

                        if(rdr!=null)
                        {
                            rdr.Close();
                        }

                        if (conn != null) 
                        {
                            conn.Close();
                        }

                    }
    


            if (flag)
    {
        for (t = 0; t <= 200; t++)
        {
            progressBar1.Value = t;
        }
        MessageBox.Show("Valid");

                /*
                MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
       try
        {
            mail.From = new MailAddress("getout67@gmail.com");
            mail.To.Add(eid);
            mail.Subject = "Logged in";
            mail.Body = "User login at " + System.DateTime.Now;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("getout67@gmail.com", "passgetout67");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            MessageBox.Show("Mail sent");
        }catch (Exception ex) 
        {
            MessageBox.Show(ex.ToString());
        }
      //  Home obj = new Home();
      //  obj.Show();
       // this.Hide();
        }
    else
    {
        MessageBox.Show("Invalid details");
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        try
        {
            mail.From = new MailAddress("getout67@gmail.com");

            mail.To.Add(eid);
            mail.Subject = "Invalid Login";
            mail.Body = "Invalid user login at " + System.DateTime.Now;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("getout67@gmail.com", "passgetout67");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            MessageBox.Show("Mail sent");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
        textBox2.Text = "";
    }/*/
        
    }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            userid = textBox1.Text;
            int.TryParse(textBox1.Text, out uid); 
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            string connection = "datasource=localhost;port=3306;username=root;password=mysql";
            //in function
            
            MySqlConnection conn = null;
            MySqlDataReader rd1 = null;
            MySqlDataReader rd2 = null;
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                String qu;

                int.TryParse(textBox1.Text, out i);
                qu = "Select password from anantneil.logindetails where user_id='" + i +"';";

                MySqlCommand cmd1 = new MySqlCommand(qu, conn);
                rd1 = cmd1.ExecuteReader();
                if (rd1.Read())
                {
                    flag = true;
                    pass = rd1.GetString(rd1.GetOrdinal("password"));
                   
                }
                else
                    flag = false;





            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (rd1 != null)
                {
                    rd1.Close();
                }


                if (conn != null)
                {
                    conn.Close();
                }

            }
            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                int.TryParse(textBox1.Text, out i);
                string s1 = "select email from anantneil.user where user_id='" + i + "';";

                MySqlCommand cm = new MySqlCommand(s1, conn);
                rd2 = cm.ExecuteReader();
                if (rd2.Read())
                    eid = rd2.GetString(rd2.GetOrdinal("email"));
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                try
                {
                    mail.From = new MailAddress("getout67@gmail.com");
                    mail.To.Add(eid);
                    mail.Subject = "Password";
                    mail.Body = "Your password is " + pass;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("getout67@gmail.com", "passgetout67");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    MessageBox.Show("Please check your mail.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                //MessageBox.Show("" + eid);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {

                if (rd2 != null)
                {
                    rd2.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }

            }/*/


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
