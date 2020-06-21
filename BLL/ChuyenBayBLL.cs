using Flight.DAL;
using System;
using System.Collections.Generic;
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
        public int getDonGia(string MaChuyenBay)
        {
            return dalCB.getDonGia(MaChuyenBay);
        }
    }
}
