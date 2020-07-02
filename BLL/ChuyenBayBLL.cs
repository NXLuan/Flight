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
    class ChuyenBayBLL
    {
        ChuyenBayDAL dalCB;

        public ChuyenBayBLL()
        {
            dalCB = new ChuyenBayDAL();
        }
        public DateTime getNgayKhoiHanh(string MaChuyenBay)
        {
            return dalCB.getNgayKhoiHanh(MaChuyenBay);
        }
        public decimal getDonGia(string MaChuyenBay)
        {
            return dalCB.getDonGia(MaChuyenBay);
        }

        public DataTable getThongTinChuyenBay(string NgayGio, string SanBayDi, string SanBayDen)
        {
            return dalCB.getThongTinChuyenBay(NgayGio, SanBayDi, SanBayDen);
        }
        public void InsertChuyenBay(ChuyenBay CB)
        {
            dalCB.insertChuyenBay(CB);
        }
        public DataTable getChuyenBay()
        {
            return dalCB.getChuyenBay();
        }
        public bool DeleteChuyenBay(string MaChuyenBay)
        {
            return dalCB.DeleteChuyenBay(MaChuyenBay);
        }
        public bool UpdateChuyenBay(ChuyenBay CB)
        {
            return dalCB.UpdateChuyenBay(CB);
        }
        public bool CheckTrungChuyenBay(string MaChuyenBay)
        {
            return dalCB.CheckTrungChuyenBay(MaChuyenBay);
        }
    }
}
