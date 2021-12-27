﻿using GiaoDienDoAn.Areas.Admin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GiaoDienDoAn.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (AdminLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
               System.Web.Routing.RouteValueDictionary(new
               {
                   Controller = "Login",
                   action = "Index",
                   Areas = "Admin"
               }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}