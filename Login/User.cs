using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class User : Form
    {
        SqlConnection conn;
        public User(string name,string pass)
        {
            InitializeComponent();
            txtUserName.Text = name;
            txtPass.Text = pass;
            conn = new SqlConnection(@"Data Source=CHUTNGOCHANH\CTTH;Initial Catalog=QuanLyNhaThuoc;Integrated Security=True");
        }

        private void quảnLýThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageMed manageMed = new ManageMed();
            showMed();
            manageMed.ShowDialog();
            this.Show();
        }

        private void quảnLýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageReceipt manageReceipt = new ManageReceipt();
            showRec();
            manageReceipt.ShowDialog();
            this.Show();
        }

        private void quảnLýHóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageBill manageBill = new ManageBill();
            showBill();
            manageBill.ShowDialog();
            this.Show();
        }

        private void User_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            dgvShowRec.Hide();
            dgvShowBill.Hide();
            dgvShowMed.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
        }
        private void showMed()
        {
            dgvShowRec.Hide();
            dgvShowBill.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            dgvShowMed.Show();
            SqlCommand cmd = new SqlCommand("select* from HangHoa", conn);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dgvShowMed.DataSource= dt;
        }
        private void showRec()
        {
            dgvShowBill.Hide();
            dgvShowMed.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            dgvShowRec.Show();
            SqlCommand cmd = new SqlCommand("select* from HoaDonNhap", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvShowRec.DataSource = dt;
        }
        private void showBill()
        {
            dgvShowRec.Hide();
            dgvShowMed.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            dgvShowBill.Show();
            SqlCommand cmd = new SqlCommand("select* from HoaDonXuat", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvShowBill.DataSource = dt;
        }
        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void ckbChangePass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbChangePass.Checked)
            {
                groupBox2.Show();
            }
            else groupBox2.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPass.Text != "")
                {
                    if (txtNewPass2.Text != "")
                    {
                        if (txtNewPass.Text == txtNewPass2.Text)
                        {
                            SqlCommand cmd = new SqlCommand("update account set Pass=@Pass where Name=@Name", conn);
                            cmd.Parameters.AddWithValue("@Pass", txtNewPass.Text);
                            cmd.Parameters.AddWithValue("@Name", txtUserName.Text);
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công");
                            }
                            else
                            {
                                MessageBox.Show("Chưa đổi được mật khẩu");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhập lại mật khẩu mới chưa đúng");
                            txtNewPass2.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mời nhập lại mật khẩu mới");
                        txtNewPass2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mời nhập mật khẩu mới");
                    txtNewPass.Focus();
                }
            }
            catch (Exception ex)
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
