using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class PhieuThuController : Controller
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.PhieuThuDAO();
            var model = dao.listAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var phieuthu = new PhieuThuDAO().ViewDetail(id);
            return View(phieuthu);
        }

        [HttpPost]
        public ActionResult Create(PHIEUTHU phieuthu)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.PhieuThuDAO();
                phieuthu.NGAY = DateTime.Today;
                long id = dao.Insert(phieuthu);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "PhieuThu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Số Lượng Đăng Ký Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(PHIEUTHU phieuthu)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.PhieuThuDAO();
                var result = dao.Update(phieuthu);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "PhieuThu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại!");
                }
            }
            return View("Index");
        }

        public void SetViewBag(long? selectedID = null)
        {
            var dao = new DaiLyDAO();
            ViewBag.MaDL = new SelectList(dao.GetAll(), "MaDL", "Ten", selectedID);
        }
    }
}