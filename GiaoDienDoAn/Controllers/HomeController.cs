using CSDL.DAO;
using CSDL.EF;
using GiaoDienDoAn.Common;
using GiaoDienDoAn.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Controllers
{
    public class HomeController : BaseController
    {
        QLGVDBContext db = new QLGVDBContext();
        public ActionResult Index(string tk)
        {
      
            var dao1  = new TAIKHOANDAO();
            var model1 = dao1.getbyid(tk);
            idad = GetIPAddress();
            TaiKhoan = tk;
            
         
          var model  =dao1.getView(tk);
            return View(model);
        }
        public static string TaiKhoan;
        [HttpGet]
        public ActionResult Create()
        {
            
            return View("Index", "Home");
        }
        public static string idad;
        public static long? mk;
        [HttpPost]
        public ActionResult Create(long mkgv,long cttkb)
        {
            
            if (ModelState.IsValid)
            {
                var dao =new DIEMDANHDAO();
                var model = dao.Update( mkgv, cttkb,idad);
                if (model)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Chuyên Ngành không thành công.");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index", "Home");
        }
        static string GetIPAddress()
        {
            String address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;
        }
        public static long? idtk;
        [HttpGet]
        public ActionResult EditPass(long? id)
        {
            var tk = new TAIKHOANDAO().ViewDetail(id);
            idtk = id;
            return View(tk);
        }
        [HttpPost]
        public ActionResult EditPass(TBL_TaiKhoan tk)
        {
            //if (ModelState.IsValid)
            //{
                var dao =new  TAIKHOANDAO();
                if (!string.IsNullOrEmpty(tk.MatKhau))
                {
                    var mhMD5 = MaHoaMD5.MD5Hash(tk.MatKhau);
                    tk.MatKhau = mhMD5;
                }
                var res = dao.Update(tk,idtk);
                if (res)
                {
                    return RedirectToAction("Index", "Home",new { @tk=TaiKhoan});
                }
                else
                {
                    this.AddNotification("Thay đổi mật khẩu thất bại", NotificationType.ERROR);
                    return RedirectToAction("EditPass", "Home");
                }
               
            //}
            //return RedirectToAction("Index", "Home", new { @tk = TaiKhoan });
        }
    }
}