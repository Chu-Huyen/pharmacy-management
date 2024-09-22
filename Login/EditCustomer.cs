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
    public partial class EditCustomer : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        public EditCustomer()
        {
            InitializeComponent();
            conn= new SqlConnection("Data Source=CHUTNGOCHANH\\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void ChangeCustomer_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            txtSearch_TextChanged(sender, e);
        }

        private void dgvShow_SelectionChanged(object sender, EventArgs e)
        {
            dongchon = dgvShow.CurrentRow.Index;
            if(dongchon>=0)
            {
                txtMaKH.Text = dgvShow.Rows[dongchon].Cells["MaKH"].Value.ToString();
                txtTenKH.Text = dgvShow.Rows[dongchon].Cells["TenKH"].Value.ToString();
                txtDC.Text = dgvShow.Rows[dongchon].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dgvShow.Rows[dongchon].Cells["SDT"].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from KhachHang where MaKH like '%" + txtSearch.Text + "%' or TenKH like '%" + txtSearch.Text + "%'",conn);
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShow.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvShow.CurrentRow.Index;
                cmd = new SqlCommand("update KhachHang set MaKH=@MaKH, TenKH=@TenKH, DiaChi=@DiaChi, SDT=@SDT where MaKH=@MaKHcu", conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@MaKHcu", dgvShow.Rows[dongchon].Cells["MaKH"].Value.ToString());
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
            catch(Exception ex)
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
