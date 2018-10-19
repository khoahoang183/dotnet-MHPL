using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace QuanLyBanVeSo.Controllers
{
    public class CongNoController : Controller
    {
        // GET: CongNo
        public ActionResult Index(int page = 1, int pageSize = 8)
        {
            var dao = new Model.DAO.CongNoDAO();
            var model = dao.GetAll(page,pageSize);
            return View(model);
        }
    }
}
