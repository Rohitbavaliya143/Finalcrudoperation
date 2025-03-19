# Finalcrudoperation
crude_c#
//Form2.cs//
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
    public partial class Form2: Form
    {
        int tr, rp = 0,id;
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection sc = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\hello.mdf;Integrated Security=True");
        private void stdinsert_Click(object sender, EventArgs e)
        {
            if(stdinsert.Text=="&insert")
            {
                if(stdname.Text!=""&&stdmobile.Text!="")
                {
                    string sql="insert into login3 values('"+stdname.Text+"','"+stdmobile.Text+"')";
                    SqlDataAdapter da = new SqlDataAdapter(sql, sc);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    stdname.Text = stdmobile.Text = string.Empty;
                    loaddata();
                }
                else
                {
                    MessageBox.Show("data not inserted");
                }
            }
            else
            {
                stdname.Text = stdmobile.Text = string.Empty;
                stdname.Focus();
                stdinsert.Text = "&insert";
                stdupdate.Enabled = false;
                stdupdate.Enabled = false;
            }
        }

        private void stdfirst_Click(object sender, EventArgs e)
        {
            rp = 0;
            Navigate();
            stdupdate.Enabled = true;
            stdupdate.Enabled = true;
            stdinsert.Text = "&insert";
            loaddata();

        }

        private void loaddata()
        {
            string sql = "select * from login3";
            SqlDataAdapter da = new SqlDataAdapter(sql,sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            tr = dt.Rows.Count - 1;
        }

        private void stdprev_Click(object sender, EventArgs e)
        {
            if(rp>0)
            {
                rp--;
                Navigate();
                stdupdate.Enabled = true;
                stdupdate.Enabled = true;
                
            }
        }

        private void stdlast_Click(object sender, EventArgs e)
        {
            rp = tr;
            Navigate();
            stdupdate.Enabled = true;
            stdupdate.Enabled = true;
            
        }

        private void stdupdate_Click(object sender, EventArgs e)
        {
            
                
                string Sql = "update login3 set studentname='" + stdname.Text + "',mobilenumber='" + stdmobile.Text + "'where id='"+id+"'";
                SqlDataAdapter da = new SqlDataAdapter(Sql, sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                loaddata();
                stdname.Text = stdmobile.Text = string.Empty;
                stdupdate.Enabled = false;
                stdupdate.Enabled = false;
         
        }

        private void stddelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from login3 where id='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, sc);
            DataTable dt = new DataTable();
            da.Fill(dt);
            loaddata();
            stdname.Text = stdmobile.Text = string.Empty;
            stdname.Focus();
            stdupdate.Enabled = false;
            stdupdate.Enabled = false;
        }

        private void stdnext_Click(object sender, EventArgs e)
        {
            if(rp<tr)
            {
                rp++;
                Navigate();
                stdupdate.Enabled = true;
                stddelete.Enabled = true;
                stdinsert.Text = "&insert";
            }
        }

        private void Navigate()
        {
            if(tr>0)
            {
                string sql = "select * from login3";
                SqlDataAdapter da = new SqlDataAdapter(sql, sc);
                DataTable dt = new DataTable();
                da.Fill(dt);
                stdname.Text = dt.Rows[rp][1].ToString();
                stdmobile.Text = dt.Rows[rp][2].ToString();
                id = Convert.ToInt32(dt.Rows[rp][0]);
            }
        }
    }
}
