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
using Excel = Microsoft;
using System.Data.OleDb;
using KeepAutomation.Barcode.Bean;
//using Excel = Microsoft.Office.Interop.Excel;

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
            string q = "Select * from Table1";
              if (textBox1.Text == "")
            {
                q += "";
            }
            else
            {
                q += " where name='" + textBox1.Text + "'";
            }
            
            DataSet ds = data.getDataSet(q);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //PictureBox pictureBox1= new PictureBox();
                pictureBox1.ImageLocation = "E://DD-UserData/Desktop/New folder/Vinayak/barcode/" + ds.Tables[0].Rows[0]["barcode"].ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

                dgv.Rows.Clear();
                int currow = 0;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgv.Rows.Add();
                    currow = dgv.Rows.Count - 1;
                    dgv.Rows[currow].Cells["SNo"].Value = currow + 1;
                    dgv.Rows[currow].Cells["nme"].Value = dr["name"].ToString();
                    dgv.Rows[currow].Cells["Fname"].Value = dr["fname"].ToString();
                    dgv.Rows[currow].Cells["dob"].Value = dr["dob"].ToString();
                    dgv.Rows[currow].Cells["Sex"].Value = dr["Sex"].ToString();
                    dgv.Rows[currow].Cells["address"].Value = dr["address"].ToString();
                        dgv.Rows[currow].Cells["number"].Value = dr["number"].ToString();
                    dgv.Rows[currow].Cells["hobby"].Value = dr["hobby"].ToString();
                    //   dgv.Rows[currow].Cells["InvNo"].Value = dr["InvNo"].ToString();
                }
            }
            //else
            //{
            //    DataSet d = data.getDataSet(q);
            //    if (d.Tables[0].Rows.Count > 0)
            //    {
            //        dgv.Rows.Clear();
            //        int currow = 0;
            //        foreach (DataRow dr in d.Tables[0].Rows)
            //        {
            //            dgv.Rows.Add();
            //            currow = dgv.Rows.Count - 1;
            //            dgv.Rows[currow].Cells["SNo"].Value = currow + 1;
            //            dgv.Rows[currow].Cells["nme"].Value = dr["name"].ToString();
            //            dgv.Rows[currow].Cells["Fname"].Value = dr["fname"].ToString();
            //            dgv.Rows[currow].Cells["dob"].Value = dr["dob"].ToString();
            //            dgv.Rows[currow].Cells["Sex"].Value = dr["Sex"].ToString();
            //            dgv.Rows[currow].Cells["address"].Value = dr["address"].ToString();
            //            dgv.Rows[currow].Cells["number"].Value = dr["number"].ToString();
            //            dgv.Rows[currow].Cells["hobby"].Value = dr["hobby"].ToString();
            //            //   dgv.Rows[currow].Cells["InvNo"].Value = dr["InvNo"].ToString();
            //        }
            //    }
            //}
        }

        
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        
 //       private void button2_Click_1(object sender, EventArgs e)
 //       {
 //BarCode bar = new BarCode();
 //           bar.Symbology = KeepAutomation.Barcode.Symbology.Code39;
 //           bar.CodeToEncode = "11212";
 //           bar.ChecksumEnabled = true;
 //           bar.X = 1;
 //           bar.Y = 50;
 //           bar.BarCodeWidth = 100;
 //           bar.BarCodeHeight = 70;
 //           bar.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
 //           bar.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
 //           bar.DPI = 72;
 //           bar.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
 //           bar.generateBarcodeToImageFile("E://DD-UserData/Desktop/New folder/Vinayak/barcode/img.png");
 //       }


    }
}
