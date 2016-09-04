using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Eron.web.Helpers
{
    public static class HtmlTextBoxPlaceHolder
    {
        public static MvcHtmlString PlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html,Expression<Func<TModel, TValue>> expression)
        {
            string s = html.DisplayNameFor(expression).ToString();
            return html.TextBoxFor(expression,new {@placeholder=s, @class = "form-control" });
            //string s = String.Format("<input type='text' name='{0}' id='{0}' placeholder='{1}' />",name,text);
            //return new helper.TextBoxFor()
        }

        public static MvcHtmlString LtrPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string s = html.DisplayNameFor(expression).ToString();
            return html.TextBoxFor(expression, new { @placeholder = s, @class = "form-control text-right direction-left"  });
            //string s = String.Format("<input type='text' name='{0}' id='{0}' placeholder='{1}' />",name,text);
            //return new helper.TextBoxFor()
        }

        public static MvcHtmlString PlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression,object htmlAttributes)
        {
            string s = html.DisplayNameFor(expression).ToString();
            
            return html.TextBoxFor(expression, new { @placeholder = s, @class = "form-control" });
            //string s = String.Format("<input type='text' name='{0}' id='{0}' placeholder='{1}' />",name,text);
            //return new helper.TextBoxFor()
        }
    }
}