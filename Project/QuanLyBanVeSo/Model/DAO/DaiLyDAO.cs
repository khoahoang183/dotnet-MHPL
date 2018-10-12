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
    public class DaiLyDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public DaiLyDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public DAILY GetByID(int MaDL)
        {
            return db.DAILies.SingleOrDefault(x => x.MADL == MaDL);
        }

        public DAILY ViewDetail(int MaDL)
        {
            return db.DAILies.Find(MaDL);
        }

        public List<DAILY> GetAll()
        {
            return db.DAILies.ToList();
        }
        public IEnumerable<DAILY> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DAILY> model = db.DAILies;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TEN.Contains(searchString));
            }
            return model.OrderBy(x => x.MADL).ToPagedList(page, pageSize);
        }

        public long Insert(DAILY entity)
        {
            db.DAILies.Add(entity);
            db.SaveChanges();
            return entity.MADL;
        }

        public bool Update(DAILY entity)
        {
            try
            {
                var daily = db.DAILies.Where(g => g.MADL == entity.MADL).SingleOrDefault();
                daily.TEN = entity.TEN;
                daily.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int MaDL)
        {
            var user = db.DAILies.Find(MaDL);
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
