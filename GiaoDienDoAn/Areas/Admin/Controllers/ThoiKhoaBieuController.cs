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
    public class ThoiKhoaBieuController : Controller
    {
        QLGVDBContext db = new QLGVDBContext();
        // GET: Admin/ThoiKhoaBieu
        [HttpGet]
        public ActionResult Index(string searchString,string TenPhong)
        {
            var dao = new THOIKHOABIEUDAO();
            var model = dao.getListTKB(searchString, TenPhong);
      
           SetViewBag();
            SetViewBag2();
        
            //SetViewBag1();
            SetViewBag4();
            SetViewBag5();
            SetViewBag6();
            return View(model);
        }
        [HttpGet]
        public ActionResult TKBGV( long? MaGV,int? ts)
        {
            if (ts == null)
            {
                ts = 0;
            }
            var dao = new THOIKHOABIEUDAO();
            var model = dao.listCTTKBGV(MaGV,ts);
            return View(model) ;
        }
        [HttpGet]
        public ActionResult Create()
        {
         
            SetViewBag();
            SetViewBag2();
            //SetViewBag3();
          //  SetViewBag1();
            SetViewBag4();
            SetViewBag5();
            return View("Index", "ThoiKhoaBieu");
        }
        [HttpPost]
        public ActionResult Create(TBL_ChiTietThoiKhoaBieu user)
        {

            if (ModelState.IsValid)
            {
                var dao =new  THOIKHOABIEUDAO();
                var res = dao.InsertCTTKB(user);
                SetViewBag();
                SetViewBag2();
                //SetViewBag3();
              //  SetViewBag1();
                SetViewBag4();
                SetViewBag5();
                if (res)
                {
                    return RedirectToAction("Index", "ThoiKhoaBieu");
                }
                else
                {
                    this.AddNotification("Phân Công Trùng Thời Khóa Biểu!!!", NotificationType.ERROR);
                    return RedirectToAction("Index", "ThoiKhoaBieu");
                }
            }
       

            return View("Index", "ThoiKhoaBieu");
        }
        public static long mapc;
        //thay đổi phân công dạy
        [HttpGet]
        public ActionResult Edit(long maPC)
        {
            SetViewBag();
            SetViewBag2();
            //SetViewBag3();
            SetViewBag1();
            SetViewBag4();
            SetViewBag5();
            var Lop = new THOIKHOABIEUDAO().ViewDetail(maPC);
            mapc = maPC;
            return View(Lop);
        }
        [HttpPost]
        public ActionResult Edit(TBL_ChiTietThoiKhoaBieu tBL_ChiTietThoiKhoaBieu)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                SetViewBag2();
                //SetViewBag3();
                SetViewBag1();
                SetViewBag4();
                SetViewBag5();
                var dao = new THOIKHOABIEUDAO();
                var res = dao.Update(tBL_ChiTietThoiKhoaBieu, mapc);
                if (res)
                {
                    this.AddNotification("Cập nhật thông tin thành công", NotificationType.INFO);
                    return RedirectToAction("Index", "ThoiKhoaBieu");

                }
                else
                {
                    this.AddNotification("Phân công trùng thời khóa biểu", NotificationType.ERROR);
                    return RedirectToAction("Index", "ThoiKhoaBieu");
                }
            }
            return View("Index", "ThoiKhoaBieu");
        }

        public ActionResult Delete()
        {
            return View("Index", "ThoiKhoaBieu");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            var gv = new THOIKHOABIEUDAO().Delete(id);
            if (gv)
            {
                return View("Index", "ThoiKhoaBieu");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");

            }

            return View("Index");

        }
    
        public JsonResult getListGV(long? maGV = null)
        {

            db.Configuration.ProxyCreationEnabled = false;
            var dao = new PHANCONGDAYDAO();

            string magv = maGV.ToString();
            var list = dao.listAllPhanCong(magv,"");

            return Json(list, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult getListNgay(string Tuan =null)
        {

            db.Configuration.ProxyCreationEnabled = false;
            var dao = new THOIKHOABIEUDAO();

            string magv = Tuan;
            var list = dao.listNgay(Tuan);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public void SetViewBag(long? id = null, string searchString = null)
        {
            var dao = new GIANGVIENDAO();


            ViewBag.MaGiangVien = new SelectList(dao.listallGV(searchString), "MaGV", "TenGiangVien", id);

        }
        public void SetViewBag1(long? id = null, string searchString = null)
        {
            var dao = new PHANCONGDAYDAO();

            searchString = "33";
            ViewBag.MaPhanCong = new SelectList(dao.listAllPhanCong(searchString ,""), "MaPhanCong", "GV_MH_LOP", id);

        }
        public void SetViewBag2(long? id = null)
        {
            var dao = new THOIKHOABIEUDAO();


            ViewBag.Tuan = new SelectList(dao.listTuan(), "Tuan", "Tuan", id);

        }
        //public void SetViewBag3(long? id = null)
        //{
        //    var dao = new THOIKHOABIEUDAO();
        //    ViewBag.Ngay = new SelectList(dao.listNgay("Tuần 8"), id);
        //}
        public void SetViewBag4(long? id = null)
        {
            var dao = new THOIKHOABIEUDAO();
            ViewBag.MaTiet = new SelectList(dao.listTietHoc(),"MaTiet","Tiet", id);
        }
        public void SetViewBag5(long? id = null)
        {
            var dao = new PHONGHOCDAO();
            ViewBag.MaPhong = new SelectList(dao.getalllist(""), "MaPhong", "TenPhong", id);
        }
        public void SetViewBag6(long? id = null)
        {
            var dao = new PHONGHOCDAO();
            ViewBag.TenPhong = new SelectList(dao.getalllist(""), "TenPhong", "TenPhong", id);
        }
    }
}
