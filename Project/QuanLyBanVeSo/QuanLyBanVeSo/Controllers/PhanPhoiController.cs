using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class PhanPhoiController : Controller

    {
        // GET: PhanPhoi
        public ActionResult Index(string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.PhanPhoiDAO();
            var model = dao.listAllPaging(searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBagDaiLy();
            SetViewBagVeSo();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {   
            var pp = new PhanPhoiDAO().ViewDetail(id);
            SetViewBagDaiLy();
            SetViewBagVeSo();
            return View(pp);
        }

        [HttpPost]
        public ActionResult Create(PHANPHOI pp)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.PhanPhoiDAO();
                long id = dao.Insert(pp);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "PhanPhoi");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Phân Phối Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(PHANPHOI pp)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.PhanPhoiDAO();
                var result = dao.Update(pp);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "PhanPhoi");
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
            var dao = new Model.DAO.PhanPhoiDAO();
            var result = dao.Delete(id);
            return RedirectToAction("Index", "PhanPhoi");

        }
        public void SetViewBagDaiLy(long? selectedID = null)
        {
            var dao = new DaiLyDAO();
            ViewBag.MaDL = new SelectList(dao.GetAll(), "MaDL", "MaDL", selectedID);
        }

        public void SetViewBagVeSo(long? selectedID = null)
        {
            var dao = new VeSoDAO();
            ViewBag.MaVS = new SelectList(dao.GetAll(), "MaVS", "MaVS", selectedID);
        }

    }
}