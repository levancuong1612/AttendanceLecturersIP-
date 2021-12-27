using CSDL.DAO;
using CSDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
   
    public class PhongHocController : Controller
    {
       
        // GET: Admin/PhongHoc
        [HttpGet]
        public ActionResult Index(string searchString)
        {
            this.ModelState.Clear();
            string x = searchString;
            var dao = new PHONGHOCDAO();
            var model = dao.getalllist(searchString);
            ViewBag.listPhongHoc = dao.getalllist(searchString);
            return View();
        }
       
        [HttpGet]
        public ActionResult Create()
        {
            
            return View("Index","PhongHoc");
        }

        [HttpPost]
        public ActionResult Create(TBL_PhongHoc user)
        {
            
            if (ModelState.IsValid)
            {
                var dao = new PHONGHOCDAO();
                var db = new QLGVDBContext();
                

             
                //kiếm tra userName trong list có trùng với user nhập vào k
                
                    
                    if (dao.Insert(user))
                    {
                    //thông báo cho người dùng đã thêm user thành công

                    ModelState.AddModelError("", "Thêm user thành công.");


                    return RedirectToAction("Index", "PhongHoc");   

                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm user không thành công.");
                    }
                


            }
           
            return View("Index","PhongHoc");
        }
        public static long ma;
       [HttpGet]
      public ActionResult Edit(long maphong)
        {
            var ph = new PHONGHOCDAO().ViewDetail(maphong);
            ma = maphong;
            return View(ph);
        }
        [HttpPost]
        public ActionResult Edit(TBL_PhongHoc info)
        {
            if (ModelState.IsValid)
            {
                var dao = new PHONGHOCDAO();
                var res = dao.Update(info,ma);
                if (res)
                {
                    return RedirectToAction("Index", "PhongHoc");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công.");
                }
            }
            return View("Index");
        }
        public ActionResult xoa()
        {
            return View("Index", "PhongHoc");
        }
        [HttpDelete]
        public ActionResult xoa(int id)
        {

            var gv = new PHONGHOCDAO().xoa(id);
            if (gv)
            {
                return View("Index", "PhongHoc");
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công.");
                
            }

            return View("Index");

        }
    }
}