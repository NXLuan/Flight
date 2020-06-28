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
            BaoCao bc = new BaoCao
            {
                MaBaoCao = "BC" + Thang.ToString() + Nam.ToString(),
                Thang = int.Parse(Thang),
                Nam = int.Parse(Nam)
            };
            DataTable dt = GetDoanhThuThang(Thang, Nam);
            bc.SoChuyenBay = dt.Rows.Count;
            int TongDoanhThuThang = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                TongDoanhThuThang += int.Parse(dt.Rows[i]["DoanhThu"].ToString());
            bc.DoanhThu = TongDoanhThuThang;
            return InsertBaoCao(bc);
        }
        public DataTable GetDoanhThuThangCoTiLe(string Thang, string Nam)
        {
            DataTable dt = GetDoanhThuThang(Thang, Nam);
            dt.Columns.Add("TiLe");
            float TongDoanhThuThang = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                TongDoanhThuThang += int.Parse(dt.Rows[i]["DoanhThu"].ToString());
            foreach (DataRow row in dt.Rows)
            {
                int DoanhThu = int.Parse(row["DoanhThu"].ToString());
                row["TiLe"] = (DoanhThu * 100 / TongDoanhThuThang).ToString();
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
            float TongDoanhThuNam = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
                TongDoanhThuNam += int.Parse(dt.Rows[i]["DoanhThu"].ToString());
            foreach (DataRow row in dt.Rows)
            {
                int DoanhThu = int.Parse(row["DoanhThu"].ToString());
                row["TiLe"] = (DoanhThu * 100 / TongDoanhThuNam).ToString();
            }
            return dt;
        }
    }
}
