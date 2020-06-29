using Flight.DAL;
using Flight.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class PhieuDatChoBLL
    {
        PhieuDatChoDAL dalPDC;

        public PhieuDatChoBLL()
        {
            dalPDC = new PhieuDatChoDAL();
        }

        public bool insertPhieuDatCho(PhieuDatCho PDC)
        {
            return dalPDC.insertPhieuDatCho(PDC);
        }

        public string getMaPhieuDatCho()
        {
            return dalPDC.getMaPhieuDatCho();
        }
        public DataTable getInforPhieuDatCho(string s)
        {
            return dalPDC.getInforPhieuDatCho(s);
        }
        public void UpdatePhieuDatCho(PhieuDatCho PDC)
        {
            dalPDC.UpdatePhieuDatCho(PDC);
        }
        public void UpdateTrangThai(string MaPhieuDatCho, string TrangThai)
        {
            dalPDC.UpdateTrangThai(MaPhieuDatCho, TrangThai);
        }
        public string getTrangThai(string MaPhieuDatCho)
        {
            return dalPDC.getTrangThai(MaPhieuDatCho);
        }
        public void HuyPhieuDatCho(string MaPhieuDatCho)
        {
            dalPDC.HuyPhieuDatCho(MaPhieuDatCho);
        }
        public DataTable getThongTinPhieuHuy()
        {
            return dalPDC.getThongTinPhieuHuy();
        }
    }
}
