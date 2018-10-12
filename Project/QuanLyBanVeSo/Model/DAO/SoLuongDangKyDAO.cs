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
    public class SoLuongDangKyDAO
    {
        QuanLyBanVeSoDbContext db = null;
        public SoLuongDangKyDAO()
        {
            db = new QuanLyBanVeSoDbContext();
        }

        public SOLUONGDANGKY GetByID(int MaDL)
        {
            return db.SOLUONGDANGKies.SingleOrDefault(x => x.MASLDK == MaDL);
        }

        public SOLUONGDANGKY ViewDetail(int MaDL)
        {
            return db.SOLUONGDANGKies.Find(MaDL);
        }
        public IEnumerable<SOLUONGDANGKY> listAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<SOLUONGDANGKY> model = db.SOLUONGDANGKies;
            if (!string.IsNullOrEmpty(searchString))
            {             
                model = model.Where(x => x.MADL.ToString().Contains(searchString));
            }
            return model.OrderBy(x => x.MASLDK).ToPagedList(page, pageSize);
        }

        public long Insert(SOLUONGDANGKY entity)
        {
            db.SOLUONGDANGKies.Add(entity);
            db.SaveChanges();
            return entity.MASLDK;
        }

        public bool Update(SOLUONGDANGKY entity)
        {
            try
            {
                var soluongdangky = db.SOLUONGDANGKies.Where(g => g.MASLDK == entity.MASLDK).SingleOrDefault();
                soluongdangky.MADL = entity.MADL;
                soluongdangky.NGAY = entity.NGAY;
                soluongdangky.SLDANGKY = entity.SLDANGKY;
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
