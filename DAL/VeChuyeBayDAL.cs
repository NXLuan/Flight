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
    class VeChuyenBayDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public VeChuyenBayDAL()
        {
            dc = new DataConnection();
        }
        public bool insertVeChuyenBay(VeChuyenBay VCB)
        {
            string sql = "insert into VECHUYENBAY(MaChuyenBay, HangVe, GiaTien, HoTen, CMND, SDT, Email)" +
               " VALUES(@MaChuyenBay, @HangVe, @GiaTien, @HoTen, @CMND, @SDT, @Email)";

            using (SqlConnection con = dc.getConnect())
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    con.Open();
                    cmd.Parameters.Add("@MaChuyenBay", SqlDbType.VarChar).Value = VCB.MaChuyenBay;
                    cmd.Parameters.Add("@HangVe", SqlDbType.VarChar).Value = VCB.HangVe;
                    cmd.Parameters.Add("@GiaTien", SqlDbType.Int).Value = VCB.GiaTien;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = VCB.HoTen;
                    cmd.Parameters.Add("@CMND", SqlDbType.VarChar).Value = VCB.CMND;
                    cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = VCB.SDT;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = VCB.Email;
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
    }
}
