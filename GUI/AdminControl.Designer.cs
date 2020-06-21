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
            this.btFlightSearch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // btFlightSearch
            // 
            this.btFlightSearch.Active = false;
            this.btFlightSearch.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(136)))), ((int)(((byte)(140)))));
            this.btFlightSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.btFlightSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btFlightSearch.BorderRadius = 0;
            this.btFlightSearch.ButtonText = "   PHÂN QUYỀN";
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
            this.btFlightSearch.TabIndex = 3;
            this.btFlightSearch.Text = "   PHÂN QUYỀN";
            this.btFlightSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFlightSearch.Textcolor = System.Drawing.Color.Silver;
            this.btFlightSearch.TextFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // AdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(57)))), ((int)(((byte)(66)))));
            this.Controls.Add(this.btFlightSearch);
            this.Name = "AdminControl";
            this.Size = new System.Drawing.Size(272, 52);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btFlightSearch;
    }
}
