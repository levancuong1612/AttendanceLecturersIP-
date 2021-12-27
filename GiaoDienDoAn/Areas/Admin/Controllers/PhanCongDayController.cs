using CSDL.DAO;
using CSDL.EF;
using CSDL.ViewModel;
using GiaoDienDoAn.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class PhanCongDayController : Controller
    {
        // GET: Admin/PhanCongDay
        QLGVDBContext db = new QLGVDBContext();
        public ActionResult Index(string searchString,string TenHocKy)
        {
            string x = searchString;
            var dao = new PHANCONGDAYDAO();
            var model = dao.listAllPhanCong(searchString, TenHocKy);
            SetViewBag();
           SetViewBag2();
            SetViewBag3();
        
            SetViewBag5();
      
            return View(model);
         
        }
        public JsonResult getListCTK(long? maLop = null)
        {

            db.Configuration.ProxyCreationEnabled = false;
            var dao = new CHUONGTRINHKHUNGDAO();
            
           
         var   list = dao.listallGV(maLop);
           
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getListMonHoc(long? maCTK=null)
        {
           
            db.Configuration.ProxyCreationEnabled = false;
            var dao =new  CHUONGTRINHKHUNGDAO();


            var list = dao.listCTK(maCTK);
           
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewBag2();
            SetViewBag3();
            SetViewBag4();
            return View("Index", "PhanCongDay");
        }
        [HttpPost]
        public ActionResult Create(TBL_PhanCongDay user)
        {
            if (ModelState.IsValid)
            {
                var dao = new PHANCONGDAYDAO();
                var db = new QLGVDBContext();
                SetViewBag();
                SetViewBag2();
                SetViewBag3();
                SetViewBag4();
                if (dao.Insert(user))
                {
                    //thông báo cho người dùng đã thêm user thành công
                    ModelState.AddModelError("", "Thêm thành công.");
                    return RedirectToAction("Index", "PhanCongDay");
                }
                else
                {
                    this.AddNotification("Giảng viên không được dạy cùng 1 môn của 1 lớp trong 1 học kỳ", NotificationType.ERROR);
                    return RedirectToAction("Index", "PhanCongDay");
                }
            }

            return View("Index", "PhanCongDay");
        }

        public static long mapc;
        //thay đổi phân công dạy
        [HttpGet]
        public ActionResult Edit(long maPC)
        {
            SetViewBag();
            SetViewBag2();
            SetViewBag3();
            SetViewBag4();
            var Lop = new PHANCONGDAYDAO().ViewDetail(maPC);
            mapc = maPC;
            return View(Lop);
        }
        [HttpPost]
        public ActionResult Edit(TBL_PhanCongDay tBL_PhanCongDay)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                SetViewBag2();
                SetViewBag3();
                SetViewBag4();
                var dao = new PHANCONGDAYDAO();
                var res = dao.Update(tBL_PhanCongDay, mapc);
                if (res)
                {
                    this.AddNotification("Cập nhật thông tin thành công", NotificationType.INFO);
                    return RedirectToAction("Index", "PhanCongDay");

                }
                else
                {
                    this.AddNotification("Giảng viên không được dạy cùng 1 môn của 1 lớp trong 1 học kỳ", NotificationType.ERROR);
                    return RedirectToAction("Index", "PhanCongDay");
                }
            }
            return View("Index", "PhanCongDay");
        }


        public ActionResult Delete()
        {
            return View("Index", "PhanCongDay");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            var gv = new PHANCONGDAYDAO().Delete(id);
            if (gv)
            {
                return View("Index", "PhanCongDay");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");

            }

            return View("Index");

        }


        public void SetViewBag(long? id = null, string searchString = null)
        {
            var dao = new GIANGVIENDAO();


            ViewBag.MaGiangVien = new SelectList(dao.listallGV(searchString), "MaGV", "TenGiangVien", id);

        }
        public void SetViewBag4(long? id = null, string searchString = null)
        {
            var dao = new BOMON_CHUYENNGANHDAO();


            ViewBag.MaMonHoc = new SelectList(dao.getAllListBM(searchString), "MaMonHoc", "TenMonHoc", id);

        }
        public void SetViewBag5(long? id = null, string searchString = null)
        {
            var dao = new HOCKY_LOPDAO();
            ViewBag.TenHocKy = new SelectList(dao.getAllListHK(), "TenHocKy", "TenHocKy", id);

        }
        public void SetViewBag2(long? id = null, string searchString = null)
        {
            var dao2 = new HOCKY_LOPDAO();
            ViewBag.MaLop = new SelectList(dao2.getAllListLop(searchString), "MaLop", "TenLop", id);

        }
        public void SetViewBag6(long? id = null, long? maLop=null)
        {
            var dao2 = new CHUONGTRINHKHUNGDAO();
            ViewBag.MaLop = new SelectList(dao2.listallGV(maLop), "MaCTK", "TenLop", id);

        }
        public void SetViewBag3(long? id = null)
        {
            var dao = new HOCKY_LOPDAO();
            ViewBag.MaHocKy = new SelectList(dao.getAllListHK(), "MaHocKy", "TenHocKy", id);
        }

    }
}