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
    public partial class DeleteUser : Form
    {
        SqlConnection conn;
        public DeleteUser()
        {
            InitializeComponent();
            conn= new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select* from NhanVien where TenNV like '%" + txtSearch.Text + "%' or MaNV like '%" + txtSearch.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvShow.DataSource = dt;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    if (MessageBox.Show("Bạn có muốn xóa người dùng này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        xoataikhoan();
                        int dongchon = dgvShow.CurrentRow.Index;
                        SqlCommand cmd = new SqlCommand("delete from NhanVien where MaNV=@MaNV", conn);
                        cmd.Parameters.AddWithValue("@MaNV", dgvShow.Rows[dongchon].Cells["MaNV"].Value.ToString());
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Xóa thành công", "Thông báo");
                        }
                        else                
                        {
                            MessageBox.Show("Xóa thất bại");
                        }
                        txtSearch_TextChanged(sender, e);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void xoataikhoan()
        {
            try
            {
                int dongchon=dgvShow.CurrentRow.Index;
                SqlCommand cmd = new SqlCommand("delete from account where Name=@MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", dgvShow.Rows[dongchon].Cells["MaNV"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã xóa tài khoản");
                }
                else
                {
                    MessageBox.Show("Lỗi");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            txtSearch.ResetText();
            txtSearch_TextChanged(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
