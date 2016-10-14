using Eron.core.DataModel.Location;
using Eron.core.DataModel.Navigation;
using Eron.core.ViewModels.Category;
using Eron.core.ViewModels.Content;
using Eron.core.ViewModels.Language;
using Eron.core.ViewModels.Navigation;
using Eron.core.ViewModels.Page;
using Eron.core.ViewModels.Slider;

namespace Eron.core.ViewModels
{
    public interface IModelFactory
    {
        GoogleMap Create(decimal lat, decimal lng);

        byte Create(bool[] model);

        //Content
        ContentListView Create(core.DataModel.Content.Content model);

        core.DataModel.Content.Content Create(ContentCreate model);

        ContentEdit EditCreate(core.DataModel.Content.Content model);


        core.DataModel.Content.Content Create(ContentEdit model);
        //Category
        CategoryEdit EditCreate(core.DataModel.Content.Category model);

        CategoryList ListCreate(core.DataModel.Content.Category model);

        core.DataModel.Content.Category Create(CategoryCreate model);

        core.DataModel.Content.Category Create(CategoryEdit model);

        //Language
        core.DataModel.Location.Language Create(LanguageCreate model);

        core.DataModel.Location.Language Create(LanguageEdit model);

        LanguageList ListCreate(core.DataModel.Location.Language model);

        LanguageEdit EditCreate(core.DataModel.Location.Language model);

        //SelectList
        SelectListItem<TKey> SelectList<TKey>(string name, TKey id);

        //Page
        PageList ListCreate(core.DataModel.Page.Page model);
        core.DataModel.Page.Page Create(PageCreate model);

        //Navigation
        Menu Create(MenuCreate model);
        MenuCreate EditCreate(Menu model);
        MenuList ListCreate(Menu model);

        //Slider
        core.DataModel.Utilities.Slider Create(SliderViewModel model);
        SliderViewModel ListCreate(core.DataModel.Utilities.Slider model);

    }
}