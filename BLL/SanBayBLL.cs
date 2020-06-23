using Flight.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class SanBayBLL
    {
        SanBayDAL dalSB;

        public SanBayBLL()
        {
            dalSB = new SanBayDAL();
        }
        public DataTable getSanBay()
        {
            return dalSB.getSanBay();
        }
    }
}
