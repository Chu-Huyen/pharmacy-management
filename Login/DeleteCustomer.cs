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
    public partial class DeleteCustomer : Form
    {
        SqlConnection conn;
        int dongchon;
        SqlCommand cmd;
        public DeleteCustomer()
        {
            InitializeComponent();
            conn= new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select * from KhachHang where MaKH like '%"+txtSearch.Text+"%' or TenKH like '%"+txtSearch.Text+"%'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvShow.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteCustomer_Load(object sender, EventArgs e)
        {
            if(conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            txtSearch_TextChanged(sender, e);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                dongchon = dgvShow.CurrentRow.Index;
                if(MessageBox.Show("Bạn có muốn xóa khách hàng?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    cmd = new SqlCommand("delete from KhachHang where MaKH=@MaKH", conn);
                    cmd.Parameters.AddWithValue("@MaKH", dgvShow.Rows[dongchon].Cells["MaKH"].Value.ToString());
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                    }
                    else MessageBox.Show("Xóa thất bại");
                }
                txtSearch.ResetText();
                txtSearch_TextChanged(sender, e);
            }
            catch(Exception ex )
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
