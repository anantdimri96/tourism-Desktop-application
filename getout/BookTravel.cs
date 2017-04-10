using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace getout
{
    public partial class BookTravel : Form
    {
        int a, b, c;
        public BookTravel(int a, int b, int c)
        {
            InitializeComponent();
            this.a = a;
            this.b = b;
            this.c = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModeofTransport obj = new ModeofTransport(searchdetails.d_id);
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            this.Hide();
            obj.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (a == 1)
                System.Diagnostics.Process.Start("https://www.irctc.co.in/eticketing/loginHome.jsf");
            else
                MessageBox.Show("Train not suggested for this journey");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (b == 1)
                System.Diagnostics.Process.Start("http://www.makemytrip.com/flights");
            else
                MessageBox.Show("Flights not suggested for this journey");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(c==1)
                System.Diagnostics.Process.Start("http://www.easycabs.com/");
            else
                MessageBox.Show("Cabs not suggested for this journey");
        }

        private void BookTravel_Load(object sender, EventArgs e)
        {

        }
    }
}
