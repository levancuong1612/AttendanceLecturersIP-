using CSDL.DAO;
using CSDL.EF;
using GiaoDienDoAn.Areas.Admin.Common;
using GiaoDienDoAn.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        QLGVDBContext db = new QLGVDBContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TAIKHOANDAO();
                var res = dao.Login(model.TaiKhoan, MaHoa.MD5Hash(model.MatKhau));
                if (res)
                {
                    var user = dao.getbyid(model.TaiKhoan);
                    var userSession = new AdminLogin();
                    userSession.TaiKhoan = user.TaiKhoan;
                    userSession.ID = user.id;
                    var da = db.TBL_GiangVien.Find(user.MaGiangVien);
                    userSession.HinhAnh = da.HinhAnh;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
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