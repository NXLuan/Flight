using Flight.DAL;
using Flight.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.BLL
{
    class PhieuDatChoBLL
    {
        PhieuDatChoDAL dalPDC;

        public PhieuDatChoBLL()
        {
            dalPDC = new PhieuDatChoDAL();
        }

        public string getTongSoLuong()
        {
            return dalPDC.getTongSoLuong();
        }
        public bool insertPhieuDatCho(PhieuDatCho PDC)
        {
            return dalPDC.insertPhieuDatCho(PDC);
        }
    }
}
