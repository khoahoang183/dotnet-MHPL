using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data;

namespace Model.DAO
{
    public class CongNoDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public CongNoDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public IEnumerable<CONGNO> GetAll(int page, int pageSize)
        {
            List<CONGNO> listCongNo = new List<CONGNO>();
            var DAILYitems = db.DAILies.ToList();
            foreach (var item in DAILYitems)
            {
                long congno = 0;
                var PHANPHOIitems = db.PHANPHOIs.Where(x => x.MADL == item.MADL).Where(x => x.SLBAN != 0).ToList();
                var PHIEUTHUitems = db.PHIEUTHUs.Where(x => x.MADL == item.MADL).ToList();
                if (PHANPHOIitems != null)
                    foreach (var itema in PHANPHOIitems)
                {
                    congno += Convert.ToInt64(itema.SLBAN * (1.0 - 0.1) * 10000);
                }
                if (PHIEUTHUitems != null)
                foreach (var itemb in PHIEUTHUitems)
                {
                    congno -= Convert.ToInt64(itemb.TIEN);
                }
                CONGNO cn = new CONGNO();
                cn.daily = item;
                cn.congno = congno;
                listCongNo.Add(cn);
            }
            return listCongNo.AsEnumerable().ToPagedList(page,pageSize);
        }
    }
}
