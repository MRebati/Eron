using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eron.web.Helpers
{
    public static class HtmlCreateFormScript
    {
        public static IHtmlString CreateFormScript(this HtmlHelper helper, string controller, string area, string actionName)
        {
            controller = controller.ToLower();
            area = area.ToLower();
            return new HtmlString(string.Format("<script>createAjaxForm('{0}/{1}/list','" + actionName + "');</script>", area, controller));
        }

        public static IHtmlString CreateFormScript(this HtmlHelper helper,string actionName)
        {
            return new HtmlString("<script>createAjaxForm('"+actionName+"');</script>");
        }

        public static IHtmlString EditFormScript(this HtmlHelper helper, string controller, string area,string actionName)
        {
            controller = controller.ToLower();
            area = area.ToLower();
            return new HtmlString(string.Format("<script>editAjaxForm('{0}/{1}/list','"+actionName+"');</script>", area, controller));
        }

        public static IHtmlString EditFormScript(this HtmlHelper helper, string actionName)
        {
            return new HtmlString("<script>editAjaxForm('" + actionName + "');</script>");
        }
    }
}