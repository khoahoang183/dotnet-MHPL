using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class KetQuaController : Controller

    {
        // GET: KetQua
        public ActionResult Index(DateTime? searchDate,string searchString, int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.KetQuaDAO();                             
            var model = dao.listAllPaging(searchDate, searchString, page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            SetViewBagVeSo();
            SetViewBagGiai();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ketqua = new KetQuaDAO().ViewDetail(id);
            
            SetViewBagVeSo();
            SetViewBagGiai();
            return View(ketqua);
        }

        [HttpPost]
        public ActionResult Create(KETQUA ketqua)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.KetQuaDAO();
                long id = dao.Insert(ketqua);
                if (id > 0) // if insert success, back to index
                {
                    return RedirectToAction("Index", "KetQua");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Kết Quả Thất Bại!");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(KETQUA ketqua)
        {
            if (ModelState.IsValid)
            {
                var dao = new Model.DAO.KetQuaDAO();
                var result = dao.Update(ketqua);
                if (result) // if update success, back to index
                {
                    return RedirectToAction("Index", "KetQua");
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
            var dao = new Model.DAO.KetQuaDAO();
            var result = dao.Delete(id);
            return RedirectToAction("Index", "KetQua");

        }

        public void SetViewBagGiai(long? selectedID = null)
        {
            var dao = new GiaiDAO();
            ViewBag.MaGiai = new SelectList(dao.GetAll(), "MaGiai", "Ten", selectedID);
        }

        public void SetViewBagVeSo(long? selectedID = null)
        {
            var dao = new VeSoDAO();
            ViewBag.MaVS = new SelectList(dao.GetAll(), "MaVS", "Tinh", selectedID);
        }

    }
}