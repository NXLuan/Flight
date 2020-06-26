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
    class DanhSachVeBLL
    {
        DanhSachVeDAL dalDSV;

        public DanhSachVeBLL()
        {
            dalDSV = new DanhSachVeDAL();
        }
        
        public DataTable getDanhSachVe()
        {
            return dalDSV.getDanhSachVe();
        }
        public int GetSoLuongHangVe()
        {
            return dalDSV.GetSoLuongHangVe();
        }
        public bool CheckTrungHangVe(string s)
        {
            return dalDSV.CheckTrungHangVe(s);
        }
        public bool InsertHangVe(DanhSachVe[] dsv, int n)
        {
            return dalDSV.InsertHangVe(dsv, n);
        }
        public bool DeleteHangVe(string HangVe)
        {
            return dalDSV.DeleteHangVe(HangVe);
        }
        public DanhSachVe GetInfo1HangVe(string HV)
        {
            return dalDSV.GetInfo1HangVe(HV);
        }
        public bool UpdateDanhSachVe(string HV, string TiLe)
        {
            return dalDSV.UpdateDanhSachVe(HV, TiLe);
        }
    }
}
