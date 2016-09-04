using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Eron.web.Helpers
{
    public static class HtmlTagInput
    {
        public static MvcHtmlString TagInput<TModel, TValue>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TValue>> expression,string name)
        {
            var text = helper.DisplayNameFor(expression).ToString();
            //var script = helper.TagInputScript(name, text);
            var input = helper.HiddenFor(expression,new { @placeholder=text,@class= "tagsinput" });
            var s = new MvcHtmlString(input.ToHtmlString());
            return s;
        }

        public static MvcHtmlString TagInputScript(this HtmlHelper helper)
        {
            //
            return new MvcHtmlString(String.Format("<script>$('.tagsinput').each(function(){{" +
                                                   "$(this).tagsInput();" +
                                                   "}});</script>"));
        }
    }
}