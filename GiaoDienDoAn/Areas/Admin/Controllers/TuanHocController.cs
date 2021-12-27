using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class TuanHocController : Controller
    {
        // GET: Admin/TuanHoc
        public ActionResult Index()
        {
            var dao = new THOIKHOABIEUDAO();
            var model = dao.listTuan();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Index", "TuanHoc");
        }
        [HttpPost]
        public ActionResult Create(TBL_Tuan user, int? TrangThai)
        {
            if (ModelState.IsValid)
            {
                var dao = new THOIKHOABIEUDAO();
                var db = new QLGVDBContext();
                DateTime ngay = Convert.ToDateTime(user.TuNgay);
                //kiếm tra userName trong list có trùng với user nhập vào k
                if (dao.Insert(user, ngay, Convert.ToInt32(user.TrangThai)))
                {
                    //thông báo cho người dùng đã thêm user thành công
                   
                    return RedirectToAction("Index", "TuanHoc");
                }
                else
                {
                    return RedirectToAction("Index", "TuanHoc");
                }
            }
            return View("Index", "TuanHoc");
        }
        public static long makhoa;
        [HttpGet]
        public ActionResult Edit(long MaKhoa)
        {
        
            var khoa = new THOIKHOABIEUDAO().ViewDetailTuan(MaKhoa);
            makhoa = MaKhoa;
            return View(khoa);
        }

        [HttpPost]
        public ActionResult Edit(TBL_Tuan tbl_tuan)
        {
            if (ModelState.IsValid)
            {
                long m = makhoa;
      
                var dao = new THOIKHOABIEUDAO();

                var res = dao.UpdateTuan(tbl_tuan, makhoa);

                if (res)
                {
                    return RedirectToAction("Index", "TuanHoc");
                }
                else
                {

                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }
            return View("Index", "TuanHoc");
        }
    }
}