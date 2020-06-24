using Flight.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class ThamSoBLL
    {
        ThamSoDAL dalTS;

        public ThamSoBLL()
        {
            dalTS = new ThamSoDAL();
        }

        public int getThoiGianChoPhepDatVe()
        {
            return dalTS.getThoiGianChoPhepDatVe();
        }
    }
}
