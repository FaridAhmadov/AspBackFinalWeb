using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFINALPROJECT.Areas.Admin.Filters
{
    public class SessionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["LoggedIn"] == null)
            {
                filterContext.Result = new RedirectResult("~/Admin/LoginReg/myLogin");
                return;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}