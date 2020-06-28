namespace Flight.GUI
{
    partial class ManagerCotrol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerCotrol));
            this.btQuyDinh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // btQuyDinh
            // 
            this.btQuyDinh.Active = false;
            this.btQuyDinh.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(140)))));
            this.btQuyDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btQuyDinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btQuyDinh.BorderRadius = 0;
            this.btQuyDinh.ButtonText = "   THAY ĐỔI QUY DỊNH";
            this.btQuyDinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btQuyDinh.DisabledColor = System.Drawing.Color.Gray;
            this.btQuyDinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btQuyDinh.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuyDinh.Iconcolor = System.Drawing.Color.Transparent;
            this.btQuyDinh.Iconimage = ((System.Drawing.Image)(resources.GetObject("btQuyDinh.Iconimage")));
            this.btQuyDinh.Iconimage_right = null;
            this.btQuyDinh.Iconimage_right_Selected = null;
            this.btQuyDinh.Iconimage_Selected = null;
            this.btQuyDinh.IconMarginLeft = 0;
            this.btQuyDinh.IconMarginRight = 0;
            this.btQuyDinh.IconRightVisible = true;
            this.btQuyDinh.IconRightZoom = 0D;
            this.btQuyDinh.IconVisible = true;
            this.btQuyDinh.IconZoom = 50D;
            this.btQuyDinh.IsTab = false;
            this.btQuyDinh.Location = new System.Drawing.Point(0, 0);
            this.btQuyDinh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btQuyDinh.Name = "btQuyDinh";
            this.btQuyDinh.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btQuyDinh.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(131)))));
            this.btQuyDinh.OnHoverTextColor = System.Drawing.Color.White;
            this.btQuyDinh.selected = false;
            this.btQuyDinh.Size = new System.Drawing.Size(272, 52);
            this.btQuyDinh.TabIndex = 4;
            this.btQuyDinh.Text = "   THAY ĐỔI QUY DỊNH";
            this.btQuyDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQuyDinh.Textcolor = System.Drawing.Color.Silver;
            this.btQuyDinh.TextFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuyDinh.Click += new System.EventHandler(this.btQuyDinh_Click);
            // 
            // ManagerCotrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.btQuyDinh);
            this.Name = "ManagerCotrol";
            this.Size = new System.Drawing.Size(272, 52);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btQuyDinh;
    }
}
