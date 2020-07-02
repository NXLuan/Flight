using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flight.DAL;
using Flight.DTO;
namespace Flight.BLL
{
    class BaoCaoBLL
    {
        BaoCaoDAL dalBaoCao;
        public BaoCaoBLL()
        {
            dalBaoCao = new BaoCaoDAL();
        }
        public DataTable GetDoanhThuThang(string Thang, string Nam)
        {
            return dalBaoCao.GetDoanhThuThang(Thang, Nam);
        }
        public bool InsertBaoCao(BaoCao baocao)
        {
            return dalBaoCao.InsertBaoCao(baocao);
        }
        public bool LuuDoanhThuThang(string Thang, string Nam)
        {
            string[] arr = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };
            BaoCao bc = new BaoCao
            {
                MaBaoCao = "BC" + arr[int.Parse(Thang) - 1] + Nam,
                Thang = int.Parse(Thang),
                Nam = int.Parse(Nam)
            };
            DataTable dt = GetDoanhThuThang(Thang, Nam);
            bc.SoChuyenBay = dt.Rows.Count;
            decimal TongDoanhThuThang = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                TongDoanhThuThang += decimal.Parse(dt.Rows[i]["DoanhThu"].ToString());
            bc.DoanhThu = TongDoanhThuThang;
            return InsertBaoCao(bc);
        }
        public DataTable GetDoanhThuThangCoTiLe(string Thang, string Nam)
        {
            DataTable dt = GetDoanhThuThang(Thang, Nam);
            dt.Columns.Add("TiLe");
            decimal TongDoanhThuThang = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                TongDoanhThuThang += decimal.Parse(dt.Rows[i]["DoanhThu"].ToString());
            foreach (DataRow row in dt.Rows)
            {
                decimal DoanhThu = decimal.Parse(row["DoanhThu"].ToString());
                try
                {
                    row["TiLe"] = (Math.Round((DoanhThu * 100 / TongDoanhThuThang), 2)).ToString();
                }
                catch
                {
                    row["TiLe"] = "";
                }

            }
            return dt;
        }
        public bool CheckTrungMaBaoCao(string MaBaoCao)
        {
            return dalBaoCao.CheckTrungMaBaoCao(MaBaoCao);
        }
        public DataTable GetBaoCaoNam(string Nam)
        {
            return dalBaoCao.GetBaoCaoNam(Nam);
        }
        public DataTable GetBaoCaoNamCoTiLe(string Nam)
        {
            DataTable dt = GetBaoCaoNam(Nam);
            dt.Columns.Add("TiLe");
            decimal TongDoanhThuNam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                TongDoanhThuNam += decimal.Parse(dt.Rows[i]["DoanhThu"].ToString());
            foreach (DataRow row in dt.Rows)
            {
                decimal DoanhThu = decimal.Parse(row["DoanhThu"].ToString());
                try
                {
                    row["TiLe"] = (Math.Round((DoanhThu * 100 / TongDoanhThuNam), 2)).ToString();
                }
                catch
                {
                    row["TiLe"] = "";
                }

            }
            return dt;
        }
    }
}
