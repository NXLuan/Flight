using Flight.DAL;
using Flight.DTO;
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

        public DataTable getThamSo()
        {
            return dalTS.getThamSo();
        }

        public bool setThamSo(ThamSo[] thamso, int n)
        {
            return dalTS.setThamSo(thamso, n);
        }
        public int getQuyDinhHuy()
        {
            return dalTS.getQuyDinhHuy();
        }
    }
}
