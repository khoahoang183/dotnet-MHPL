using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class PhieuChiController : Controller
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.PhieuChiDAO();
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
            var phieuchi = new PhieuChiDAO().ViewDetail(id);
            return View(phieuchi);
        }

        [HttpPost]
        public ActionResult Create(PHIEUCHI phieuchi)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.PhieuChiDAO();
                phieuchi.NGAY = DateTime.Today;
                long id = dao.Insert(phieuchi);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "PhieuChi");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Số Lượng Đăng Ký Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(PHIEUCHI phieuchi)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.PhieuChiDAO();
                var result = dao.Update(phieuchi);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "PhieuChi");
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