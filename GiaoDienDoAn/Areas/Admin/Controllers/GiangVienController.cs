using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class GiangVienController : Controller
    {
        // GET: Admin/GiangVien
        public ActionResult Index(string searchString)
        {
            
            var dao = new GIANGVIENDAO();
            var model = dao.listallGV(searchString);
            SetViewBag();
            SetViewBag2();
            SetViewBag3();
            SetViewBag4();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewBag2();
            SetViewBag3();
            return View("Index","GiangVien");
        }
        [HttpPost]
        public ActionResult Create(TBL_GiangVien user, HttpPostedFileBase file)
        {

            

            if (ModelState.IsValid)
            {
                var dao = new GIANGVIENDAO();
                var db = new QLGVDBContext();
                SetViewBag();
                SetViewBag2();
                SetViewBag3();
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Img"), pic);
                file.SaveAs(path);


                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                //kiếm tra userName trong list có trùng với user nhập vào k


                if (dao.Insert(user,pic))
                {
                    //thông báo cho người dùng đã thêm user thành công

                    ModelState.AddModelError("", "Thêm Giảng Viên thành công.");


                    return RedirectToAction("Index", "GiangVien");

                }
                else
                {
                    ModelState.AddModelError("", "Thêm Giảng Viên không thành công.");
                }
            }

           return View("Index","GiangVien");
        }
        public ActionResult ThongTin(int id)
        {
            var gv = new GIANGVIENDAO().chinhSua(id);
            return View(gv);
        }
        public static long ma;
        [HttpGet]
        public ActionResult Edit(long magv)
        {
            var ph = new GIANGVIENDAO().ViewDetail(magv);
            SetViewBag();
            SetViewBag2();
            SetViewBag3();
            ma = magv;
            return View(ph);
        }
        [HttpPost]
        public ActionResult Edit(TBL_GiangVien info, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                SetViewBag2();
                SetViewBag3();
                var dao = new GIANGVIENDAO();

                
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Img"), pic);
                file.SaveAs(path);
                var res = dao.Update(info, ma, pic);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                if (res)
                {
                    return RedirectToAction("Index", "GiangVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }
            return View("Index");
        }


        [HttpGet]
        public ActionResult xoa()
        {
            return View("Index", "GiangVien");
        }
        [HttpDelete]
        public ActionResult xoa(int id)
        {

            var gv = new GIANGVIENDAO().xoa(id);
           
              
                return View();
            
            
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                //thông báo thành công alert-success
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                //thông báo cảnh báo alert-warning
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                //thông báo nguy hiểm alert-danger
                TempData["AlertType"] = "alert-danger";
            }
        }
        public void SetViewBag(long? id = null,string searchString = null)
        {
            var dao = new KHOADAO();
          

            ViewBag.MaKhoa = new SelectList(dao.getalllist(searchString), "MaKhoa", "TenKhoa", id);

        }
        public void SetViewBag4(long? id = null, string searchString = null)
        {
            var dao = new KHOADAO();


            ViewBag.TenKhoa = new SelectList(dao.getalllist(searchString), "TenKhoa", "TenKhoa", id);

        }
        public void SetViewBag2(long? id = null)
        {
            var dao2 = new CHUCVUDAO();
            ViewBag.MaChucVu = new SelectList(dao2.getalllist(), "MaChucVu", "TenChucVu", id);
            
        }
        public void SetViewBag3(long? id=null)
        {
            var dao = new CHUCVUDAO();
            ViewBag.MaBoMon = new SelectList(dao.getlistbomon(), "MaBoMon", "TenBoMon", id);
        }
    
    }
}