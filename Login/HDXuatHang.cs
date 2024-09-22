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
    public partial class HDXuatHang : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        string MHD;
        public HDXuatHang(string mahd)
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=.\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
            MHD = mahd; 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into HDXuatHang values (@MaHD,@MaNV,@MaKH)", conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaNV", cmbMaHang.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaKH", nudSoLuong.Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else MessageBox.Show("Thêm thất bại");
                txtMaHD_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaHD.Text = MHD;
                cmd = new SqlCommand("select * from HDXuatHang where MaHDXuat='" + txtMaHD.Text + "'", conn);
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvShow.CurrentRow.Index;
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cmd = new SqlCommand("delete from HDXuatHang where MaHDXuat=@MaKH", conn);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaHD.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else MessageBox.Show("Xóa thất bại");
                }
                txtMaHD_TextChanged(sender, e);
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

        private void HDXuatHang_Load(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            txtMaHD.Text = MHD;
            ShowMaHangXuat();
        }
        private void ShowMaHangXuat()
        {
            cmd = new SqlCommand("select MaHang from HangHoa", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaHang.DataSource = dt;
            cmbMaHang.DisplayMember = "MaHang";
            cmbMaHang.ValueMember = "MaHang";
        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvShow.CurrentRow.Index;
                if (dongchon >= 0)
                {
                    cmbMaHang.SelectedValue = dgvShow.Rows[dongchon].Cells["MaHang"].Value;
                    nudSoLuong.Value = decimal.Parse(dgvShow.Rows[dongchon].Cells["SoLuongBan"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update HDXuatHang set MaHang=@Manv, SoLuongBan=@Mancc where MaHDXuat=@Mahdnhap", conn);
                cmd.Parameters.AddWithValue("@Manv", cmbMaHang.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Mancc", nudSoLuong.Value.ToString());
                cmd.Parameters.AddWithValue("@Mahdnhap", dgvShow.Rows[dongchon].Cells["MaHDXuat"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else MessageBox.Show("Sửa thất bại");
                txtMaHD_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
