namespace Flight
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbFormName = new System.Windows.Forms.Label();
            this.btMinimize = new System.Windows.Forms.Button();
            this.btMaximize = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnFunction = new System.Windows.Forms.Panel();
            this.pnSelect = new System.Windows.Forms.Panel();
            this.btReservate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btFlightSearch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbAccount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btLogin = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pnRight = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnLeft.SuspendLayout();
            this.pnFunction.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.White;
            this.pnTop.Controls.Add(this.lbFormName);
            this.pnTop.Controls.Add(this.btMinimize);
            this.pnTop.Controls.Add(this.btMaximize);
            this.pnTop.Controls.Add(this.btClose);
            this.pnTop.Controls.Add(this.pictureBox2);
            this.pnTop.Controls.Add(this.pictureBox1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1300, 74);
            this.pnTop.TabIndex = 0;
            // 
            // lbFormName
            // 
            this.lbFormName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.lbFormName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFormName.ForeColor = System.Drawing.Color.White;
            this.lbFormName.Location = new System.Drawing.Point(272, 0);
            this.lbFormName.Name = "lbFormName";
            this.lbFormName.Size = new System.Drawing.Size(274, 74);
            this.lbFormName.TabIndex = 5;
            this.lbFormName.Text = "Màn hình chính";
            this.lbFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btMinimize
            // 
            this.btMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinimize.BackColor = System.Drawing.Color.White;
            this.btMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMinimize.BackgroundImage")));
            this.btMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMinimize.FlatAppearance.BorderSize = 0;
            this.btMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.btMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimize.Location = new System.Drawing.Point(1159, 19);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Size = new System.Drawing.Size(39, 36);
            this.btMinimize.TabIndex = 3;
            this.btMinimize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btMinimize.UseVisualStyleBackColor = false;
            this.btMinimize.Click += new System.EventHandler(this.btMinimize_Click);
            // 
            // btMaximize
            // 
            this.btMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaximize.BackColor = System.Drawing.Color.White;
            this.btMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btMaximize.BackgroundImage")));
            this.btMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMaximize.FlatAppearance.BorderSize = 0;
            this.btMaximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.btMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximize.Location = new System.Drawing.Point(1204, 19);
            this.btMaximize.Name = "btMaximize";
            this.btMaximize.Size = new System.Drawing.Size(39, 36);
            this.btMaximize.TabIndex = 4;
            this.btMaximize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btMaximize.UseVisualStyleBackColor = false;
            this.btMaximize.Click += new System.EventHandler(this.btMaximize_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.White;
            this.btClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btClose.BackgroundImage")));
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(1249, 19);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(39, 36);
            this.btClose.TabIndex = 2;
            this.btClose.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(93, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.pnLeft.Controls.Add(this.richTextBox1);
            this.pnLeft.Controls.Add(this.pnFunction);
            this.pnLeft.Controls.Add(this.panel3);
            this.pnLeft.Controls.Add(this.panel1);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 74);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(272, 726);
            this.pnLeft.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 10.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.richTextBox1.Location = new System.Drawing.Point(0, 572);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(272, 154);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "      Flight Project\n      \n      Nguyến Xuân Luân\n      Nguyễn Hữu Hiếu\n      Ph" +
    "an Đức Cường\n      Trương Nhật Tiến";
            // 
            // pnFunction
            // 
            this.pnFunction.Controls.Add(this.pnSelect);
            this.pnFunction.Controls.Add(this.btReservate);
            this.pnFunction.Controls.Add(this.btFlightSearch);
            this.pnFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFunction.Location = new System.Drawing.Point(0, 199);
            this.pnFunction.Name = "pnFunction";
            this.pnFunction.Size = new System.Drawing.Size(272, 265);
            this.pnFunction.TabIndex = 8;
            // 
            // pnSelect
            // 
            this.pnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.pnSelect.Location = new System.Drawing.Point(0, 0);
            this.pnSelect.Name = "pnSelect";
            this.pnSelect.Size = new System.Drawing.Size(5, 52);
            this.pnSelect.TabIndex = 9;
            // 
            // btReservate
            // 
            this.btReservate.Active = false;
            this.btReservate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(140)))));
            this.btReservate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btReservate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btReservate.BorderRadius = 0;
            this.btReservate.ButtonText = "   LẬP PHIẾU ĐẶT CHỖ";
            this.btReservate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReservate.DisabledColor = System.Drawing.Color.Gray;
            this.btReservate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btReservate.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReservate.Iconcolor = System.Drawing.Color.Transparent;
            this.btReservate.Iconimage = ((System.Drawing.Image)(resources.GetObject("btReservate.Iconimage")));
            this.btReservate.Iconimage_right = null;
            this.btReservate.Iconimage_right_Selected = null;
            this.btReservate.Iconimage_Selected = null;
            this.btReservate.IconMarginLeft = 0;
            this.btReservate.IconMarginRight = 0;
            this.btReservate.IconRightVisible = true;
            this.btReservate.IconRightZoom = 0D;
            this.btReservate.IconVisible = true;
            this.btReservate.IconZoom = 50D;
            this.btReservate.IsTab = false;
            this.btReservate.Location = new System.Drawing.Point(0, 52);
            this.btReservate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btReservate.Name = "btReservate";
            this.btReservate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btReservate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(131)))));
            this.btReservate.OnHoverTextColor = System.Drawing.Color.White;
            this.btReservate.selected = false;
            this.btReservate.Size = new System.Drawing.Size(272, 52);
            this.btReservate.TabIndex = 3;
            this.btReservate.Text = "   LẬP PHIẾU ĐẶT CHỖ";
            this.btReservate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReservate.Textcolor = System.Drawing.Color.Silver;
            this.btReservate.TextFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReservate.Click += new System.EventHandler(this.btReservate_Click);
            // 
            // btFlightSearch
            // 
            this.btFlightSearch.Active = false;
            this.btFlightSearch.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(140)))));
            this.btFlightSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btFlightSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFlightSearch.BorderRadius = 0;
            this.btFlightSearch.ButtonText = "   TRA CỨU CHUYẾN BAY";
            this.btFlightSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFlightSearch.DisabledColor = System.Drawing.Color.Gray;
            this.btFlightSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.btFlightSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFlightSearch.Iconcolor = System.Drawing.Color.Transparent;
            this.btFlightSearch.Iconimage = ((System.Drawing.Image)(resources.GetObject("btFlightSearch.Iconimage")));
            this.btFlightSearch.Iconimage_right = null;
            this.btFlightSearch.Iconimage_right_Selected = null;
            this.btFlightSearch.Iconimage_Selected = null;
            this.btFlightSearch.IconMarginLeft = 0;
            this.btFlightSearch.IconMarginRight = 0;
            this.btFlightSearch.IconRightVisible = true;
            this.btFlightSearch.IconRightZoom = 0D;
            this.btFlightSearch.IconVisible = true;
            this.btFlightSearch.IconZoom = 50D;
            this.btFlightSearch.IsTab = false;
            this.btFlightSearch.Location = new System.Drawing.Point(0, 0);
            this.btFlightSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btFlightSearch.Name = "btFlightSearch";
            this.btFlightSearch.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btFlightSearch.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(131)))));
            this.btFlightSearch.OnHoverTextColor = System.Drawing.Color.White;
            this.btFlightSearch.selected = false;
            this.btFlightSearch.Size = new System.Drawing.Size(272, 52);
            this.btFlightSearch.TabIndex = 2;
            this.btFlightSearch.Text = "   TRA CỨU CHUYẾN BAY";
            this.btFlightSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFlightSearch.Textcolor = System.Drawing.Color.Silver;
            this.btFlightSearch.TextFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFlightSearch.Click += new System.EventHandler(this.btFlightSearch_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 68);
            this.panel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "    QUYỀN THAO TÁC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(59)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(272, 5);
            this.panel5.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 131);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbAccount);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 68);
            this.panel4.TabIndex = 6;
            // 
            // lbAccount
            // 
            this.lbAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAccount.ForeColor = System.Drawing.Color.White;
            this.lbAccount.Location = new System.Drawing.Point(0, 0);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(272, 63);
            this.lbAccount.TabIndex = 0;
            this.lbAccount.Text = "    TÀI KHOẢN";
            this.lbAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(50)))), ((int)(((byte)(59)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 5);
            this.panel2.TabIndex = 2;
            // 
            // btLogin
            // 
            this.btLogin.ActiveBorderThickness = 1;
            this.btLogin.ActiveCornerRadius = 5;
            this.btLogin.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btLogin.ActiveForecolor = System.Drawing.Color.White;
            this.btLogin.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(189)))), ((int)(((byte)(235)))));
            this.btLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btLogin.BackgroundImage")));
            this.btLogin.ButtonText = "Đăng nhập";
            this.btLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.ForeColor = System.Drawing.Color.White;
            this.btLogin.IdleBorderThickness = 1;
            this.btLogin.IdleCornerRadius = 5;
            this.btLogin.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btLogin.IdleForecolor = System.Drawing.Color.White;
            this.btLogin.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.btLogin.Location = new System.Drawing.Point(36, 73);
            this.btLogin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(197, 51);
            this.btLogin.TabIndex = 2;
            this.btLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // pnRight
            // 
            this.pnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(272, 74);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(1028, 726);
            this.pnRight.TabIndex = 2;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnTop;
            this.bunifuDragControl1.Vertical = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 800);
            this.Controls.Add(this.pnRight);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1300, 800);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mainform";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnLeft.ResumeLayout(false);
            this.pnFunction.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btMinimize;
        private System.Windows.Forms.Button btMaximize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAccount;
        private Bunifu.Framework.UI.BunifuThinButton2 btLogin;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuFlatButton btFlightSearch;
        private Bunifu.Framework.UI.BunifuFlatButton btReservate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbFormName;
        private System.Windows.Forms.Panel pnSelect;
        private System.Windows.Forms.Panel pnFunction;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

