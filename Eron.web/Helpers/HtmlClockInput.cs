using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Eron.web.Helpers
{
    public static class HtmlClockInput
    {
        public static IHtmlString ClockInput<TModel, TValue>(this HtmlHelper<TModel> helper,Expression<Func<TModel, TValue>> expression)
        {
            /*<div data-autoclose="true" class="input-group clockpicker">
                                <input type="text" value="09:30" class="form-control">
                                <span class="input-group-addon">
                                    <span class="fa fa-clock-o"></span>
                                </span>
                            </div>*/
            var s = helper.TextBoxFor(expression, new { @class = "form-control" }).ToHtmlString();
            var w = "<div data-autoclose='true' class='input-group clockpicker'>"+s+"<span class='input-group-addon'><span class='fa fa-clock-o'></span></span></div>";

            return new HtmlString(w);
        }

        public static IHtmlString ClockInputScript(this HtmlHelper helper)
        {
            var w = "<script>$('.clockpicker').clockpicker();</script>";
            return new HtmlString(w);
        }
    }
}