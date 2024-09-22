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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Login
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        string name = " ";
        public Form1()
        {
            InitializeComponent();
            conn= new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");

        }

        private void ckbShowpass_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbShowpass.Checked)
            {
                txtPass.PasswordChar=(char)0;
            }
            else
            {
                txtPass.PasswordChar='*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            txtPass.PasswordChar='*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_AuthoLogin";
                cmd.Parameters.AddWithValue("@name", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cmd.Connection = conn;
                name = txtUsername.Text;
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                switch(code)
                {
                    case 0:
                        {
                            MessageBox.Show("Bạn đã đăng nhập bằng tài khoản Admin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Admin a = new Admin(txtUsername.Text, txtPass.Text);
                            this.Hide();
                            a.ShowDialog();
                            this.Show();
                            break;
                        }
                    case 1:
                        {
                            MessageBox.Show("Bạn đã đăng nhập bằng tài khoản User", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            User u = new User(txtUsername.Text, txtPass.Text);
                            this.Hide();
                            u.ShowDialog();
                            this.Show();
                            break;
                        }
                    case 2:
                        {
                            MessageBox.Show("Nhập sai tên hoặc mật khẩu !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Focus();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Focus();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
