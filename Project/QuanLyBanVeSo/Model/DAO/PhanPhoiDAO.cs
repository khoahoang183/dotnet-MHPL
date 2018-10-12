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
    public class PhanPhoiDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public PhanPhoiDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public PHANPHOI GetByID(int MAPP)
        {
            return db.PHANPHOIs.SingleOrDefault(x => x.MAPP == MAPP);
        }

        public PHANPHOI ViewDetail(int MAPP)
        {
            return db.PHANPHOIs.Find(MAPP);
        }
        public IEnumerable<PHANPHOI> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<PHANPHOI> model = db.PHANPHOIs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NGAY.ToString().Contains(searchString));
            }
            return model.OrderBy(x => x.MAPP).ToPagedList(page, pageSize);
        }

        public long Insert(PHANPHOI entity)
        {
            db.PHANPHOIs.Add(entity);
            db.SaveChanges();
            return entity.MAPP;
        }

        public bool Update(PHANPHOI entity)
        {
            try
            {
                var pp = db.PHANPHOIs.Where(g => g.MAPP == entity.MAPP).SingleOrDefault();
                pp.MAVS = entity.MAVS;
                pp.MADL = entity.MADL;
                pp.NGAY = entity.NGAY;
                pp.SLGIAO = entity.SLGIAO;
                pp.SLBAN = entity.SLBAN;
                pp.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int MAPP)
        {
            var pp = db.PHANPHOIs.Find(MAPP);
            int? status = pp.TINHTRANG;
            if (status == 1)
            {
                status = 0;
                pp.TINHTRANG = status;
                db.SaveChanges();
                return true;
            }
            else
            {
                if (status == 0)
                {
                    status = 1;
                    pp.TINHTRANG = status;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
