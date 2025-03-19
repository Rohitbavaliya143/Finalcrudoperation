//Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudoperatioinsecond
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\hello.mdf;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string sql="select * from login2 where username='"+textBox1.Text+"'and password='"+textBox2.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count==1)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}
