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
    public partial class ManageMed : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        public ManageMed()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void ManageMed_Load(object sender, EventArgs e)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            ShowcmbMedCat();
            ShowcmbMedUsing();
            ShowcmbEditCat();
            ShowcmbEditUsing();
            txtSearchEdit_TextChanged(sender,e);
            txtSearchDel_TextChanged(sender,e);
        }
        private void ShowcmbMedCat()
        {
            cmd = new SqlCommand("select LoaiHang from HangHoa group by LoaiHang", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMedCat.DataSource = dt;
            cmbMedCat.DisplayMember = "LoaiHang";
            cmbMedCat.ValueMember = "LoaiHang";
        }
        private void ShowcmbMedUsing()
        {
            cmd = new SqlCommand("select CachDung from HangHoa group by CachDung", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMedUsing.DataSource = dt;
            cmbMedUsing.DisplayMember = "CachDung";
            cmbMedUsing.ValueMember = "CachDung";
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void resettext()
        {
            txtMedID.ResetText();
            txtMedName.ResetText();
            cmbMedCat.SelectedIndex = 0;
            cmbMedUsing.SelectedIndex = 0;
            txtPurPrice.ResetText();
            txtSalePrice.ResetText();
            nudQuantity.ResetText();
        }
        private void btnAddMed_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into HangHoa values (@MaNV,@TenNV,@LoaiThuoc,@CachDung,@ChucVu,@SDT,@SoLuong)", conn);
                cmd.Parameters.AddWithValue("@MaNV", txtMedID.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtMedName.Text);
                cmd.Parameters.AddWithValue("@LoaiThuoc", cmbMedCat.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@CachDung", cmbMedUsing.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@ChucVu", txtPurPrice.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSalePrice.Text);
                cmd.Parameters.AddWithValue("@SoLuong", nudQuantity.Value);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    resettext();
                }
                else MessageBox.Show("Thêm thất bại");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchEdit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from HangHoa where MaHang like '%" + txtSearchEdit.Text + "%' or TenHang like '%" + txtSearchEdit.Text + "%'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSearchEdit.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSearchEdit_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvSearchEdit.CurrentRow.Index;
                if (dongchon >= 0)
                {
                    txtEditID.Text = dgvSearchEdit.Rows[dongchon].Cells["MaHang"].Value.ToString();
                    txtEditName.Text = dgvSearchEdit.Rows[dongchon].Cells["TenHang"].Value.ToString();
                    cmbEditCat.SelectedValue = dgvSearchEdit.Rows[dongchon].Cells["LoaiHang"].Value;
                    cmbEditUsing.SelectedValue = dgvSearchEdit.Rows[dongchon].Cells["CachDung"].Value;
                    txtEditPur.Text = dgvSearchEdit.Rows[dongchon].Cells["DonGiaNhap"].Value.ToString();
                    txtEditSale.Text = dgvSearchEdit.Rows[dongchon].Cells["DonGiaBan"].Value.ToString();
                    nudEditQuan.Value = decimal.Parse(dgvSearchEdit.Rows[dongchon].Cells["SoLuong"].Value.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowcmbEditCat()
        {
            cmd = new SqlCommand("select LoaiHang from HangHoa group by LoaiHang", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbEditCat.DataSource = dt;
            cmbEditCat.DisplayMember = "LoaiHang";
            cmbEditCat.ValueMember = "LoaiHang";
        }
        private void ShowcmbEditUsing()
        {
            cmd = new SqlCommand("select CachDung from HangHoa group by CachDung", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbEditUsing.DataSource = dt;
            cmbEditUsing.DisplayMember = "CachDung";
            cmbEditUsing.ValueMember = "CachDung";
        }

        private void btnEditOK_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvSearchEdit.CurrentRow.Index;
                cmd = new SqlCommand("update HangHoa set MaHang=@MaHang, TenHang=@TenHang, LoaiHang=@LoaiHang, CachDung=@CachDung, DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaXuat,SoLuong=@SoLuong where MaHang=@MaHangcu", conn);
                cmd.Parameters.AddWithValue("@MaHang", txtEditID.Text);
                cmd.Parameters.AddWithValue("@TenHang", txtEditName.Text);
                cmd.Parameters.AddWithValue("@LoaiHang", cmbEditCat.SelectedValue);
                cmd.Parameters.AddWithValue("@CachDung", cmbEditUsing.SelectedValue);
                cmd.Parameters.AddWithValue("@DonGiaNhap", txtEditPur.Text);
                cmd.Parameters.AddWithValue("@DonGiaXuat", txtEditSale.Text);
                cmd.Parameters.AddWithValue("@SoLuong", nudEditQuan.Value);
                cmd.Parameters.AddWithValue("@MaHangcu", dgvSearchEdit.Rows[dongchon].Cells["MaHang"].Value.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thay đổi thành công");
                }
                else
                {
                    MessageBox.Show("Thay đổi thất bại");
                }
                txtSearchEdit_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchDel_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from HangHoa where MaHang like '%" + txtSearchEdit.Text + "%' or TenHang like '%" + txtSearchEdit.Text + "%'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDel.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelOK_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvDel.CurrentRow.Index;
                if (MessageBox.Show("Bạn có muốn xóa thuốc?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    cmd = new SqlCommand("delete from HangHoa where MaHang=@MaKH", conn);
                    cmd.Parameters.AddWithValue("@MaKH", dgvDel.Rows[dongchon].Cells["MaHang"].Value.ToString());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else MessageBox.Show("Xóa thất bại");
                }
                txtSearchDel.ResetText();
                txtSearchDel_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
