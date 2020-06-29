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
        public void UpdateSoGheTrong(DanhSachGhe DSG)
        {
            dalDSG.UpdateSoGheTrong(DSG);
        }
        public DataTable getDanhSachGheChuyenBay(string MaChuyenBay)
        {
            return dalDSG.getDanhSachGheChuyenBay(MaChuyenBay);
        }
        public DataTable getDanhSachGhe(string MaChuyenBay)
        {
            return dalDSG.getDanhSachGhe(MaChuyenBay);
        }
        public bool UpdateDanhSachGhe(DataTable tbDSG)
        {
            return dalDSG.UpdateDanhSachGhe(tbDSG);
        }
        public void InsertDanhSachGhe(DanhSachGhe CB)
        {
            dalDSG.insertDanhSachGhe(CB);
        }
        public bool CheckTrungDanhSachGhe(string MaChuyenBay, string HangVe)
        {
            return dalDSG.CheckTrungDanhSachGhe(MaChuyenBay, HangVe);
        }
    }
}
