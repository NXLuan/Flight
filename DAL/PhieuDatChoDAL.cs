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
    class PhieuDatChoDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public PhieuDatChoDAL()
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

        public bool insertPhieuDatCho(PhieuDatCho PDC)
        {
            string sql = "insert into PHIEUDATCHO(MaChuyenBay, HangVe, GiaTien, HoTen, CMND, SDT, Email)" +
               " VALUES(@MaChuyenBay, @HangVe, @GiaTien, @HoTen, @CMND, @SDT, @Email)";

            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = PDC.MaChuyenBay;
                    cmd.Parameters.Add("@HangVe", SqlDbType.VarChar).Value = PDC.HangVe;
                    cmd.Parameters.Add("@GiaTien", SqlDbType.Int).Value = PDC.GiaTien;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = PDC.HoTen;
                    cmd.Parameters.Add("@CMND", SqlDbType.VarChar).Value = PDC.CMND;
                    cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = PDC.SDT;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = PDC.Email;
                    cmd.ExecuteNonQuery();
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

        public string getMaPhieuDatCho()
        {
            string sql = "select dbo.AUTO_IDPDC()";

            DataTable dt = GetData(sql);

            if (dt == null) return null;
            return dt.Rows[0][0].ToString();
        }
    }
}
