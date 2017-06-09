//searching
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Vinayak.DATA
{
    public partial class Form3 : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            string q = "Select * from Table1 where name= '"+ s+"'";
            using (SqlConnection con = new SqlConnection(data.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
        }
    }
}
