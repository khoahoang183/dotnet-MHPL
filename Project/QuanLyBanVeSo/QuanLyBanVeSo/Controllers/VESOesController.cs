using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class VeSoController : Controller

    {
        // GET: Giai
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.VeSoDAO();
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
            var veso = new VeSoDAO().ViewDetail(id);
            return View(veso);
        }

        [HttpPost]
        public ActionResult Create(VESO veso)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.VeSoDAO();
                long id = dao.Insert(veso);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "VeSo");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Giải Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(VESO veso)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.VeSoDAO();
                var result = dao.Update(veso);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "VeSo");
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
            var dao = new Model.DAO.VeSoDAO();
            var result = dao.Delete(id);
            return RedirectToAction("Index", "VeSo");

        }

    }
}