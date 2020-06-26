using Flight.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class VeChuyenBayBLL
    {
        VeChuyenBayDAL dalVCB;

        public VeChuyenBayBLL()
        {
            dalVCB = new VeChuyenBayDAL();
        }
    }
}
