﻿using QuanLyBanHangFinal.Model;
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

namespace QuanLyBanHangFinal.Admin
{
    public partial class QuanLyForm : Form
    {
        DOANHTHU dt = new DOANHTHU();
        NHANVIEN nv = new NHANVIEN();
        public QuanLyForm()
        {
            InitializeComponent();
        }

        private void ButtonThemNV_Click(object sender, EventArgs e)
        {
            ThemNVForm themnv = new ThemNVForm();
            themnv.ShowDialog();
        }

        private void buttonXoaNV_Click(object sender, EventArgs e)
        {
            XoaNVForm xoanv = new XoaNVForm();
            xoanv.ShowDialog();
        }

        private void buttonQuanLyNV_Click(object sender, EventArgs e)
        {
            QLNVForm qlnv = new QLNVForm();
            qlnv.ShowDialog();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            KhoHangForm kh = new KhoHangForm();
            kh.ShowDialog();
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void customButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void customButton4_Click(object sender, EventArgs e)
        {
            /*ThongKeDoanhThuForm tkdt = new ThongKeDoanhThuForm();
            tkdt.ShowDialog();*/
        }

        private void buttonChamCong_Click(object sender, EventArgs e)
        {
            ChamCongAD chamcong = new ChamCongAD();
            chamcong.ShowDialog();
        }

        private void QuanLyForm_Load(object sender, EventArgs e)
        {
            string ngay = dateTimePicker1.Value.ToString();
            SqlCommand command = new SqlCommand("SELECT * FROM DOANHTHU WHERE ngay=@ngay");
            command.Parameters.Add("@ngay", SqlDbType.VarChar).Value = ngay;
           
            dataGridViewDoanhThu.DataSource = dt.layDoanhThu(command);


        }
        void StyleDatagridview()
        {
            DateTime ngay = DateTime.Now;
            SqlCommand command = new SqlCommand("SELECT tien as 'Tiền',ngay as 'Ngày' FROM DOANHTHU WHERE ngay=@ngay");
            command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngay;
            dataGridViewDoanhThu.DataSource = nv.layNV(command);
            dataGridViewDoanhThu.ReadOnly = true;
            dataGridViewDoanhThu.RowTemplate.Height = 60;
            dataGridViewDoanhThu.BorderStyle = BorderStyle.None;
            dataGridViewDoanhThu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridViewDoanhThu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewDoanhThu.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dataGridViewDoanhThu.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewDoanhThu.BackgroundColor = Color.FromArgb(148, 184, 184);
            dataGridViewDoanhThu.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewDoanhThu.EnableHeadersVisualStyles = false;
            dataGridViewDoanhThu.AllowUserToAddRows = false;
            dataGridViewDoanhThu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewDoanhThu.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12);

            //dòng tiêu đề của bảng
            dataGridViewDoanhThu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(58, 95, 95);
            dataGridViewDoanhThu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //căn giữa 
            dataGridViewDoanhThu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }

        private void btnOUT_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 lo = new Form1();
            lo.ShowDialog();
        }

        private void dataGridViewDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            string ngay = dateTimePicker1.Value.ToString();
            SqlCommand command = new SqlCommand("SELECT * FROM DOANHTHU WHERE ngay=@ngay");
            command.Parameters.Add("@ngay", SqlDbType.VarChar).Value = ngay;
            dataGridViewDoanhThu.DataSource = dt.layDoanhThu(command);
        }
    }
}
