using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangNhap
{
    public partial class Form1 : Form
    {
        DanhSachTaiKhoan danhSachTaiKhoan = new DanhSachTaiKhoan();

        public Form1()
        {
            InitializeComponent();
        }

        bool KiemTraDangNhap(string tenTaiKhoan, string matKhau)
        {
            foreach (var taiKhoan in danhSachTaiKhoan.ListTaiKhoan)
            {
                if (tenTaiKhoan == taiKhoan.TenTaiKhoan && matKhau == taiKhoan.MatKhau)
                {
                    Const.TaiKhoan = taiKhoan;
                    return true;
                }
            }
            return false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = textBox1.Text;
            string matKhau = textBox2.Text;

            if (KiemTraDangNhap(tenTaiKhoan, matKhau))
            {
                // Nếu đăng nhập thành công, chuyển sang form Menu
                this.Hide(); // Ẩn form đăng nhập
                Menu menuForm = new Menu();
                menuForm.FormClosed += (s, args) => this.Show(); // Hiển thị lại form đăng nhập khi Menu đóng
                menuForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }

}
