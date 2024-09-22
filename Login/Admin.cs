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

namespace Login
{
    public partial class Admin : Form
    {
        SqlConnection conn;
        BindingSource bs=new BindingSource();
        public Admin(string name,string pass)
        {
            InitializeComponent();
            txtUserName.Text = name;
            txtPass.Text = pass;
            conn=new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }
        private void hienthi()
        {
            SqlCommand cmd = new SqlCommand("select *from NhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bs.DataSource = dt;
            dgvView.DataSource = bs;
        }

        private void thêmNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser au = new AddUser();
            au.ShowDialog();
            dgvView.Hide();
            this.Show();
        }


        private void xóaNgườiDùngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteUser du= new DeleteUser();
            du.ShowDialog();
            dgvView.Hide();
            this.Show();
        }

        private void sửaNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUser cu= new EditUser();
            cu.ShowDialog();
            dgvView.Hide();
            this.Show();
        }

        private void thêmThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer ac = new AddCustomer();
            ac.ShowDialog();
            dgvShowCus.Hide();
            this.Show();
        }

        private void sửaThôngTinThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomer cc= new EditCustomer();
            cc.ShowDialog();
            dgvShowCus.Hide();
            this.Show();
        }

        private void xóaThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomer dc = new DeleteCustomer();
            dc.ShowDialog();
            dgvShowCus.Hide();
            this.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            dgvView.Hide();
            dgvShowCus.Hide();
            dgvShowSup.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
        }

        private void xemDanhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            dgvView.Show();
            hienthi();
        }

        private void xemDanhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            dgvShowCus.Show();
            SqlCommand cmd = new SqlCommand("select *from KhachHang", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bs.DataSource = dt;
            dgvShowCus.DataSource = bs;
        }

        private void thêmNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSup addsup = new AddSup();
            addsup.ShowDialog();
            dgvShowSup.Hide();
            this.Show();
        }

        private void sửaThôngTinNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSup es=new EditSup();
            es.ShowDialog();
            dgvShowSup.Hide();
            this.Show();
        }

        private void xóaNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSup deleteSup= new DeleteSup();
            deleteSup.ShowDialog();
            dgvShowSup.Hide();
            this.Show();
        }

        private void xemDanhSáchNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            dgvShowSup.Show();
            SqlCommand cmd = new SqlCommand("select *from NCC", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bs.DataSource = dt;
            dgvShowSup.DataSource = bs;
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void ckbChangePass_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbChangePass.Checked)
            {
                groupBox2.Show();
            }
            else groupBox2.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPass.Text != "")
                {
                    if (txtNewPass2.Text != "")
                    {
                        if(txtNewPass.Text==txtNewPass2.Text)
                        {
                            SqlCommand cmd = new SqlCommand("update account set Pass=@Pass where Name=@Name", conn);
                            cmd.Parameters.AddWithValue("@Pass",txtNewPass.Text);
                            cmd.Parameters.AddWithValue("@Name",txtUserName.Text);
                            if(cmd.ExecuteNonQuery()>0) {
                                MessageBox.Show("Đổi mật khẩu thành công");
                            }
                            else
                            {
                                MessageBox.Show("Chưa đổi được mật khẩu");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhập lại mật khẩu mới chưa đúng");
                            txtNewPass2.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mời nhập lại mật khẩu mới");
                        txtNewPass2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mời nhập mật khẩu mới");
                    txtNewPass.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
