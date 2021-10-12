using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Security
{
    public abstract class BasePage: System.Web.Mvc.WebViewPage
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }
    public abstract class BasePage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public CustomPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as CustomPrincipal;
            }
        }
    }
}