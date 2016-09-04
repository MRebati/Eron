using System;
using System.Web;
using System.Web.Mvc;

namespace Eron.web.Helpers
{
    public enum ModalType
    {
        CreateModal,
        EditModal,
        DeleteModal,
        DetailsModal
    }

    public enum Size
    {
        lg,
        md,
        sm,
        sx
    }

    public static class HtmlModalHelper
    {
        public static IHtmlString ModalHelper(this HtmlHelper helper, ModalType modalType,Size size)
        {
            var s = "<div aria-hidden='true' role='dialog' tabindex='-1' id='" + modalType.ToString().ToLower() +
                    "' class='modal inmodal fade' style='display: none;'><div id='" + modalType.ToString().ToLower() + "-inner' class='modal-dialog modal-"+size+"'></div></div>";
            return new HtmlString(s);
        }

        public static IHtmlString ModalOptionBox(this HtmlHelper helper, string controller, string area, string id)
        {
            area = area.ToLower();
            controller = controller.ToLower();
            return new HtmlString(String.Format("<a href='/{1}/{0}/edit/{2}' data-ajax-success='editModalShow' data-ajax-update='#editmodal-inner' data-ajax-mode='replace' data-ajax='true'><i class='ion ion-edit text-yellow'></i></a>&nbsp;&nbsp;<a href = '/{1}/{0}/details/{2}' data-ajax-update = '#editmodal-inner' data-ajax-success='detailsModalShow' data-ajax-mode ='replace' data-ajax ='true'><i class='ion ion-information-circled text-light-blue'></i></a>&nbsp;&nbsp;<a href ='/{1}/{0}/delete/{2}' data-ajax-update='#deletemodal-inner' data-ajax-success='deleteModalShow' data-ajax-mode='replace' data-ajax='true'><i class='ion ion-android-delete text-red'></i></a>", controller, area, id));
        }

        public static IHtmlString EditDeleteOptionBox(this HtmlHelper helper, string controller, string area, string id)
        {
            area = area.ToLower();
            controller = controller.ToLower();
            return new HtmlString(String.Format("<a href='/{1}/{0}/edit/{2}' data-ajax-success='editModalShow' data-ajax-update='#editmodal-inner' data-ajax-mode='replace' data-ajax='true'><i class='ion ion-edit text-yellow'></i></a>&nbsp;&nbsp;<a href ='/{1}/{0}/delete/{2}' data-ajax-update='#deletemodal-inner' data-ajax-success='deleteModalShow' data-ajax-mode='replace' data-ajax='true'><i class='ion ion-android-delete text-red'></i></a>", controller, area, id));
        }
    }
}