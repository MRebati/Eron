using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Eron.web.Helpers
{
    public static class AjaxUploadForm
    {
        //Html.BeginForm("Create","BooksControl",FormMethod.Post,new { @enctype="multipart/form-data",@id="createform" })

        public static MvcForm CreateUploadForm(this HtmlHelper helper, string controller, string action, FormMethod method)
        {
            var form = helper.BeginForm(action, controller, method, new { @enctype = "multipart/form-data", @id = "createform" });
            return form;
        }

        public static MvcForm EditUploadForm(this HtmlHelper helper, string controller, string action, FormMethod method)
        {
            return helper.BeginForm(action, controller, method, new { @enctype = "multipart/form-data", @id = "editform" });
        }
    }
}