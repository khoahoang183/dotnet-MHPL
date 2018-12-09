using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data;
using System.Data.SqlClient;
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
            entity.TINHTRANG = 1;
            object[] parameter =
                {
                new SqlParameter("@MaDL", entity.MADL)
                };
            //entity.SLGIAO= db.Database.ExecuteSqlCommand("PROC_PHANPHOI_CALC_SLGIAO @MADL", parameter);

            double soluongdangki = 0;
            double phantramban = 0;

            IQueryable<SOLUONGDANGKY> modelSOLUONGDANGKY = db.SOLUONGDANGKies.OrderByDescending(x => x.NGAY).Where(x => x.MADL == entity.MADL);
            var itemsSOLUONGDANGKY = modelSOLUONGDANGKY.ToList().FirstOrDefault();
            if (itemsSOLUONGDANGKY != null)
                soluongdangki = Convert.ToInt32(itemsSOLUONGDANGKY.SLDANGKY);
            else
                soluongdangki = 0;

            IQueryable<PHANPHOI> modelPHANPHOI = db.PHANPHOIs.OrderByDescending(x => x.NGAY).Where(x => x.MADL == entity.MADL).Where(x => x.SLBAN != 0);
            var itemsPHANPHOI = modelPHANPHOI.Take(3).ToList();
            double c = 0;
            foreach (var item in itemsPHANPHOI)
            {
                phantramban += Convert.ToDouble(item.SLBAN) / Convert.ToDouble(item.SLGIAO);
                c=c+1;
            }
            
            if (c == 0)
            {
                entity.SLGIAO = Convert.ToInt32(soluongdangki);
            }
            else
            {
                entity.SLGIAO = Convert.ToInt32(phantramban / c * soluongdangki);
            }

            entity.SLBAN = 0;
            entity.NGAY = DateTime.Today;
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
