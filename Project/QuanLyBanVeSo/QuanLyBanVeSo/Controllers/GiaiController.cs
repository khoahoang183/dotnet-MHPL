using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class GiaiController : Controller

    {
        // GET: Giai
        public ActionResult Index(string searchString, int page=1, int pageSize= 8 )
        {
            var dao = new Model.DAO.GiaiDAO();
            var model = dao.listAllPaging(searchString,page,pageSize);
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
            var giai = new GiaiDAO().ViewDetail(id);
            return View(giai);
        }

        [HttpPost]
        public ActionResult Create(GIAI giai)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.GiaiDAO();
                long id = dao.Insert(giai);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "Giai");
                }
                else
                {
                    ModelState.AddModelError("","Thêm Giải Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(GIAI giai)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.GiaiDAO();
                var result = dao.Update(giai);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "Giai");
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
            var dao = new Model.DAO.GiaiDAO();
            var result = dao.Delete(id);
            return RedirectToAction("Index", "Giai");

        }

    }
}