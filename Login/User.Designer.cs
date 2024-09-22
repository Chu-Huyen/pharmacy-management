namespace Login
{
    partial class User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýThuốcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHóaĐơnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvShowMed = new System.Windows.Forms.DataGridView();
            this.dgvShowRec = new System.Windows.Forms.DataGridView();
            this.dgvShowBill = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPass2 = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.ckbChangePass = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBill)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýThuốcToolStripMenuItem,
            this.quảnLýHóaĐơnNhậpToolStripMenuItem,
            this.quảnLýHóaĐơnXuấtToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýThuốcToolStripMenuItem
            // 
            this.quảnLýThuốcToolStripMenuItem.Name = "quảnLýThuốcToolStripMenuItem";
            this.quảnLýThuốcToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.quảnLýThuốcToolStripMenuItem.Text = "Quản lý thuốc";
            this.quảnLýThuốcToolStripMenuItem.Click += new System.EventHandler(this.quảnLýThuốcToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnNhậpToolStripMenuItem
            // 
            this.quảnLýHóaĐơnNhậpToolStripMenuItem.Name = "quảnLýHóaĐơnNhậpToolStripMenuItem";
            this.quảnLýHóaĐơnNhậpToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.quảnLýHóaĐơnNhậpToolStripMenuItem.Text = "Quản lý hóa đơn nhập";
            this.quảnLýHóaĐơnNhậpToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnNhậpToolStripMenuItem_Click);
            // 
            // quảnLýHóaĐơnXuấtToolStripMenuItem
            // 
            this.quảnLýHóaĐơnXuấtToolStripMenuItem.Name = "quảnLýHóaĐơnXuấtToolStripMenuItem";
            this.quảnLýHóaĐơnXuấtToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.quảnLýHóaĐơnXuấtToolStripMenuItem.Text = "Quản lý hóa đơn xuất";
            this.quảnLýHóaĐơnXuấtToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHóaĐơnXuấtToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(102, 30);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            this.tàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.tàiKhoảnToolStripMenuItem_Click);
            // 
            // dgvShowMed
            // 
            this.dgvShowMed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowMed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowMed.Location = new System.Drawing.Point(0, 36);
            this.dgvShowMed.Name = "dgvShowMed";
            this.dgvShowMed.RowHeadersWidth = 62;
            this.dgvShowMed.RowTemplate.Height = 28;
            this.dgvShowMed.Size = new System.Drawing.Size(800, 414);
            this.dgvShowMed.TabIndex = 1;
            // 
            // dgvShowRec
            // 
            this.dgvShowRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowRec.Location = new System.Drawing.Point(0, 36);
            this.dgvShowRec.Name = "dgvShowRec";
            this.dgvShowRec.RowHeadersWidth = 62;
            this.dgvShowRec.RowTemplate.Height = 28;
            this.dgvShowRec.Size = new System.Drawing.Size(800, 414);
            this.dgvShowRec.TabIndex = 2;
            // 
            // dgvShowBill
            // 
            this.dgvShowBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowBill.Location = new System.Drawing.Point(0, 36);
            this.dgvShowBill.Name = "dgvShowBill";
            this.dgvShowBill.RowHeadersWidth = 62;
            this.dgvShowBill.RowTemplate.Height = 28;
            this.dgvShowBill.Size = new System.Drawing.Size(800, 414);
            this.dgvShowBill.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.ckbChangePass);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 414);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(350, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 44);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(275, 67);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(334, 26);
            this.txtPass.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(275, 25);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(334, 26);
            this.txtUserName.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNewPass2);
            this.groupBox2.Controls.Add(this.txtNewPass);
            this.groupBox2.Location = new System.Drawing.Point(135, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 171);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đổi mật khẩu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nhập lại mật khẩu";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(215, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 44);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txtNewPass2
            // 
            this.txtNewPass2.Location = new System.Drawing.Point(173, 68);
            this.txtNewPass2.Name = "txtNewPass2";
            this.txtNewPass2.Size = new System.Drawing.Size(301, 26);
            this.txtNewPass2.TabIndex = 2;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(173, 25);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(301, 26);
            this.txtNewPass.TabIndex = 0;
            // 
            // ckbChangePass
            // 
            this.ckbChangePass.AutoSize = true;
            this.ckbChangePass.Location = new System.Drawing.Point(632, 70);
            this.ckbChangePass.Name = "ckbChangePass";
            this.ckbChangePass.Size = new System.Drawing.Size(129, 24);
            this.ckbChangePass.TabIndex = 2;
            this.ckbChangePass.Text = "Đổi mật khẩu";
            this.ckbChangePass.UseVisualStyleBackColor = true;
            this.ckbChangePass.CheckedChanged += new System.EventHandler(this.ckbChangePass_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvShowBill);
            this.Controls.Add(this.dgvShowRec);
            this.Controls.Add(this.dgvShowMed);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.User_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowRec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBill)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýThuốcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHóaĐơnXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvShowMed;
        private System.Windows.Forms.DataGridView dgvShowRec;
        private System.Windows.Forms.DataGridView dgvShowBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPass2;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.CheckBox ckbChangePass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}