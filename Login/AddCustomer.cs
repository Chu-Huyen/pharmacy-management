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
    public partial class AddCustomer : Form
    {
        SqlConnection conn;
        public AddCustomer()
        {
            InitializeComponent();
            conn=new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into KhachHang values(@MaKH,@TenKH,@DiaChi,@SDT)",conn);
                cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                if(cmd.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
    }
}
