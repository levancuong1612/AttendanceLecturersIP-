using CSDL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            var dao = new TAIKHOANDAO();
            var model = dao.listAllTaiKhoan();
            return View(model);
        }
    }
}