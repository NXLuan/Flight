namespace Flight.GUI
{
    partial class AccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pn1 = new System.Windows.Forms.Panel();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.pnThemTK = new System.Windows.Forms.Panel();
            this.cbQuyen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTBThemTK = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThempanelTK = new System.Windows.Forms.Button();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnChonFile = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnLuu = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnThoat = new Bunifu.Framework.UI.BunifuThinButton2();
            this.listViewTK = new System.Windows.Forms.ListView();
            this.colTenDangNhap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatKhau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuyen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbSLTK = new System.Windows.Forms.Label();
            this.btnThemTK = new Bunifu.Framework.UI.BunifuThinButton2();
            this.dgvTaiKhoan = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.dgvcolTenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcolMatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcolQuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colExit = new System.Windows.Forms.DataGridViewImageColumn();
            this.pn1.SuspendLayout();
            this.pnThemTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // pn1
            // 
            this.pn1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pn1.BackColor = System.Drawing.Color.White;
            this.pn1.Controls.Add(this.lbThongBao);
            this.pn1.Controls.Add(this.pnThemTK);
            this.pn1.Controls.Add(this.label11);
            this.pn1.Controls.Add(this.lbSLTK);
            this.pn1.Controls.Add(this.btnThemTK);
            this.pn1.Controls.Add(this.dgvTaiKhoan);
            this.pn1.Location = new System.Drawing.Point(11, 49);
            this.pn1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pn1.Name = "pn1";
            this.pn1.Size = new System.Drawing.Size(1005, 633);
            this.pn1.TabIndex = 8;
            // 
            // lbThongBao
            // 
            this.lbThongBao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbThongBao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongBao.Location = new System.Drawing.Point(175, 75);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(684, 28);
            this.lbThongBao.TabIndex = 43;
            this.lbThongBao.Text = "Thông báo";
            this.lbThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThongBao.Visible = false;
            // 
            // pnThemTK
            // 
            this.pnThemTK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnThemTK.Controls.Add(this.cbQuyen);
            this.pnThemTK.Controls.Add(this.label1);
            this.pnThemTK.Controls.Add(this.lbTBThemTK);
            this.pnThemTK.Controls.Add(this.btnXoa);
            this.pnThemTK.Controls.Add(this.btnThempanelTK);
            this.pnThemTK.Controls.Add(this.txtTenDangNhap);
            this.pnThemTK.Controls.Add(this.txtMatKhau);
            this.pnThemTK.Controls.Add(this.btnChonFile);
            this.pnThemTK.Controls.Add(this.btnLuu);
            this.pnThemTK.Controls.Add(this.btnThoat);
            this.pnThemTK.Controls.Add(this.listViewTK);
            this.pnThemTK.Controls.Add(this.label15);
            this.pnThemTK.Controls.Add(this.label14);
            this.pnThemTK.Controls.Add(this.label13);
            this.pnThemTK.Location = new System.Drawing.Point(196, 107);
            this.pnThemTK.Margin = new System.Windows.Forms.Padding(4);
            this.pnThemTK.Name = "pnThemTK";
            this.pnThemTK.Size = new System.Drawing.Size(629, 448);
            this.pnThemTK.TabIndex = 31;
            this.pnThemTK.Visible = false;
            // 
            // cbQuyen
            // 
            this.cbQuyen.FormattingEnabled = true;
            this.cbQuyen.Location = new System.Drawing.Point(323, 76);
            this.cbQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(169, 24);
            this.cbQuyen.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 43;
            this.label1.Text = "Quyền:";
            // 
            // lbTBThemTK
            // 
            this.lbTBThemTK.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTBThemTK.Location = new System.Drawing.Point(4, 367);
            this.lbTBThemTK.Name = "lbTBThemTK";
            this.lbTBThemTK.Size = new System.Drawing.Size(488, 23);
            this.lbTBThemTK.TabIndex = 42;
            this.lbTBThemTK.Text = "Thông báo";
            this.lbTBThemTK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTBThemTK.Visible = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(513, 293);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 28);
            this.btnXoa.TabIndex = 41;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThempanelTK
            // 
            this.btnThempanelTK.Location = new System.Drawing.Point(513, 75);
            this.btnThempanelTK.Margin = new System.Windows.Forms.Padding(4);
            this.btnThempanelTK.Name = "btnThempanelTK";
            this.btnThempanelTK.Size = new System.Drawing.Size(100, 28);
            this.btnThempanelTK.TabIndex = 39;
            this.btnThempanelTK.Text = "Thêm";
            this.btnThempanelTK.UseVisualStyleBackColor = true;
            this.btnThempanelTK.Click += new System.EventHandler(this.btnThempanelTK_Click);
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(8, 78);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(155, 22);
            this.txtTenDangNhap.TabIndex = 38;
            this.txtTenDangNhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenDangNhap_KeyPress);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(172, 78);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(141, 22);
            this.txtMatKhau.TabIndex = 37;
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatKhau_KeyPress);
            // 
            // btnChonFile
            // 
            this.btnChonFile.ActiveBorderThickness = 1;
            this.btnChonFile.ActiveCornerRadius = 5;
            this.btnChonFile.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnChonFile.ActiveForecolor = System.Drawing.Color.White;
            this.btnChonFile.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnChonFile.BackColor = System.Drawing.Color.White;
            this.btnChonFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonFile.BackgroundImage")));
            this.btnChonFile.ButtonText = "Chọn file";
            this.btnChonFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonFile.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonFile.ForeColor = System.Drawing.Color.White;
            this.btnChonFile.IdleBorderThickness = 1;
            this.btnChonFile.IdleCornerRadius = 5;
            this.btnChonFile.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnChonFile.IdleForecolor = System.Drawing.Color.White;
            this.btnChonFile.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnChonFile.Location = new System.Drawing.Point(8, 396);
            this.btnChonFile.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(107, 46);
            this.btnChonFile.TabIndex = 35;
            this.btnChonFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ActiveBorderThickness = 1;
            this.btnLuu.ActiveCornerRadius = 5;
            this.btnLuu.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnLuu.ActiveForecolor = System.Drawing.Color.White;
            this.btnLuu.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLuu.BackgroundImage")));
            this.btnLuu.ButtonText = "Lưu";
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.IdleBorderThickness = 1;
            this.btnLuu.IdleCornerRadius = 5;
            this.btnLuu.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnLuu.IdleForecolor = System.Drawing.Color.White;
            this.btnLuu.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnLuu.Location = new System.Drawing.Point(269, 396);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(107, 46);
            this.btnLuu.TabIndex = 34;
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.ActiveBorderThickness = 1;
            this.btnThoat.ActiveCornerRadius = 5;
            this.btnThoat.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnThoat.ActiveForecolor = System.Drawing.Color.White;
            this.btnThoat.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnThoat.BackColor = System.Drawing.Color.White;
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.ButtonText = "Thoát";
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.IdleBorderThickness = 1;
            this.btnThoat.IdleCornerRadius = 5;
            this.btnThoat.IdleFillColor = System.Drawing.Color.White;
            this.btnThoat.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnThoat.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnThoat.Location = new System.Drawing.Point(387, 396);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 46);
            this.btnThoat.TabIndex = 33;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // listViewTK
            // 
            this.listViewTK.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listViewTK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTenDangNhap,
            this.colMatKhau,
            this.colQuyen});
            this.listViewTK.FullRowSelect = true;
            this.listViewTK.GridLines = true;
            this.listViewTK.HideSelection = false;
            this.listViewTK.Location = new System.Drawing.Point(8, 110);
            this.listViewTK.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTK.MultiSelect = false;
            this.listViewTK.Name = "listViewTK";
            this.listViewTK.Size = new System.Drawing.Size(484, 240);
            this.listViewTK.TabIndex = 27;
            this.listViewTK.UseCompatibleStateImageBehavior = false;
            this.listViewTK.View = System.Windows.Forms.View.Details;
            this.listViewTK.SelectedIndexChanged += new System.EventHandler(this.listViewTK_SelectedIndexChanged);
            // 
            // colTenDangNhap
            // 
            this.colTenDangNhap.Text = "Tên Đăng Nhập";
            this.colTenDangNhap.Width = 117;
            // 
            // colMatKhau
            // 
            this.colMatKhau.Text = "Mật Khẩu";
            this.colMatKhau.Width = 115;
            // 
            // colQuyen
            // 
            this.colQuyen.Text = "Quyền";
            this.colQuyen.Width = 130;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(168, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 23);
            this.label15.TabIndex = 24;
            this.label15.Text = "Mật khẩu:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(128, 23);
            this.label14.TabIndex = 23;
            this.label14.Text = "Tên đăng nhập:";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(131)))));
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(629, 47);
            this.label13.TabIndex = 5;
            this.label13.Text = "Thêm tài khoản";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(149)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(1005, 60);
            this.label11.TabIndex = 4;
            this.label11.Text = "Danh sách tài khoản";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSLTK
            // 
            this.lbSLTK.AutoSize = true;
            this.lbSLTK.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSLTK.Location = new System.Drawing.Point(9, 75);
            this.lbSLTK.Name = "lbSLTK";
            this.lbSLTK.Size = new System.Drawing.Size(160, 23);
            this.lbSLTK.TabIndex = 22;
            this.lbSLTK.Text = "Số lượng tài khoản:";
            // 
            // btnThemTK
            // 
            this.btnThemTK.ActiveBorderThickness = 1;
            this.btnThemTK.ActiveCornerRadius = 5;
            this.btnThemTK.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnThemTK.ActiveForecolor = System.Drawing.Color.White;
            this.btnThemTK.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btnThemTK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemTK.BackColor = System.Drawing.Color.White;
            this.btnThemTK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThemTK.BackgroundImage")));
            this.btnThemTK.ButtonText = "Thêm";
            this.btnThemTK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemTK.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTK.ForeColor = System.Drawing.Color.White;
            this.btnThemTK.IdleBorderThickness = 1;
            this.btnThemTK.IdleCornerRadius = 5;
            this.btnThemTK.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnThemTK.IdleForecolor = System.Drawing.Color.White;
            this.btnThemTK.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btnThemTK.Location = new System.Drawing.Point(893, 66);
            this.btnThemTK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(107, 46);
            this.btnThemTK.TabIndex = 28;
            this.btnThemTK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowCustomTheming = false;
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            this.dgvTaiKhoan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTaiKhoan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaiKhoan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTaiKhoan.ColumnHeadersHeight = 40;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcolTenDangNhap,
            this.dgvcolMatKhau,
            this.dgvcolQuyen,
            this.colEdit,
            this.colExit});
            this.dgvTaiKhoan.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvTaiKhoan.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTaiKhoan.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvTaiKhoan.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgvTaiKhoan.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvTaiKhoan.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.CurrentTheme.Name = null;
            this.dgvTaiKhoan.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvTaiKhoan.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvTaiKhoan.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaiKhoan.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvTaiKhoan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvTaiKhoan.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.dgvTaiKhoan.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvTaiKhoan.HeaderForeColor = System.Drawing.Color.White;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(8, 117);
            this.dgvTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 40;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(995, 508);
            this.dgvTaiKhoan.TabIndex = 44;
            this.dgvTaiKhoan.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.dgvTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaiKhoan_CellContentClick);
            this.dgvTaiKhoan.CurrentCellChanged += new System.EventHandler(this.dgvTaiKhoan_CurrentCellChanged);
            this.dgvTaiKhoan.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTaiKhoan_DataError);
            // 
            // dgvcolTenDangNhap
            // 
            this.dgvcolTenDangNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvcolTenDangNhap.DataPropertyName = "TenDangNhap";
            this.dgvcolTenDangNhap.HeaderText = "Tên Đăng Nhập";
            this.dgvcolTenDangNhap.MinimumWidth = 6;
            this.dgvcolTenDangNhap.Name = "dgvcolTenDangNhap";
            this.dgvcolTenDangNhap.ReadOnly = true;
            this.dgvcolTenDangNhap.Width = 200;
            // 
            // dgvcolMatKhau
            // 
            this.dgvcolMatKhau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvcolMatKhau.DataPropertyName = "MatKhau";
            this.dgvcolMatKhau.HeaderText = "Mật Khẩu";
            this.dgvcolMatKhau.MinimumWidth = 6;
            this.dgvcolMatKhau.Name = "dgvcolMatKhau";
            this.dgvcolMatKhau.ReadOnly = true;
            this.dgvcolMatKhau.Width = 250;
            // 
            // dgvcolQuyen
            // 
            this.dgvcolQuyen.DataPropertyName = "Quyen";
            this.dgvcolQuyen.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dgvcolQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvcolQuyen.HeaderText = "Quyền";
            this.dgvcolQuyen.MinimumWidth = 6;
            this.dgvcolQuyen.Name = "dgvcolQuyen";
            this.dgvcolQuyen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = ((System.Drawing.Image)(resources.GetObject("colEdit.Image")));
            this.colEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Width = 30;
            // 
            // colExit
            // 
            this.colExit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colExit.HeaderText = "";
            this.colExit.Image = ((System.Drawing.Image)(resources.GetObject("colExit.Image")));
            this.colExit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colExit.MinimumWidth = 6;
            this.colExit.Name = "colExit";
            this.colExit.ReadOnly = true;
            this.colExit.Width = 30;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1028, 730);
            this.Controls.Add(this.pn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AccountForm";
            this.Text = "TicketForm";
            this.pn1.ResumeLayout(false);
            this.pn1.PerformLayout();
            this.pnThemTK.ResumeLayout(false);
            this.pnThemTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn1;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Panel pnThemTK;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTBThemTK;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThempanelTK;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private Bunifu.Framework.UI.BunifuThinButton2 btnChonFile;
        private Bunifu.Framework.UI.BunifuThinButton2 btnLuu;
        private Bunifu.Framework.UI.BunifuThinButton2 btnThoat;
        private System.Windows.Forms.ListView listViewTK;
        private System.Windows.Forms.ColumnHeader colTenDangNhap;
        private System.Windows.Forms.ColumnHeader colMatKhau;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbSLTK;
        private Bunifu.Framework.UI.BunifuThinButton2 btnThemTK;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvTaiKhoan;
        private System.Windows.Forms.ColumnHeader colQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcolTenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcolMatKhau;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcolQuyen;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colExit;
    }
}