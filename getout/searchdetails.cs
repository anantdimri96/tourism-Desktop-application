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
    public partial class searchdetails : Form
    {
        String cat;
        public static int d_id;
        
        public static String city;
        public searchdetails()
        {
            InitializeComponent();
        }
        public searchdetails(String s, String c)
        {
            InitializeComponent();
            cat = s;
            city = c;
           
          
        }


        private void searchdetails_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            if (cat == "Hill Station")
            {
                try
                {

                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=mysql";
                    //Display query  
                    string Query = "Select dest_id,city,state from anantneil." + city + " where dest_id < 6000 and dest_id not in(select dest_id from anantneil.prevdetails where user_id = " + login.uid + ");";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    //  MyConn2.Open();  
                    //For offline connection we weill use  MySqlDataAdapter class.  
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    DataSet dataset;
                    dataset = new DataSet();
                    MyAdapter.Fill(dataset);
                    int t = dTable.Rows.Count;
                    DataRow dr;
                    dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                    // MyConn2.Close();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
            if (cat == "Beaches")
            {
                try
                {

                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=mysql";
                    //Display query  

                    string Query = "Select dest_id,city,state from anantneil." + city +
                        " where dest_id > 7999 and dest_id not in(select dest_id from anantneil.prevdetails where user_id = " + login.uid + ");";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    //  MyConn2.Open();  
                    //For offline connection we weill use  MySqlDataAdapter class.  

                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    DataSet dataset;
                    dataset = new DataSet();
                    MyAdapter.Fill(dataset);
                    int t = dTable.Rows.Count;
                    DataRow dr;
                    dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                    // MyConn2.Close();  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            int.TryParse(textBox1.Text, out d_id);
            ModeofTransport obj = new ModeofTransport(d_id);
            this.Hide();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out d_id);
            hotels h = new hotels(d_id);
            h.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out d_id);
            ThingsToDo obj = new ThingsToDo();
            this.Hide();
            obj.Show();
        }
    }
}
