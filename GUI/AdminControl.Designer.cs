namespace Flight.GUI
{
    partial class AdminControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminControl));
            this.btPhanQuyen = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // btPhanQuyen
            // 
            this.btPhanQuyen.Active = false;
            this.btPhanQuyen.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(140)))));
            this.btPhanQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btPhanQuyen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPhanQuyen.BorderRadius = 0;
            this.btPhanQuyen.ButtonText = "   PHÂN QUYỀN";
            this.btPhanQuyen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPhanQuyen.DisabledColor = System.Drawing.Color.Gray;
            this.btPhanQuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btPhanQuyen.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPhanQuyen.Iconcolor = System.Drawing.Color.Transparent;
            this.btPhanQuyen.Iconimage = ((System.Drawing.Image)(resources.GetObject("btPhanQuyen.Iconimage")));
            this.btPhanQuyen.Iconimage_right = null;
            this.btPhanQuyen.Iconimage_right_Selected = null;
            this.btPhanQuyen.Iconimage_Selected = null;
            this.btPhanQuyen.IconMarginLeft = 0;
            this.btPhanQuyen.IconMarginRight = 0;
            this.btPhanQuyen.IconRightVisible = true;
            this.btPhanQuyen.IconRightZoom = 0D;
            this.btPhanQuyen.IconVisible = true;
            this.btPhanQuyen.IconZoom = 50D;
            this.btPhanQuyen.IsTab = false;
            this.btPhanQuyen.Location = new System.Drawing.Point(0, 0);
            this.btPhanQuyen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btPhanQuyen.Name = "btPhanQuyen";
            this.btPhanQuyen.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btPhanQuyen.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(117)))), ((int)(((byte)(131)))));
            this.btPhanQuyen.OnHoverTextColor = System.Drawing.Color.White;
            this.btPhanQuyen.selected = false;
            this.btPhanQuyen.Size = new System.Drawing.Size(272, 52);
            this.btPhanQuyen.TabIndex = 3;
            this.btPhanQuyen.Text = "   PHÂN QUYỀN";
            this.btPhanQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPhanQuyen.Textcolor = System.Drawing.Color.Silver;
            this.btPhanQuyen.TextFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPhanQuyen.Click += new System.EventHandler(this.btPhanQuyen_Click);
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.btPhanQuyen);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(272, 52);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btPhanQuyen;
    }
}
