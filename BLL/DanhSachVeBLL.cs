using Flight.DAL;
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
    }
}
