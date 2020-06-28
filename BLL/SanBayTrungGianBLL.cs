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
    class SanBayTrungGianBLL
    {
        SanBayTrungGianDAL dalSBTG;

        public SanBayTrungGianBLL()
        {
            dalSBTG = new SanBayTrungGianDAL();
        }
        public void InsertSanBayTrungGian(SanBayTrungGian SBTG)
        {
            dalSBTG.insertSanBayTrungGian(SBTG);
        }
        public DataTable getSanBayTrungGian(string MaChuyenBay)
        {
            return dalSBTG.getSanBayTrungGian(MaChuyenBay);
        }
        public bool UpdateSanBayTrungGian(DataTable tbSBTG)
        {
            return dalSBTG.UpdateSanBayTrungGian(tbSBTG);
        }
        public bool CheckTrungSanBayTrungGian(string MaChuyenBay, string MaSanBay)
        {
            return dalSBTG.CheckTrungSanBayTrungGian(MaChuyenBay, MaSanBay);
        }
    }
}
