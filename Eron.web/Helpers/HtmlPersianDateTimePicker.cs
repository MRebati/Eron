using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eron.web.Helpers
{
    public static class HtmlPersianDateTimePicker
    {
        public static IHtmlString PersianDateTime(this HtmlHelper helper, string name)
        {
            string s = string.Format(
                "<div class='input-group-addon' data-mddatetimepicker='true' data-targetselector='#{0}' data-trigger='click' data-englishnumber='true' data-enabletimepicker='true'><span class='ion ion-calendar'></span></div>", name);
            return new HtmlString(s);
        }

        public static IHtmlString PersianFromDateTime(this HtmlHelper helper, string name, string groupid)
        {
            string s = string.Format(
                "<div class='input-group-addon' data-mddatetimepicker='true' data-groupid='{1}' data-targetselector='#{0}' data-trigger='click' data-englishnumber='true' data-fromdate='true' data-enabletimepicker='true'><span class='ion ion-calendar'></span></div>", name, groupid);
            return new HtmlString(s);
        }

        public static IHtmlString PersianToDateTime(this HtmlHelper helper, string name, string groupid)
        {
            string s = string.Format(
                "<div class='input-group-addon' data-mddatetimepicker='true' data-groupid='{1}' data-targetselector='#{0}' data-trigger='click' data-englishnumber='true' data-todate='true' data-enabletimepicker='true'><span class='ion ion-calendar'></span></div>", name, groupid);
            return new HtmlString(s);
        }

        public static IHtmlString PersianDateTimeScript(this HtmlHelper helper)
        {
            string s = string.Format("<script>EnableMdDateTimePickers();</script>");
            return new HtmlString(s);

        }
    }
}