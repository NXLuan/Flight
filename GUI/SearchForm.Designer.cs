namespace Flight.GUI
{
    partial class SearchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbMaChuyenBay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.datagridChuyenBay = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dpNgayGio = new Bunifu.Framework.UI.BunifuDatepicker();
            this.cbSanBayDi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSanBayDen = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colMaChuyenBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SanBayDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SanBayDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGheTrong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGheDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridChuyenBay)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(26, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(977, 678);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbMaChuyenBay);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.datagridChuyenBay);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(977, 618);
            this.panel4.TabIndex = 7;
            // 
            // tbMaChuyenBay
            // 
            this.tbMaChuyenBay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMaChuyenBay.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaChuyenBay.Location = new System.Drawing.Point(641, 10);
            this.tbMaChuyenBay.Name = "tbMaChuyenBay";
            this.tbMaChuyenBay.ReadOnly = true;
            this.tbMaChuyenBay.Size = new System.Drawing.Size(127, 30);
            this.tbMaChuyenBay.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.label4.Location = new System.Drawing.Point(520, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Chuyến bay:";
            // 
            // datagridChuyenBay
            // 
            this.datagridChuyenBay.AllowUserToAddRows = false;
            this.datagridChuyenBay.AllowUserToDeleteRows = false;
            this.datagridChuyenBay.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.datagridChuyenBay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridChuyenBay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridChuyenBay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridChuyenBay.BackgroundColor = System.Drawing.Color.LightGray;
            this.datagridChuyenBay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datagridChuyenBay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datagridChuyenBay.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridChuyenBay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridChuyenBay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridChuyenBay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaChuyenBay,
            this.SanBayDi,
            this.SanBayDen,
            this.NgayGio,
            this.ThoiGianBay,
            this.SoGheTrong,
            this.SoGheDat});
            this.datagridChuyenBay.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridChuyenBay.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridChuyenBay.DoubleBuffered = true;
            this.datagridChuyenBay.EnableHeadersVisualStyles = false;
            this.datagridChuyenBay.HeaderBgColor = System.Drawing.Color.White;
            this.datagridChuyenBay.HeaderForeColor = System.Drawing.Color.Black;
            this.datagridChuyenBay.Location = new System.Drawing.Point(367, 51);
            this.datagridChuyenBay.Name = "datagridChuyenBay";
            this.datagridChuyenBay.ReadOnly = true;
            this.datagridChuyenBay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datagridChuyenBay.RowHeadersVisible = false;
            this.datagridChuyenBay.RowHeadersWidth = 51;
            this.datagridChuyenBay.RowTemplate.Height = 35;
            this.datagridChuyenBay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagridChuyenBay.Size = new System.Drawing.Size(610, 567);
            this.datagridChuyenBay.TabIndex = 34;
            this.datagridChuyenBay.CurrentCellChanged += new System.EventHandler(this.datagridChuyenBay_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dpNgayGio);
            this.panel1.Controls.Add(this.cbSanBayDi);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbSanBayDen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 618);
            this.panel1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "Ngày khởi hành:";
            // 
            // dpNgayGio
            // 
            this.dpNgayGio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(156)))), ((int)(((byte)(225)))));
            this.dpNgayGio.BorderRadius = 0;
            this.dpNgayGio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpNgayGio.ForeColor = System.Drawing.Color.White;
            this.dpNgayGio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpNgayGio.FormatCustom = null;
            this.dpNgayGio.Location = new System.Drawing.Point(24, 51);
            this.dpNgayGio.Margin = new System.Windows.Forms.Padding(4);
            this.dpNgayGio.Name = "dpNgayGio";
            this.dpNgayGio.Size = new System.Drawing.Size(317, 44);
            this.dpNgayGio.TabIndex = 33;
            this.dpNgayGio.Value = new System.DateTime(2020, 6, 14, 23, 52, 45, 204);
            this.dpNgayGio.onValueChanged += new System.EventHandler(this.dpNgayGio_onValueChanged);
            // 
            // cbSanBayDi
            // 
            this.cbSanBayDi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanBayDi.FormattingEnabled = true;
            this.cbSanBayDi.Location = new System.Drawing.Point(24, 140);
            this.cbSanBayDi.Name = "cbSanBayDi";
            this.cbSanBayDi.Size = new System.Drawing.Size(317, 31);
            this.cbSanBayDi.TabIndex = 4;
            this.cbSanBayDi.SelectedIndexChanged += new System.EventHandler(this.cbSanBayDi_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Sân bay đi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Sân bay đến:";
            // 
            // cbSanBayDen
            // 
            this.cbSanBayDen.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanBayDen.FormattingEnabled = true;
            this.cbSanBayDen.Location = new System.Drawing.Point(24, 217);
            this.cbSanBayDen.Name = "cbSanBayDen";
            this.cbSanBayDen.Size = new System.Drawing.Size(317, 31);
            this.cbSanBayDen.TabIndex = 29;
            this.cbSanBayDen.SelectedIndexChanged += new System.EventHandler(this.cbSanBayDen_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 60);
            this.panel2.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(131)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(367, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(610, 60);
            this.label9.TabIndex = 34;
            this.label9.Text = "Danh sách chuyến bay";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(131)))), ((int)(((byte)(149)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 60);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tiêu chuẩn tra cứu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colMaChuyenBay
            // 
            this.colMaChuyenBay.DataPropertyName = "MaChuyenBay";
            this.colMaChuyenBay.HeaderText = "MaChuyenBay";
            this.colMaChuyenBay.MinimumWidth = 6;
            this.colMaChuyenBay.Name = "colMaChuyenBay";
            this.colMaChuyenBay.ReadOnly = true;
            this.colMaChuyenBay.Visible = false;
            // 
            // SanBayDi
            // 
            this.SanBayDi.DataPropertyName = "SanBayDi";
            this.SanBayDi.HeaderText = "Sân bay đi";
            this.SanBayDi.MinimumWidth = 6;
            this.SanBayDi.Name = "SanBayDi";
            this.SanBayDi.ReadOnly = true;
            // 
            // SanBayDen
            // 
            this.SanBayDen.DataPropertyName = "SanBayDen";
            this.SanBayDen.HeaderText = "Sân bay đến";
            this.SanBayDen.MinimumWidth = 6;
            this.SanBayDen.Name = "SanBayDen";
            this.SanBayDen.ReadOnly = true;
            // 
            // NgayGio
            // 
            this.NgayGio.DataPropertyName = "NgayGio";
            this.NgayGio.HeaderText = "Khời hành";
            this.NgayGio.MinimumWidth = 6;
            this.NgayGio.Name = "NgayGio";
            this.NgayGio.ReadOnly = true;
            // 
            // ThoiGianBay
            // 
            this.ThoiGianBay.DataPropertyName = "ThoiGianBay";
            this.ThoiGianBay.HeaderText = "Thời gian";
            this.ThoiGianBay.MinimumWidth = 6;
            this.ThoiGianBay.Name = "ThoiGianBay";
            this.ThoiGianBay.ReadOnly = true;
            // 
            // SoGheTrong
            // 
            this.SoGheTrong.DataPropertyName = "SoGheTrong";
            this.SoGheTrong.HeaderText = "Số ghế trống";
            this.SoGheTrong.MinimumWidth = 6;
            this.SoGheTrong.Name = "SoGheTrong";
            this.SoGheTrong.ReadOnly = true;
            // 
            // SoGheDat
            // 
            this.SoGheDat.DataPropertyName = "SoGheDat";
            this.SoGheDat.HeaderText = "Số ghế đặt";
            this.SoGheDat.MinimumWidth = 6;
            this.SoGheDat.Name = "SoGheDat";
            this.SoGheDat.ReadOnly = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1028, 726);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridChuyenBay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSanBayDi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSanBayDen;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuDatepicker dpNgayGio;
        private Bunifu.Framework.UI.BunifuCustomDataGrid datagridChuyenBay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChuyenBay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMaChuyenBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaChuyenBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanBayDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanBayDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGheTrong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGheDat;
    }
}