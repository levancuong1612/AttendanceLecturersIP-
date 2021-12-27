using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Controllers
{
    public class ThoiKhoaBieuController : Controller
    {
        QLGVDBContext db = new QLGVDBContext();
        // GET: ThoiKhoaBieu
        public ActionResult Index(long?MaGV, int? ts)
        {
            if (ts == null)
            {
                ts = 0;
            }
            var dao = new THOIKHOABIEUDAO();
            var model = dao.listCTTKBGV(MaGV, ts);
            return View(model);
           
        }
        static long? maHK;
        public ActionResult ChiTietDiemDanhUS(long? MaDD)
        {
            DateTime dt = DateTime.Now;
            var dao = new DIEMDANHDAO();
            var hocKy = db.TBL_HocKy.Where(x => x.ThoiGianBD <= dt && x.ThoiGianKT >= dt);
            long MaHK = hocKy.First().MaHocKy;
            var model = dao.getAllListDiemDanhGV(MaDD, MaHK);
            return View(model);
        }
    }
}