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
    public partial class HDNhapHang : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        string MHD;
        public HDNhapHang(string mahd)
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
            MHD = mahd;
        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvShow.CurrentRow.Index;
                if (dongchon >= 0)
                {
                    cmbMaHang.SelectedValue = dgvShow.Rows[dongchon].Cells["MaHang"].Value;
                    nudSoLuong.Value =decimal.Parse( dgvShow.Rows[dongchon].Cells["SoLuongNhap"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowMaHangNhap()
        {
            cmd = new SqlCommand("select MaHang from HangHoa", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaHang.DataSource = dt;
            cmbMaHang.DisplayMember = "MaHang";
            cmbMaHang.ValueMember = "MaHang";
        }

        private void HDNhapHang_Load(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            txtMaHD.Text = MHD;
            ShowMaHangNhap();
            cmbMaHD_SelectedIndexChanged(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into HDNhapHang values (@MaHD,@MaNV,@MaNCC)", conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaNV", cmbMaHang.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaNCC", nudSoLuong.Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else MessageBox.Show("Thêm thất bại");
                cmbMaHD_SelectedIndexChanged(sender, e);
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
                    cmd = new SqlCommand("delete from HDNhapHang where MaHDNhap=@MaKH", conn);
                    cmd.Parameters.AddWithValue("@MaKH", txtMaHD.Text);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else MessageBox.Show("Xóa thất bại");
                }
                cmbMaHD_SelectedIndexChanged(sender, e);
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

        private void cmbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaHD.Text = MHD;
                cmd = new SqlCommand("select * from HDNhapHang where MaHDNhap='" + txtMaHD.Text + "'", conn);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update HDNhapHang set MaHang=@Manv, SoLuongNhap=@Mancc where MaHDNhap=@Mahdnhap", conn);
                cmd.Parameters.AddWithValue("@Manv", cmbMaHang.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Mancc", nudSoLuong.Value.ToString());
                cmd.Parameters.AddWithValue("@Mahdnhap", dgvShow.Rows[dongchon].Cells["MaHDNhap"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else MessageBox.Show("Sửa thất bại");
                cmbMaHD_SelectedIndexChanged(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }
    }
}
