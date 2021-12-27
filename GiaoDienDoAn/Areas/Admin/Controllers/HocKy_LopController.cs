using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class HocKy_LopController : Controller
    {
        // GET: Admin/HocKy_Lop
        public ActionResult Index(string searchString)
        {
            SetViewBag2(); SetViewBag();
            var dao = new HOCKY_LOPDAO();
            var model = dao.getAllListLop(searchString);
        
            return View(model);
        }

        //thêm chuyên ngành mới
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag2();
            SetViewBag();
            return View("Index", "HocKy_Lop");
        }
        [HttpPost]
        public ActionResult Create(TBL_Lop user)
        {
            if (ModelState.IsValid)
            {
                var dao = new HOCKY_LOPDAO();
                var db = new QLGVDBContext();
                SetViewBag();
                SetViewBag2();
                //kiếm tra userName trong list có trùng với user nhập vào k
                if (dao.InsertLop(user))
                {
                    //thông báo cho người dùng đã thêm user thành công
                    ModelState.AddModelError("", "Thêm Chuyên Ngành thành công.");
                    return RedirectToAction("Index", "HocKy_Lop");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Chuyên Ngành không thành công.");
                }
            }
            return View("Index", "HocKy_Lop");
        }
        public static long malop;
        //chỉnh sửa Lớp
        [HttpGet]
        public ActionResult Edit(long maLop)
        {
            SetViewBag();
            SetViewBag2();
            var Lop = new HOCKY_LOPDAO().ViewDetail(maLop);
            malop= maLop;
            return View(Lop);
        }
        [HttpPost]
        public ActionResult Edit(TBL_Lop tbl_Lop)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                SetViewBag2();
                var dao = new HOCKY_LOPDAO();
                var res = dao.Update(tbl_Lop, malop);
                if (res)
                {
                    return RedirectToAction("Index", "HocKy_Lop");

                }
                else
                {
                    ModelState.AddModelError("", "Thêm Chuyên Ngành không thành công.");
                }
            }
            return View("Index", "HocKy_Lop");
        }

        public ActionResult Delete()
        {
            return View("Index", "HocKy_Lop");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            var gv = new HOCKY_LOPDAO().Delete(id);
            if (gv)
            {
                return View("Index", "HocKy_Lop");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");

            }

            return View("Index");

        }

        public void SetViewBag(long? id = null, String search = null)
        {
            var dao = new BOMON_CHUYENNGANHDAO();
            ViewBag.MaChuyenNganh = new SelectList(dao.getAllListCN(search), "MaChuyenNganh", "TenChuyenNganh", id);
        }
        public void SetViewBag2(long? id = null, String search = null)
        {
            var dao = new KHOADAO();
            ViewBag.MaKhoa = new SelectList(dao.getalllist(search), "MaKhoa", "TenKhoa", id);
        }
    }
}