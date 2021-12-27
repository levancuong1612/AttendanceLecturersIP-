using CSDL.DAO;
using CSDL.EF;
using GiaoDienDoAn.Common;
using GiaoDienDoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GiaoDienDoAn.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login user
        QLGVDBContext db = new QLGVDBContext();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TAIKHOANDAO();
                var res = dao.LoginUser(model.TaiKhoan, MaHoaMD5.MD5Hash(model.MatKhau));
                if (res)
                {
                    var user = dao.getbyid(model.TaiKhoan);
                    var userSession = new UserLogin();
                    userSession.TaiKhoan = user.TaiKhoan;
                    userSession.ID = user.id;
                    userSession.MaGV = user.MaGiangVien;
                    var data = db.TBL_GiangVien.Find(user.MaGiangVien);
                    userSession.HinhAnh = data.HinhAnh;
                    string taikhoan = user.TaiKhoan;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    //Session["TaiKhoan"] = userSession.TaiKhoan;
                    return RedirectToAction("Index", "Home",new { @tk=taikhoan.Trim().ToString()});
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            return View("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
      
    }
}