using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class HoaHongController : Controller

    {
        // GET: HoaHong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.HoaHongDAO();
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
            var hoahong = new HoaHongDAO().ViewDetail(id);
            return View(hoahong);
        }

        [HttpPost]
        public ActionResult Create(HOAHONG hoahong)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.HoaHongDAO();
                long id = dao.Insert(hoahong);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "HoaHong");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Hoa Hồng Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(HOAHONG hoahong)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.HoaHongDAO();
                var result = dao.Update(hoahong);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "HoaHong");
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
            var dao = new Model.DAO.HoaHongDAO();
            var result = dao.Delete(id);
            return RedirectToAction("Index", "HoaHong");

        }

    }
}