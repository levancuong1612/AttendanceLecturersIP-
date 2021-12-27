using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class KhoaController : Controller
    {
        // GET: Admin/Khoa
        public static List<TBL_PhongHoc> list = new List<TBL_PhongHoc>();
        public ActionResult Index(string searchString)
        {
           
            var dao = new KHOADAO();
            var model = dao.getalllist(searchString);
            SetViewBag();
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View("Index","Khoa");
        }



        [HttpPost]
        public ActionResult Create(TBL_Khoa user)
        {

            if (ModelState.IsValid)
            {
                var dao = new KHOADAO();
                var db = new QLGVDBContext();
                SetViewBag();


                //kiếm tra userName trong list có trùng với user nhập vào k


                if (dao.Insert(user))
                {
                    //thông báo cho người dùng đã thêm user thành công

                    ModelState.AddModelError("", "Thêm Khoa thành công.");


                    return RedirectToAction("Index", "Khoa");

                }
                else
                {
                    ModelState.AddModelError("", "Thêm Khoa không thành công.");
                }
            }
           
            return View("Index", "Khoa");
        }
        public static long makhoa;
    [HttpGet]
        public ActionResult Edit(long MaKhoa)
        {
            SetViewBag();
            var khoa = new KHOADAO().ViewDetail(MaKhoa);
            makhoa = MaKhoa;
            return View(khoa);
        }
       
        [HttpPost]
        public ActionResult Edit(TBL_Khoa tbl_khoa)
        {
            if (ModelState.IsValid)
            {
                long m = makhoa;
                SetViewBag();
                var dao = new KHOADAO();
               
                var res = dao.Update(tbl_khoa,makhoa);
                
                if (res)
                {
                    return RedirectToAction("Index", "Khoa");
                }
                else
                {
                   
                    ModelState.AddModelError("", "Thêm Khoa không thành công.");
                }
            }
            return View("Index", "Khoa");
        }
        public void SetViewBag(long? id=null,String search=null)
        {
            var dao = new PHONGHOCDAO();
            ViewBag.MaPhong = new SelectList(dao.getalllist(search), "MaPhong", "TenPhong", id);
        }
        public ActionResult xoa()
        {
            return View("Index", "Khoa");
        }
        [HttpDelete]
        public ActionResult xoa(int id)
        {
            
            var gv = new KHOADAO().xoa(id);
            if (gv)
            {
                return View("Index", "Khoa");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");

            }

            return View("Index");

        }

    }
}