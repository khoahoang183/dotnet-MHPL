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
    public class HoaHongDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public HoaHongDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public HOAHONG GetByID(int MaHH)
        {
            return db.HOAHONGs.SingleOrDefault(x => x.MAHH == MaHH);
        }

        public HOAHONG ViewDetail(int MaHH)
        {
            return db.HOAHONGs.Find(MaHH);
        }

        public List<HOAHONG> GetAll()
        {
            return db.HOAHONGs.ToList();
        }
        public IEnumerable<HOAHONG> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<HOAHONG> model = db.HOAHONGs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TILE.ToString().Contains(searchString));
            }
            return model.OrderBy(x => x.MAHH).ToPagedList(page, pageSize);
        }

        public long Insert(HOAHONG entity)
        {
            entity.TINHTRANG = 1;
            db.HOAHONGs.Add(entity);
            db.SaveChanges();
            return entity.MAHH;
        }

        public bool Update(HOAHONG entity)
        {
            try
            {
                var hoahong = db.HOAHONGs.Where(g => g.MAHH == entity.MAHH).SingleOrDefault();
                hoahong.TILE = entity.TILE;
                hoahong.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int MaHH)
        {
            var user = db.HOAHONGs.Find(MaHH);
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
