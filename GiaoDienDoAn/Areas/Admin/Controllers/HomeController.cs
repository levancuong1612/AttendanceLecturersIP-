using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        QLGVDBContext db = new QLGVDBContext();
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now;
            var data = db.TBL_HocKy.Where(x => x.ThoiGianBD <= dt && x.ThoiGianKT >= dt);
            var dao = new DIEMDANHDAO();
            long? ma = data.First().MaHocKy;
            var model = dao.TrangChu(ma);
            return View(model);
        }
        public ActionResult Table()
        {
            return View();
        }
    }
}