using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class BoMon_NganhController : Controller
    {
        // GET: Admin/BoMon_Nganh
        public ActionResult Index(string searchString)
        {
            var dao = new BOMON_CHUYENNGANHDAO();
            var model = dao.getAllList(searchString);
            SetViewBag();
            return View(model);
        }
        //thêm chuyên ngành mới
        [HttpGet]
        public ActionResult CreateCN()
        {
            SetViewBag();
            return View("Index", "BoMon_Nganh");
        }
        [HttpPost]
        public ActionResult CreateCN(TBL_ChuyenNganh user)
        {
            if (ModelState.IsValid)
            {
                var dao = new BOMON_CHUYENNGANHDAO();
                var db = new QLGVDBContext();
                SetViewBag();
                //kiếm tra userName trong list có trùng với user nhập vào k
                if (dao.InsertCN(user))
                {
                    //thông báo cho người dùng đã thêm user thành công
                    ModelState.AddModelError("", "Thêm Chuyên Ngành thành công.");
                    return RedirectToAction("Index", "BoMon_Nganh");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Chuyên Ngành không thành công.");
                }
            }
            return View("Index", "BoMon_Nganh");
        }
        //Thêm môn học mới
        [HttpGet]
        public ActionResult CreateBM()
        {
            SetViewBag();
            return View("Index", "BoMon_Nganh");
        }
        [HttpPost]
        public ActionResult CreateBM(TBL_MonHoc user)
        {
            if (ModelState.IsValid)
            {
                var dao = new BOMON_CHUYENNGANHDAO();
                var db = new QLGVDBContext();
                SetViewBag();
                //kiếm tra userName trong list có trùng với user nhập vào k
                if (dao.InsertBM(user))
                {
                    //thông báo cho người dùng đã thêm user thành công
                    ModelState.AddModelError("", "Thêm Môn Học thành công.");
                    return RedirectToAction("Index", "BoMon_Nganh");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Môn Học không thành công.");
                }
            }
            return View("Index", "BoMon_Nganh");
        }
        public static long mamonhoc;
        //chỉnh sửa môn học
        [HttpGet]
        public ActionResult Edit(long maMonHoc)
        {
            SetViewBag();
            var khoa = new BOMON_CHUYENNGANHDAO().ViewDetail(maMonHoc);
            mamonhoc = maMonHoc;
            return View(khoa);
        }
        [HttpPost]
        public ActionResult Edit(TBL_MonHoc tbl_MonHoc)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                var dao = new BOMON_CHUYENNGANHDAO();
                var res = dao.Update(tbl_MonHoc, mamonhoc);
                if (res)
                {
                    return View("Index", "BoMon_Nganh");

                } 
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Chỉnh sửa thất bại!!!');</script>");
                }
            }
            return View("Index", "BoMon_Nganh");
        }

        public ActionResult Delete()
        {
            return View("Index", "BoMon_Nganh");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {

            var gv = new BOMON_CHUYENNGANHDAO().Delete(id);
            if (gv)
            {
                return View("Index", "BoMon_Nganh");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");

            }

            return View("Index");

        }
        public ActionResult DeleteCN()
        {
            return View("Index", "BoMon_Nganh");
        }
        [HttpDelete]
        public ActionResult DeleteCN(int id)
        {

            var gv = new BOMON_CHUYENNGANHDAO().DeleteCN(id);
            if (gv)
            {
                return View("Index", "BoMon_Nganh");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");

            }

            return View("Index");

        }

        //load Chuyên ngành lên dropdownlist
        public void SetViewBag(long? id = null, String search = null)
        {
            var dao = new BOMON_CHUYENNGANHDAO();
            ViewBag.MaChuyenNganh= new SelectList(dao.getAllListCN(search), "MaChuyenNganh", "TenChuyenNganh", id);
        }
    }
}