using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class DaiLyController : Controller

    {
        // GET: DaiLy
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.DaiLyDAO();
            var model = dao.listAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var daily = new DaiLyDAO().ViewDetail(id);
            return View(daily);
        }

        [HttpPost]
        public ActionResult Create(DAILY daily)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.DaiLyDAO();
                long id = dao.Insert(daily);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "DaiLy");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Đại lý Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(DAILY daily)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.DaiLyDAO();
                var result = dao.Update(daily);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "DaiLy");
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new Model.DAO.DaiLyDAO();
            var result = dao.Delete(id);
            return RedirectToAction("Index", "DaiLy");

        }

    }
}