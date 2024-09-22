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
    public partial class ManageReceipt : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        public ManageReceipt()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void ManageReceipt_Load(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            txtTim_TextChanged(sender, e);
            ShowMaNV();
            ShowMaNCC();
        }
        private void thanhtien()
        {
            cmd = new SqlCommand("select SoLuongNhap*DonGiaNhap as thanhtien from HDNhapHang,HangHoa where HDNhapHang.MaHang=HangHoa.MaHang and MaHDNhap='"+txtMaHD.Text+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds=new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.Tables.Add(dt);
            textBox1.Text = ds.Tables[0].Rows[0]["thanhtien"].ToString();
            //int thanhtien=(int) cmd.ExecuteScalar();
            //textBox1.Text=thanhtien.ToString();
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from HoaDonNhap where MaHDNhap like '%" + txtTim.Text + "%'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHienthi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowMaNV()
        {
            cmd = new SqlCommand("select MaNV,TenNV from NhanVien", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaNV.DataSource = dt;
            cmbMaNV.DisplayMember = "TenNV";
            cmbMaNV.ValueMember = "MaNV";
        }
        private void ShowMaNCC()
        {
            cmd = new SqlCommand("select MaNCC,TenNCC from NCC", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaNCC.DataSource = dt;
            cmbMaNCC.DisplayMember = "TenNCC";
            cmbMaNCC.ValueMember = "MaNCC";
        }
        private void dgvHienthi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvHienthi.CurrentRow.Index;
                if (dongchon >= 0)
                {
                    txtMaHD.Text = dgvHienthi.Rows[dongchon].Cells["MaHDNhap"].Value.ToString();
                    cmbMaNV.SelectedValue = dgvHienthi.Rows[dongchon].Cells["MaNV"].Value;
                    cmbMaNCC.SelectedValue = dgvHienthi.Rows[dongchon].Cells["MaNCC"].Value;
                    dtpNgay.Value = (DateTime)dgvHienthi.Rows[dongchon].Cells["Ngay"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void resettext()
        {
            txtMaHD.ResetText();
            cmbMaNV.SelectedIndex = 0;
            cmbMaNCC.SelectedIndex = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into HoaDonNhap values (@MaHD,@MaNV,@MaNCC,@Ngay)", conn);
                cmd.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@MaNV", cmbMaNV.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MaNCC", cmbMaNCC.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@Ngay",dtpNgay.Value);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    resettext();
                }
                else MessageBox.Show("Thêm thất bại");
                txtTim_TextChanged(sender, e);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvHienthi.CurrentRow.Index;
                cmd = new SqlCommand("update HoaDonNhap set MaHDNhap=@MaHang, MaNV=@TenHang, MaNCC=@LoaiHang, Ngay=@CachDung where MaHDNhap=@MaHangcu", conn);
                cmd.Parameters.AddWithValue("@MaHang", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@TenHang",cmbMaNV.SelectedValue);
                cmd.Parameters.AddWithValue("@LoaiHang", cmbMaNCC.SelectedValue);
                cmd.Parameters.AddWithValue("@CachDung", dtpNgay.Value);
                cmd.Parameters.AddWithValue("@MaHangcu", dgvHienthi.Rows[dongchon].Cells["MaHDNhap"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thay đổi thành công");
                }
                else
                {
                    MessageBox.Show("Thay đổi thất bại");
                }
                txtTim_TextChanged(sender, e);
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
                HDNhapHang hd = new HDNhapHang(txtMaHD.Text);
                hd.ShowDialog();
                this.Show();
                dongchon = dgvHienthi.CurrentRow.Index;
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cmd = new SqlCommand("delete from HoaDonNhap where MaHDNhap=@MaKH", conn);
                    cmd.Parameters.AddWithValue("@MaKH", dgvHienthi.Rows[dongchon].Cells["MaHDNhap"].Value.ToString());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else MessageBox.Show("Xóa thất bại");
                }
                txtTim.ResetText();
                txtTim_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HDNhapHang hd = new HDNhapHang(txtMaHD.Text);
            hd.ShowDialog();
            this.Show();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HDNhapHang hd=new HDNhapHang(txtMaHD.Text);
            hd.ShowDialog();
            this.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            thanhtien();
        }
    }
}
