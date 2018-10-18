using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class SoLuongDangKyController : Controller

    {
        // GET: SoLuongDangKy
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.SoLuongDangKyDAO();
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
            var soluongdangky = new SoLuongDangKyDAO().ViewDetail(id);
            return View(soluongdangky);
        }

        [HttpPost]
        public ActionResult Create(SOLUONGDANGKY soluongdangky)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.SoLuongDangKyDAO();
                soluongdangky.NGAY = DateTime.Today;
                long id = dao.Insert(soluongdangky);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "SoLuongDangKy");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Số Lượng Đăng Ký Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(SOLUONGDANGKY soluongdangky)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.SoLuongDangKyDAO();
                var result = dao.Update(soluongdangky);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "SoLuongDangKy");
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
            ViewBag.MaDL = new SelectList(dao.GetAll(), "MaDL", "MaDL", selectedID);
        }


    }
}