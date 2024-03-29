﻿using Microsoft.Extensions.Configuration;
using QuanLyBanHangFinal.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangFinal.NhanVien
{
    public partial class ResetForm : Form
    {
        MATHANG mathang = new MATHANG();

        public string getConnect()
        {
            string connectionString;

            var conf = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())

              //             need full path
              .AddJsonFile("appsettings.json", true, true)

              .Build();
            connectionString = conf.GetConnectionString("DbConnection");


            return connectionString;

        }
        public ResetForm()
        {
            InitializeComponent();
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            string connectionString = getConnect();
            SqlConnection connection = new SqlConnection(connectionString);
            if (textBoxCustom1.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã xác nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand("SELECT * FROM QUANLY WHERE password = @Pass", connection);
                command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBoxCustom1.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn có chắc chắn muốn xóa toàn bộ hàng hóa không ?", "Hệ Thống", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        MessageBox.Show("Xóa thành công", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        SqlCommand command2 = new SqlCommand("DELETE FROM HANGHOA");
                        DataTable table2 = mathang.layHangHoa(command2);
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
