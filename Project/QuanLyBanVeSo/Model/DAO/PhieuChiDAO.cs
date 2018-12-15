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
    public class PhieuChiDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public PhieuChiDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public PHIEUCHI GetByID(int MaPC)
        {
            return db.PHIEUCHIs.SingleOrDefault(x => x.MAPC == MaPC);
        }

        public PHIEUCHI ViewDetail(int MaPC)
        {
            return db.PHIEUCHIs.Find(MaPC);
        }

        public List<PHIEUCHI> GetAll()
        {
            return db.PHIEUCHIs.ToList();
        }
        public IEnumerable<PHIEUCHI> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PHIEUCHI> model = db.PHIEUCHIs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MAPC.ToString().Contains(searchString));
            }
            return model.OrderBy(x => x.MAPC).ToPagedList(page, pageSize);
        }

        public long Insert(PHIEUCHI entity)
        {
            entity.TINHTRANG = 1;
            db.PHIEUCHIs.Add(entity);
            db.SaveChanges();
            return entity.MAPC;
        }

        public bool Update(PHIEUCHI entity)
        {
            try
            {
                var phieuchi = db.PHIEUCHIs.Where(g => g.MAPC == entity.MAPC).SingleOrDefault();
                phieuchi.NGAY = entity.NGAY;
                phieuchi.TIEN = entity.TIEN;
                phieuchi.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
