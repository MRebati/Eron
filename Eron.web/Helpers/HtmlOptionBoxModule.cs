using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eron.web.Helpers
{
    public static class HtmlOptionBox
    {
        public static IHtmlString OptionBox(this HtmlHelper helper, string controller,string area,string id)
        {
            area = area.ToLower();
            controller = controller.ToLower();
            return new HtmlString(String.Format("<a href='/{1}/{0}/edit/{2}' data-ajax-success='blacknav' data-ajax-update='#mainpanel' data-ajax-mode='replace' data-ajax='true'><i class='ion ion-edit text-yellow'></i></a>&nbsp;&nbsp;<a href = '/{1}/{0}/details/{2}' data-ajax-update = '#mainpanel' data-ajax-success='blacknav' data-ajax-mode ='replace' data-ajax ='true'><i class='ion ion-information-circled text-light-blue'></i></a>&nbsp;&nbsp;<a href ='/{1}/{0}/delete/{2}' data-ajax-update='#mainpanel' data-ajax-success='blacknav' data-ajax-mode='replace' data-ajax='true'><i class='ion ion-android-delete text-red'></i></a>", controller,area,id));
        }
    }
}