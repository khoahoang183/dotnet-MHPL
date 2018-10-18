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
    public class KetQuaDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public KetQuaDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public KETQUA GetByID(int MaKetQua)
        {
            return db.KETQUAs.SingleOrDefault(x => x.MAKQ == MaKetQua);
        }

        public KETQUA ViewDetail(int MaKetQua)
        {
            return db.KETQUAs.Find(MaKetQua);
        }
        public IEnumerable<KETQUA> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<KETQUA> model = db.KETQUAs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.SOTRUNG.Contains(searchString));
            }
            return model.OrderBy(x => x.MAKQ).ToPagedList(page, pageSize);
        }

        public long Insert(KETQUA entity)
        {
            entity.TINHTRANG = 1;
            entity.NGAY = DateTime.Today;
            db.KETQUAs.Add(entity);
            db.SaveChanges();
            return entity.MAKQ;
        }

        public bool Update(KETQUA entity)
        {
            try
            {
                var ketqua = db.KETQUAs.Where(g => g.MAKQ == entity.MAKQ).SingleOrDefault();
                ketqua.MAVS = entity.MAVS;
                ketqua.NGAY = entity.NGAY;
                ketqua.MAGIAI = entity.MAGIAI;
                ketqua.SOTRUNG = entity.SOTRUNG;
                ketqua.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int MaKetQua)
        {
            var user = db.KETQUAs.Find(MaKetQua);
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
