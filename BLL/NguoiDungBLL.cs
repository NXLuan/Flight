using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight.DAL;
using Flight.DTO;
namespace Flight.BLL
{
    class NguoiDungBLL
    {
        NguoiDungDAL dalND;
        public NguoiDungBLL()
        {
            dalND = new NguoiDungDAL();
        }
        public DataTable getTaiKhoan()
        {
            return dalND.getTaiKhoan();
        }
        public int GetSoLuongTaiKhoan()
        {
            return dalND.GetSoLuongTaiKhoan();
        }
        public bool InsertTaiKhoan(NguoiDung[] user, int n)
        {
            return dalND.InsertTaiKhoan(user, n);
        }
        public bool DeleteNguoiDung(string TenDN)
        {
            return dalND.DeleteNguoiDung(TenDN);
        }
        public NguoiDung GetInfo1TaiKhoan(string TenDN)
        {
            return dalND.GetInfo1TaiKhoan(TenDN);
        }
        public bool CheckTrungTenDN(string s)
        {
            return dalND.CheckTrungTenDN(s);
        }
        public bool UpdateTaiKhoan(string TenDN, string MatKhau, string MaNhom)
        {
            return dalND.UpdateTaiKhoan(TenDN, MatKhau, MaNhom);
        }
        public List<string> GetListQuyen()
        {
            return dalND.GetListQuyen();
        }
    }
}
