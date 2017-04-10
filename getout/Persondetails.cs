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
    public partial class Persondetails : Form
    {
        char g;
        Boolean test;
        Boolean flag;
        String email;
        int check=0;
        public Persondetails()
        {
            InitializeComponent();
            label7.Text = ""+login.uid;
            test = false;
            dateTimePicker1.MaxDate = System.DateTime.Now;
            
         }
        public Persondetails(String s)
        {
            InitializeComponent();
            label7.Text = "" + s;
            check = 1;
            dateTimePicker1.MaxDate = System.DateTime.Now;
        }

        private void Persondetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag=false;
            foreach (char c in textBox2.Text)
            {
                if (c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                    test = true;
            }
            if(test)
            {MessageBox.Show("Please enter characters in the name field");
            test = false;}
            
            if (!test)
            {
                try
                {
                    //This is my connection string i have assigned the database file address path  
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=mysql";
                    //This is my insert query in which i am taking input from the user through windows forms  
                    if ((textBox1.Text.Contains("@")) && (textBox1.Text.Contains(".com")))
                    {
                        flag = true;
                        string Query = "insert into anantneil.user(user_id,fname,mname,lname,gender,dob,email) values('" + this.label7.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + g + "','" + dateTimePicker1.Text + "','" + textBox1.Text + "');";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        //This is command class which will handle the query and connection object.  
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                        MessageBox.Show("Save Data");

                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();
                    }
                    else
                    {
                        MessageBox.Show("Re-enter email address");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (flag == true)
                {
                    login l = new login();
                    l.Show();
                    this.Hide();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                g = 'M';
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                g = 'F';
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                try
                {
                    string connection = "datasource=localhost;port=3306;username=root;password=mysql";
                    //in function
                    MySqlConnection conn = null;
                    MySqlDataReader rd = null;
                    conn = new MySqlConnection(connection);
                    conn.Open();
                    String s;
                    int i;
                    int.TryParse(label7.Text, out i);
                    s = "Select * from anantneil.user where user_id='" + i + "';";


                    MySqlCommand cmd = new MySqlCommand(s, conn);
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                        flag = true;
                    else
                        flag = false;

                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
                if (flag)
                {
                    try
                    {
                        //This is my connection string i have assigned the database file address path  
                        string MyConnection2 = "datasource=localhost;port=3306;username=root;password=mysql";
                        //This is my update query in which i am taking input from the user through windows forms and update the record.  
                        string Query = "update anantneil.user set fname ='" + this.textBox2.Text + "', mname = '" + this.textBox3.Text + "', lname = '" + this.textBox4.Text + "', gender = '" + g + "', dob = '" + dateTimePicker1.Text + "'where user_id ='" + this.label7.Text + "';";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Details Updated");
                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();//Connection closed here  
                        Home gback = new Home();
                        this.Hide();
                        gback.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("You can not update details. Select complete registration.");
            }
        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            email = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (check==0)
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            
        }
    }
}
