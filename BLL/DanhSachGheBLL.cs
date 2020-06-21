using Flight.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class DanhSachGheBLL
    {
        DanhSachGheDAL dalDSG;

        public DanhSachGheBLL()
        {
            dalDSG = new DanhSachGheDAL();
        }
        public int getSoGheTrong(string MaChuyenBay, string HangVe)
        {
            return dalDSG.getSoGheTrong(MaChuyenBay, HangVe);
        }
    }
}
