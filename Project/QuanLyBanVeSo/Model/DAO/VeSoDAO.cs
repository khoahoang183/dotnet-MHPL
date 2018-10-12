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
    public class VeSoDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public VeSoDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public VESO GetByID(int MaVS)
        {
            return db.VESOes.SingleOrDefault(x => x.MAVS == MaVS);
        }

        public VESO ViewDetail(int MaVS)
        {
            return db.VESOes.Find(MaVS);
        }
        public IEnumerable<VESO> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<VESO> model = db.VESOes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TINH.Contains(searchString));
            }
            return model.OrderBy(x => x.MAVS).ToPagedList(page, pageSize);
        }

        public long Insert(VESO entity)
        {
            db.VESOes.Add(entity);
            db.SaveChanges();
            return entity.MAVS;
        }

        public bool Update(VESO entity)
        {
            try
            {
                var veso = db.VESOes.Where(g => g.MAVS == entity.MAVS).SingleOrDefault();
                veso.TINH = entity.TINH;
                veso.TINHTRANG = entity.TINHTRANG;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int MaVS)
        {
            var veso = db.VESOes.Find(MaVS);
            int? status = veso.TINHTRANG;
            if (status == 1)
            {
                status = 0;
                veso.TINHTRANG = status;
                db.SaveChanges();
                return true;
            }
            else
            {
                if (status == 0)
                {
                    status = 1;
                    veso.TINHTRANG = status;
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
