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
    public partial class AddUser : Form
    {
        SqlConnection conn;
        public AddUser()
        {
            InitializeComponent();
            cmbChucVu.SelectedIndex = 0;
            conn=new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void reset()
        {
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            cmbChucVu.SelectedIndex = 0;
            txtSDT.ResetText();
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into NhanVien(MaNV,TenNV,ChucVu,SDT) values (@MaNV,@TenNV,@ChucVu,@SDT)", conn);
                cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("@ChucVu", cmbChucVu.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else MessageBox.Show("Thêm thất bại");
                themtk();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void themtk()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into account values(@Name,@Pass,@ID)", conn);
                cmd.Parameters.AddWithValue("@Name", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@Pass", "12345");
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
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                else MessageBox.Show("Thêm thất bại");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if(conn.State!= ConnectionState.Open) {
                conn.Open();
            }
        }
    }
}
