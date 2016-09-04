using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace Eron.web.Helpers
{
    public static class AjaxExtensions
    {
        public static IHtmlString DefaultLink(this AjaxHelper helper, string text,
        string action, string controller, bool isBlack, object routeValues, object htmlAttributes)
        {
            // Build your link here eventually using
            // the arguments passed
            var options = new AjaxOptions
            {
                OnSuccess = isBlack ? "blacknav" : "whitenav",
                UpdateTargetId = "mainpanel",
                InsertionMode = InsertionMode.Replace
                // etc...
            };

            // return a normal ActionLink passing your options
            return helper.ActionLink(text, action, controller, routeValues, options, htmlAttributes);
        }

        public static IHtmlString DefaultLink(this AjaxHelper helper, string text,
       string action, string controller, bool isBlack)
        {
            // Build your link here eventually using 
            // the arguments passed
            var options = new AjaxOptions
            {
                OnSuccess = isBlack ? "blacknav" : "whitenav",
                UpdateTargetId = "mainpanel",
                InsertionMode = InsertionMode.Replace
                // etc...
            };

            // return a normal ActionLink passing your options
            return helper.ActionLink(text, action, controller, options);
        }

        public static IHtmlString DefaultLink(this AjaxHelper helper, string text,
       string action, string controller, bool isBlack, object routeValues)
        {
            // Build your link here eventually using 
            // the arguments passed
            var options = new AjaxOptions
            {
                OnSuccess = isBlack ? "blacknav" : "whitenav",
                UpdateTargetId = "mainpanel",
                InsertionMode = InsertionMode.Replace
                // etc...
            };

            // return a normal ActionLink passing your options
            return helper.ActionLink(text, action, controller, routeValues, options);
        }

        public static MvcForm DefaultForm(this AjaxHelper helper, string action,string controller,FormMethod method,object routeValues,object htmlAttributes,string actionName)
        {
            AjaxOptions options = new AjaxOptions()
            {
                HttpMethod = method.ToString(),
                OnSuccess="success('"+actionName+"')",
                OnFailure = "fail('" + actionName + "')",
                UpdateTargetId = "mainpanel",
                OnComplete = "complete",
                InsertionMode = InsertionMode.Replace
            };
            return helper.BeginForm(action,controller,routeValues,options,htmlAttributes);
        }
    }
}