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
    public partial class EditSup : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        public EditSup()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=CHUTNGOCHANH\\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void EditSup_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            txtSearch_TextChanged(sender, e);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from NCC where MaNCC like '%" + txtSearch.Text + "%' or TenNCC like '%" + txtSearch.Text + "%'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShow.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            dongchon = dgvShow.CurrentRow.Index;
            if (dongchon >= 0)
            {
                txtMaNCC.Text = dgvShow.Rows[dongchon].Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvShow.Rows[dongchon].Cells["TenNCC"].Value.ToString();
                txtDC.Text = dgvShow.Rows[dongchon].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dgvShow.Rows[dongchon].Cells["SDT"].Value.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvShow.CurrentRow.Index;
                cmd = new SqlCommand("update NCC set MaNCC=@MaKH, TenNCC=@TenKH, DiaChi=@DiaChi, SDT=@SDT where MaNCC=@MaKHcu", conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@TenKH", txtTenNCC.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@MaKHcu", dgvShow.Rows[dongchon].Cells["MaNCC"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thay đổi thành công");
                }
                else
                {
                    MessageBox.Show("Thay đổi thất bại");
                }
                txtSearch_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
