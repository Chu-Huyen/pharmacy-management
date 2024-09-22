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
    public partial class EditUser : Form
    {
        SqlConnection conn;
        public EditUser()
        {
            InitializeComponent();
            conn= new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            int dongchon = dgvShow.CurrentRow.Index;
            try
            {
                if(conn.State!=ConnectionState.Closed)
                {
                    SqlCommand cmd = new SqlCommand("update NhanVien set MaNV=@MaNV, " +
                        "TenNV=@TenNV,ChucVu=@ChucVu," +
                        "SDT=@SDT where MaNV=@MaNVcu", conn);
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@MaNVcu", dgvShow.Rows[dongchon].Cells["MaNV"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@ChucVu", cmbChucVu.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Sửa thành công");
                    }
                    else MessageBox.Show("Sửa thất bại");
                    suataikhoan();
                    textBox1_TextChanged(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void suataikhoan()
        {
            try
            {
                int dongchon= dgvShow.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("update account set Name=@MaNV,ID=@ID where Name=@MaNVcu", conn);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@MaNVcu", dgvShow.Rows[dongchon].Cells["MaNV"].Value.ToString());
                if (cmbChucVu.SelectedItem.ToString() == "Quản lý")
                {
                    cmd.Parameters.AddWithValue("@ID", 1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ID", 2);
                }
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã thay đổi thông tin tài khoản");
                }
                else MessageBox.Show("Thay đổi thông tin thất bại");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int dongchon = dgvShow.CurrentRow.Index;
            if (dongchon >= 0)
            {
                txtMaNV.Text = dgvShow.Rows[dongchon].Cells["MaNV"].Value.ToString();
                txtTenNV.Text = dgvShow.Rows[dongchon].Cells["TenNV"].Value.ToString();
                cmbChucVu.SelectedItem = dgvShow.Rows[dongchon].Cells["ChucVu"].Value;
                txtSDT.Text = dgvShow.Rows[dongchon].Cells["SDT"].Value.ToString();
            }
        }

        private void ChangeUser_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            textBox1_TextChanged(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from NhanVien where TenNV like N'%" + txtSearch.Text + "%' or MaNV like '%" + txtSearch.Text + "%'",conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvShow.DataSource=dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
