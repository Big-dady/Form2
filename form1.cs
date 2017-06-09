//displaying whole table data in a grid
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

namespace Vinayak
{
    public partial class Form1 : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();


        public Form1()
        {
            InitializeComponent();
            bind();
        }

        private void bind()
        {
            using (SqlConnection con = new SqlConnection(data.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Table1", con))
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
