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
    public class PhieuThuDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public PhieuThuDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public PHIEUTHU GetByID(int MaPT)
        {
            return db.PHIEUTHUs.SingleOrDefault(x=> x.MAPT == MaPT);
        }

        public PHIEUTHU ViewDetail(int MaPT)
        {
            return db.PHIEUTHUs.Find(MaPT);
        }

        public List<PHIEUTHU> GetAll()
        {
            return db.PHIEUTHUs.ToList();
        }
        public IEnumerable<PHIEUTHU> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PHIEUTHU> model = db.PHIEUTHUs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MADL.ToString().Contains(searchString));
            }
            return model.OrderBy(x => x.MAPT).ToPagedList(page, pageSize);
        }

        public long Insert(PHIEUTHU entity)
        {
            entity.TINHTRANG = 1;
            db.PHIEUTHUs.Add(entity);
            db.SaveChanges();
            return entity.MAPT;
        }

        public bool Update(PHIEUTHU entity)
        {
            try
            {
                var phieuthu = db.PHIEUTHUs.Where(g => g.MAPT == entity.MAPT).SingleOrDefault();
                phieuthu.MADL = entity.MADL;
                phieuthu.NGAY = entity.NGAY;
                phieuthu.TIEN = entity.TIEN;
                phieuthu.TINHTRANG = entity.TINHTRANG;
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
