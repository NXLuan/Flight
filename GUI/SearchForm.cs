using Flight.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight.GUI
{
    public partial class SearchForm : Form
    {
        SanBayBLL bllSB;
        ChuyenBayBLL bllCB;
        int Index;

        public SearchForm()
        {
            InitializeComponent();
            bllSB = new SanBayBLL();
            bllCB = new ChuyenBayBLL();

            cbSanBayDen.DataSource = bllSB.getSanBay();
            cbSanBayDen.DisplayMember = "TenSanBay";
            cbSanBayDi.DataSource = bllSB.getSanBay();
            cbSanBayDi.DisplayMember = "TenSanBay";

            dpNgayGio.Value = DateTime.Now;
        }

        private void dpNgayGio_onValueChanged(object sender, EventArgs e)
        {
            SearchFlight();
        }

        private void cbSanBayDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchFlight();
        }

        private void cbSanBayDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchFlight();
        }

        public void SearchFlight()
        {
            datagridChuyenBay.DataSource = bllCB.getThongTinChuyenBay(dpNgayGio.Value.ToShortDateString(), cbSanBayDi.Text, cbSanBayDen.Text);
        }

        private void datagridChuyenBay_CurrentCellChanged(object sender, EventArgs e)
        {
            if (datagridChuyenBay.CurrentCell == null) return;
            Index = datagridChuyenBay.CurrentCell.RowIndex;
            tbMaChuyenBay.Text = datagridChuyenBay.Rows[Index].Cells[0].Value.ToString();
        }

        public string getMaChuyenBay()
        {
            return tbMaChuyenBay.Text;
        }
    }
}