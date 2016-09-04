using System.Web;
using System.Web.Mvc;

namespace Eron.web.Helpers
{
    public static class HtmlListBoxAddon
    {
        public static IHtmlString ListBoxAddon(this HtmlHelper helper, string name)
        {
            //<div class="input-group">
            //  < select data - placeholder = "Choose a Country..." class="chosen-select" multiple style = "width:350px;" tabindex="4"></select></div>
            return new HtmlString("");
        }

        public static IHtmlString ListBoxScript(this HtmlHelper helper, string name)
        {
            //$('#selector').chosen();
            return new HtmlString("<script>$('.chosenlist').chosen();</script>");
        }
    }
}