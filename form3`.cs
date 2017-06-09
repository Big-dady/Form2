//filling grid using dataset;
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
           // string s = textBox1.Text;
            string q = "Select * from Table1 where name= '" + textBox1.Text + "'";

           DataSet ds = data.getDataSet(q);
           if (ds.Tables[0].Rows.Count > 0)
           {
               dgv.Rows.Clear();
               int currow = 0;
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   dgv.Rows.Add();
                   currow = dgv.Rows.Count - 1;
                   dgv.Rows[currow].Cells["SNo"].Value = currow + 1;
                   dgv.Rows[currow].Cells["Name"].Value = dr["name"].ToString(); ;
                //   dgv.Rows[currow].Cells["InvNo"].Value = dr["InvNo"].ToString();
               }
           }
        }
    }
}
