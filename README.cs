//form1
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
    public partial class Form2 : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand c = new SqlCommand();
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Fill all the entries properly");
            }
            else
            {
                if (button1.Text == "Submit")
                {
                    string s = "insert into Table1 (name,fname,dob,Sex,address,number,hobby) values(@name,@fname,@dob,@Sex,@address,@number,@hobby) ";
                    c.CommandText = s;
                    c.Parameters.Clear();
                    c.Parameters.AddWithValue("@name", textBox1.Text);
                    c.Parameters.AddWithValue("@fname", textBox2.Text);
                    c.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                    if (radioButton1.Checked == true)
                        c.Parameters.AddWithValue("@Sex", radioButton1.Text);
                    else
                        c.Parameters.AddWithValue("@Sex", radioButton2.Text);
                    c.Parameters.AddWithValue("@address", textBox3.Text);
                    c.Parameters.AddWithValue("@number", textBox4.Text);
                    if (checkBox1.Checked == true)
                        c.Parameters.AddWithValue("@hobby", checkBox1.Text);
                    if (checkBox2.Checked == true)
                        c.Parameters.AddWithValue("@hobby", checkBox2.Text);
                    if (checkBox3.Checked == true)
                        c.Parameters.AddWithValue("@hobby", checkBox3.Text);
                    data.executeCommand(c);
                    MessageBox.Show("Data Saved");
                    Resett();
                    filllist();
                }
                else
                {
                    string q2 = "update Table1 set name=@name,fname=@fname,dob=@dob,Sex=@Sex,address=@address,number=@number,hobby=@hobby where id=" + listBox1.SelectedValue;
                    c.CommandText = q2;
                    c.Parameters.Clear();
                    c.Parameters.AddWithValue("@name", textBox1.Text);
                    c.Parameters.AddWithValue("@fname", textBox2.Text);
                    c.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                    if (radioButton1.Checked == true)
                        c.Parameters.AddWithValue("@Sex", radioButton1.Text);
                    else
                        c.Parameters.AddWithValue("@Sex", radioButton2.Text);
                    c.Parameters.AddWithValue("@address", textBox3.Text);
                    c.Parameters.AddWithValue("@number", textBox4.Text);
                    if (checkBox1.Checked == true)
                        c.Parameters.AddWithValue("@hobby", checkBox1.Text);
                    //if (checkBox2.Checked == true)
                    //    c.Parameters.AddWithValue("@hobby", checkBox2.Text);
                    //if (checkBox3.Checked == true)
                    //    c.Parameters.AddWithValue("@hobby", checkBox3.Text);
                    data.executeCommand(c);
                    MessageBox.Show("Data Updated");
                    Resett();
                    filllist();
                }
            }
        }

        private void Resett()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            //textBox5.Text=null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            button1.Text = "Submit";
            
        }

        public void filllist()
        {
            listBox1.DataSource = data.getDataSet("select * from Table1 order by Name asc").Tables[0];
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";
            button2.Text = "Delete";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (button2.Text == "Reset")
                Resett();
            else
            {
                
                string q3 = "Delete from Table1 where id=" + listBox1.SelectedValue;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Resett();
            filllist();
        }


        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DataSet ds = data.getDataSet("select * from Table1 where id= " + listBox1.SelectedValue);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        textBox1.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        textBox2.Text = ds.Tables[0].Rows[0]["fname"].ToString();
                        textBox3.Text = ds.Tables[0].Rows[0]["address"].ToString();
                        textBox4.Text = ds.Tables[0].Rows[0]["number"].ToString();
                        dateTimePicker1.Text = ds.Tables[0].Rows[0]["dob"].ToString();
                        if (ds.Tables[0].Rows[0]["Sex"].ToString() == "M")
                            radioButton2.Checked = true;
                        else 
                            radioButton1.Checked = true;
                        if (ds.Tables[0].Rows[0]["hobby"].ToString() == "Football")
                            checkBox1.Checked = true;
                        if (ds.Tables[0].Rows[0]["hobby"].ToString() == "Swiming")
                            checkBox2.Checked = true;
                        if (ds.Tables[0].Rows[0]["hobby"].ToString() == "Running")
                            checkBox3.Checked = true;
                    }
                    button1.Text = "Update";
                }
            }
        }

    }
}

