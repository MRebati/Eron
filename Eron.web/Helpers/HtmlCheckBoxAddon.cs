using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Eron.web.Helpers
{
    public enum CheckBoxType
    {
        success,
        warning,
        primary,
        danger
    }
    public static class HtmlCheckBoxAddon
    {
        public static IHtmlString CheckBoxAddOn(this HtmlHelper helper, string name, string text, bool? set, CheckBoxType type)
        {
            string w = "";
            if (set == null)
                set = false;
            if (set.Value)
                w = "checked";
            var s = String.Format(
                "<div class='checkbox checkbox-{2}'><input id ='{0}' name ='{0}' type='checkbox' value='true' class='checkbox-addon'" + w + "><label for= '{0}'>{1}</label></div>", name, text, type);
            return new HtmlString(s);
        }
    }
}