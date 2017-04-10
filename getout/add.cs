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
    public partial class add : Form
    {
       int d;
        public add(String s)
        {
            InitializeComponent();
            int.TryParse(s, out d);
            label2.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=mysql";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "insert into anantneil.prevdetails(user_id,dest_id) values('" + login.uid + "','" + d + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                MessageBox.Show("Destination added");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Destination id is already there in the database.");
            }
           
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
