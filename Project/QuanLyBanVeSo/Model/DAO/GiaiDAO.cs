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
    public class GiaiDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public GiaiDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public GIAI GetByID(int MaGiai)
        {
            return db.GIAIs.SingleOrDefault(x => x.MAGIAI == MaGiai);
        }

       
        public List<GIAI> GetAll()
        {
            return db.GIAIs.ToList();
        }

        public GIAI ViewDetail(int MaGiai)
        {
            return db.GIAIs.Find(MaGiai);
        }

        public IEnumerable<GIAI> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<GIAI> model = db.GIAIs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TEN.Contains(searchString));
            }
            return model.OrderBy(x => x.MAGIAI).ToPagedList(page,pageSize);
        }

        public long Insert(GIAI entity)
        {
            db.GIAIs.Add(entity);
            db.SaveChanges();
            return entity.MAGIAI;
        }

        public bool Update(GIAI entity)
        {
            try
            {
                var giai = db.GIAIs.Where(g => g.MAGIAI == entity.MAGIAI).SingleOrDefault();
                giai.TEN = entity.TEN;
                giai.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int MaGiai)
        {
            var user = db.GIAIs.Find(MaGiai);
            int? status = user.TINHTRANG;
            if (status == 1)
            {
                status = 0;
                user.TINHTRANG = status;
                db.SaveChanges();
                return true;
            }
            else
            {
                if (status == 0)
                {
                status = 1;
                user.TINHTRANG = status;
                db.SaveChanges();
                return true;
                }
            }           
            return false;
        }
    }
}
