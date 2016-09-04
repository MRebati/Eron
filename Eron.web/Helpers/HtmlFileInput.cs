using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eron.web.Helpers
{
    public static class HtmlFileInput
    {
        public static IHtmlString FileInput(this HtmlHelper helper, string name)
        {
            var element =
                string.Format(
                    "<div class='fileUpload btn btn-success'>" +
                    "<span>بارگزاری</span>" +
                    "<input id='{0}Btn' name='{0}' type='file' class='upload'/>" +
                    "</div>" +
                    "<input id='{0}File' class='form-control file-upload-text' placeholder='فایلی را انتخاب کنید' disabled='disabled'/>" +
                    "<script>" +
                    "document.getElementById('{0}Btn').onchange = function () {{document.getElementById('{0}File').value = this.value;}};" +
                    "</script>",
                    name);

            return new HtmlString(element);
        }
    }
}