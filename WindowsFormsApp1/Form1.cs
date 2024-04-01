using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string strConn = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=TEST2;Integrated Security=True";
        SqlConnection sqlConn = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlConn == null)
                {
                    sqlConn = new SqlConnection(strConn);
                }

                if(sqlConn.State == ConnectionState.Closed)
                {

                    sqlConn.Open();
                }

                string maNV = txtMaNV.Text;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * From NHANVIEN Where MANV= '"+ maNV + "'";
                    
                sqlCmd.Connection = sqlConn;

                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    string tenNV = reader.GetString(1);

                    txtTenNV.Text = tenNV;
                }
                reader.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

   


    }



