using Flight.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flight.DAL
{
    class ThamSoDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public ThamSoDAL()
        {
            dc = new DataConnection();
        }

        public DataTable GetData(string sql)
        {
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    DataTable dt = new DataTable();
                    da = new SqlDataAdapter(sql, con);

                    con.Open();
                    da.Fill(dt);
                    da.Dispose();
                    con.Close();

                    return dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public int getThoiGianChoPhepDatVe()
        {
            string sql = "select GiaTri from THAMSO where TenThamSo = 'ThoiGianChoPhepDatVe'";

            DataTable dt = GetData(sql);
            if (dt != null) return int.Parse(dt.Rows[0][0].ToString());
            return -1;
        }

        public DataTable getThamSo()
        {
            string sql = "select * from THAMSO";

            return GetData(sql);
        }
        public bool setThamSo(ThamSo[] thamso, int n)
        {
            string GiaTri = "", TenThamSo = "";
            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    con.Open();
                    for (int i = 0; i < n; i++)
                    {
                        TenThamSo = thamso[i].TenThamSo;
                        GiaTri = thamso[i].GiaTri.ToString();
                        string sql = "update THAMSO set GiaTri = " + GiaTri + " where TenThamSo = '" + TenThamSo + "'";
                        cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public int getQuyDinhHuy()
        {
            string sql = "select GiaTri from THAMSO where TenThamSo = 'ChoPhepHuyPhieu'";
            DataTable dt = GetData(sql);
            if (dt == null) return -1;
            return int.Parse(dt.Rows[0][0].ToString());
        }
    }
}
