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
            string sql = "insert into PHIEUDATCHO(MaChuyenBay, HangVe, GiaTien, TrangThai, HoTen, CMND, SDT, Email)" +
               " VALUES(@MaChuyenBay, @HangVe, @GiaTien, @TrangThai, @HoTen, @CMND, @SDT, @Email)";

            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = PDC.MaChuyenBay;
                    cmd.Parameters.Add("@HangVe", SqlDbType.VarChar).Value = PDC.HangVe;
                    cmd.Parameters.Add("@GiaTien", SqlDbType.Int).Value = PDC.GiaTien;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = PDC.TrangThai;
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
        public DataTable getInforPhieuDatCho(string s)
        {
            string sql = "select * from PHIEUDATCHO where MaPhieuDatCho like '" + s + "%' or " +
                "MaChuyenBay like '" + s + "%' or HoTen like '" + s + "%' or CMND like '" + s + "%' or " +
                "SDT like '" + s + "%' or Email like '" + s + "%' or TrangThai = N'" + s + "'";
            return GetData(sql);
        }

        public void UpdatePhieuDatCho(PhieuDatCho PDC)
        {
            string sql = "update PHIEUDATCHO set MaChuyenBay = @MaChuyenBay, HangVe = @HangVe, GiaTien = @GiaTien, " +
                "TrangThai = @TrangThai, HoTen = @HoTen, CMND = @CMND, SDT = @SDT, Email = @Email " +
                "where MaPhieuDatCho = @MaPhieuDatCho";

            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaPhieuDatCho", SqlDbType.VarChar).Value = PDC.MaPhieuDatCho;
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = PDC.MaChuyenBay;
                    cmd.Parameters.Add("@HangVe", SqlDbType.VarChar).Value = PDC.HangVe;
                    cmd.Parameters.Add("@GiaTien", SqlDbType.Int).Value = PDC.GiaTien;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = PDC.TrangThai;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = PDC.HoTen;
                    cmd.Parameters.Add("@CMND", SqlDbType.VarChar).Value = PDC.CMND;
                    cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = PDC.SDT;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = PDC.Email;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void UpdateTrangThai(string MaPhieuDatCho, string TrangThai)
        {
            string sql = "update PHIEUDATCHO set TrangThai = @TrangThai " +
                "where MaPhieuDatCho = @MaPhieuDatCho";

            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaPhieuDatCho", SqlDbType.VarChar).Value = MaPhieuDatCho;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = TrangThai;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string getTrangThai(string MaPhieuDatCho)
        {
            string sql = "select TrangThai from PHIEUDATCHO where MaPhieuDatCho = '" + MaPhieuDatCho + "'";

            DataTable dt = GetData(sql);
            if (dt == null) return null;
            return dt.Rows[0][0].ToString();
        }
    }
}
