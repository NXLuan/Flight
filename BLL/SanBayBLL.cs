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
    class SanBayBLL
    {
        SanBayDAL dalSB;

        public SanBayBLL()
        {
            dalSB = new SanBayDAL();
        }
        public DataTable getSanBay()
        {
            return dalSB.getSanBay();
        }
        public bool InsertSanBay(SanBay[] sanbay, int n)
        {
            return dalSB.InsertSanBay(sanbay, n);
        }
        public bool CheckTrungMaSB(string s)
        {
            return dalSB.CheckTrungMaSB(s);
        }
        public int GetSoLuongSanBay()
        {
            return dalSB.GetSoLuongSanBay();
        }
        public SanBay GetInfo1SanBay(string MaSB)
        {
            return dalSB.GetInfo1SanBay(MaSB);
        }
        public bool DeleteSanBay(string MaSanBay)
        {
            return dalSB.DeleteSanBay(MaSanBay);
        }
        public bool UpdateSanBay(string MaSB, string TenSB)
        {
            return dalSB.UpdateSanBay(MaSB, TenSB);
        }
    }
}
