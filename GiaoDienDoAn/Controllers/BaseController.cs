using GiaoDienDoAn.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
               System.Web.Routing.RouteValueDictionary(new
               {
                   Controller = "Login",
                   action ="Index"
               }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}