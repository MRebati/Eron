using System;
using System.Collections;
using System.Diagnostics;
using System.Web;
using Eron.core.App_GlobalResources;
using Eron.core.DataModel.Location;
using Eron.core.DataModel.Navigation;
using Eron.core.Encode;
using Eron.core.PersianDateTime;
using Eron.core.Services;
using Eron.core.ViewModels.Category;
using Eron.core.ViewModels.Content;
using Eron.core.ViewModels.Language;
using Eron.core.ViewModels.Navigation;
using Eron.core.ViewModels.Page;
using Eron.core.ViewModels.Slider;
using Microsoft.AspNet.Identity;

namespace Eron.core.ViewModels
{
    public class ModelFactory : IModelFactory
    {
        private core.Encode.IEncode encode;

        private HttpContext message;
        private IRepositoryService service;
        private IPersian persianCalendar;

        public ModelFactory(IEncode _encode, HttpContext _message, IRepositoryService _service)
        {
            this.encode = _encode;
            this.message = _message;
            service = _service;
            this.persianCalendar = new Persian();
        }

        public GoogleMap Create(decimal lat, decimal lng)
        {
            return new GoogleMap() { Id = encode.CreateGuid(), Lat = lat, Lng = lng };
        }

        public byte Create(bool[] bools)
        {
            var bitArray = new BitArray(bools);
            var arr = Convert.ToByte(bitArray);
            return arr;
        }

        //==========================Content============================//

        public ContentListView Create(core.DataModel.Content.Content model)
        {
            return new ContentListView()
            {
                Author = String.IsNullOrEmpty(model.Author) ? GlobalResources.NotFound : model.Author,
                CategoryName = model.Category.Name,
                CreateTime = persianCalendar.PersianDate(model.CreateTime),
                ModifiedTime = persianCalendar.PersianDate(model.ModifiedTime),
                PublishStartTime = persianCalendar.PersianDate(model.PublishStartTime),
                PublishEndTime = persianCalendar.PersianDate(model.PublishEndTime),
                State = model.Published ? GlobalResources.Published : GlobalResources.Unpublished,
                Id = model.Id,
                Slug = model.Slug,
                Title = model.Title
            };
        }

        public core.DataModel.Content.Content Create(ContentCreate model)
        {
            return new core.DataModel.Content.Content()
            {
                Title = model.Title,
                Summery = model.Summery,
                Author = HttpContext.Current.User.Identity.GetUserId(),
                CategoryId = model.CategoryId,
                ContentData = model.Content,
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                ImageUrl = model.ImageUrl,
                Published = model.Published,
                PublishStartTime = persianCalendar.GregorianDateTime(model.PublishStartTime),
                PublishEndTime = string.IsNullOrEmpty(model.PublishEndTime) ? persianCalendar.GregorianDateTime(model.PublishStartTime) : persianCalendar.GregorianDateTime(model.PublishEndTime),
                Slug = model.Slug.Replace(" ", "-"),
                ShowDateTime = model.ShowDateTime,
                ShowAuthor = model.ShowAuthor,
                Tag = model.Tag,
                UserId = HttpContext.Current.User.Identity.GetUserId(),
                Language = model.Language,
                IsGlobal = model.IsGlobal,
                Keywords = model.Keywords
            };
        }

        public ContentEdit EditCreate(core.DataModel.Content.Content model)
        {
            return new ContentEdit()
            {
                Title = model.Title,
                Summery = model.Summery,
                CategoryId = model.CategoryId,
                Content = model.ContentData,
                CreateTime = model.CreateTime,
                ModifiedTime = DateTime.Now,
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Published = model.Published,
                PublishStartTime = persianCalendar.PersianDateTime(model.PublishStartTime),
                PublishEndTime = persianCalendar.PersianDateTime(model.PublishEndTime),
                Slug = model.Slug.Replace(" ", "-"),
                ShowDateTime = model.ShowDateTime,
                ShowAuthor = model.ShowAuthor,
                Tag = model.Tag,
                UserId = HttpContext.Current.User.Identity.GetUserId(),
                Language = model.Language,
                IsGlobal = model.IsGlobal,
                Keywords = model.Keywords
            };
        }

        public core.DataModel.Content.Content Create(ContentEdit model)
        {
            return new core.DataModel.Content.Content()
            {
                Id = model.Id,
                Title = model.Title,
                Summery = model.Summery,
                Author = HttpContext.Current.User.Identity.GetUserId(),
                CategoryId = model.CategoryId,
                ContentData = model.Content,
                CreateTime = model.CreateTime,
                ModifiedTime = DateTime.Now,
                ImageUrl = model.ImageUrl,
                Published = model.Published,
                PublishStartTime = persianCalendar.GregorianDateTime(model.PublishStartTime),
                PublishEndTime = string.IsNullOrEmpty(model.PublishEndTime) ? persianCalendar.GregorianDateTime(model.PublishStartTime) : persianCalendar.GregorianDateTime(model.PublishEndTime),
                Slug = model.Slug.Replace(" ", "-"),
                ShowDateTime = model.ShowDateTime,
                ShowAuthor = model.ShowAuthor,
                Tag = model.Tag,
                UserId = HttpContext.Current.User.Identity.GetUserId(),
                Language = model.Language,
                IsGlobal = model.IsGlobal,
                Keywords = model.Keywords
            };
        }

        //=========================Category============================//

        /// <summary>
        /// Creates an Instance of CategoryEdit from its entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>categoryEdit ViewModel</returns>
        public CategoryEdit EditCreate(core.DataModel.Content.Category model)
        {
            return new CategoryEdit()
            {
                Background = model.BackgroundUrl,
                Description = model.Description,
                Image = model.ImageUrl,
                Published = model.Published,
                Name = model.Name,
                Id = model.Id,
                CreateTime = model.CreateTime,
                PublishTime = persianCalendar.PersianDateTime(model.PublishTime)
            };
        }


        /// <summary>
        /// Creates List of Categories from its entity.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List Item ViewModel for Category</returns>
        public CategoryList ListCreate(core.DataModel.Content.Category model)
        {
            return new CategoryList()
            {
                CreateTime = persianCalendar.PersianDate(model.CreateTime),
                ModifiedTime = persianCalendar.PersianDate(model.ModifiedTime),
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
                State = model.Published ? GlobalResources.Published : GlobalResources.Unpublished
            };
        }

        //CategoryCraete => Category
        public core.DataModel.Content.Category Create(CategoryCreate model)
        {
            return new core.DataModel.Content.Category()
            {
                BackgroundUrl = model.Background,
                Description = model.Description,
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now,
                Name = model.Name,
                Published = model.Published,
                PublishTime = !string.IsNullOrEmpty(model.PublishTime) ? persianCalendar.GregorianDateTime(model.PublishTime) : DateTime.Now,
                ImageUrl = model.Image
            };
        }

        //CategoryEdit => Category
        public core.DataModel.Content.Category Create(CategoryEdit model)
        {
            return new core.DataModel.Content.Category()
            {
                Name = model.Name,
                BackgroundUrl = model.Background,
                CreateTime = model.CreateTime,
                ModifiedTime = DateTime.Now,
                Description = model.Description,
                Id = model.Id,
                ImageUrl = model.Image,
                PublishTime = !string.IsNullOrEmpty(model.PublishTime) ? persianCalendar.GregorianDateTime(model.PublishTime) : DateTime.Now,
                Published = model.Published
            };
        }

        //Language
        public core.DataModel.Location.Language Create(LanguageCreate model)
        {
            return new core.DataModel.Location.Language()
            {
                EnglishName = model.EnglishName,
                FlagUrl = model.FlagUrl,
                LocalName = model.LocalName,
                LanguageCode = model.LanguageCode
            };
        }

        public core.DataModel.Location.Language Create(LanguageEdit model)
        {
            return new core.DataModel.Location.Language()
            {
                EnglishName = model.EnglishName,
                FlagUrl = model.FlagUrl,
                LanguageCode = model.LanguageCode,
                LocalName = model.LocalName
            };
        }

        public LanguageList ListCreate(core.DataModel.Location.Language model)
        {
            return new LanguageList()
            {
                EnglishName = model.EnglishName,
                FlagUrl = model.FlagUrl,
                Id = model.Id,
                LanguageCode = model.LanguageCode,
                LocalName = model.LocalName
            };
        }

        public LanguageEdit EditCreate(core.DataModel.Location.Language model)
        {
            return new LanguageEdit()
            {
                EnglishName = model.EnglishName,
                FlagUrl = model.FlagUrl,
                Id = model.Id,
                LanguageCode = model.LanguageCode,
                LocalName = model.LocalName
            };
        }

        public SelectListItem<TKey> SelectList<TKey>(string name, TKey id)
        {
            return new SelectListItem<TKey>()
            {
                Name = name,
                Id = id
            };
        }

        //SelectList
        

        public PageList ListCreate(core.DataModel.Page.Page model)
        {
            var username = service.User.Users.Find(model.UserId);
            return new PageList
            {
                Id = model.Id,
                CreateTime = persianCalendar.PersianDate(model.CreateTime),
                Language = model.Language,
                PageUrl = model.Slug,
                Title = model.Title,
                UserName = username != null ? username.FirstName + " " + username.LastName : string.Empty
            };
        }

        public core.DataModel.Page.Page Create(PageCreate model)
        {
            return new core.DataModel.Page.Page
            {
                Id = model.Id,
                Content = model.Content,
                CreateTime = model.CreateTime ?? DateTime.Now,
                Language = model.Language,
                ModifiedTime = DateTime.Now,
                Slug = model.Slug.Replace(" ", "-"),
                Title = model.Title,
                UserId = message.User.Identity.GetUserId()
            };
        }

        public Menu Create(MenuCreate model)
        {
            return new Menu()
            {
                Id = model.Id?? new int(),
                Name = model.Name,
                MenuId = String.IsNullOrEmpty(model.MenuId) ? Guid.Empty : encode.GetGuid(model.MenuId),
                Target = model.Target != null && model.Target.Value ? "_self" : "_blank",
                Url = model.Url
            };
        }

        public MenuCreate EditCreate(Menu model)
        {
            return new MenuCreate()
            {
                Id = model.Id,
                IsSubMenu = model.MenuId == null,
                MenuId = encode.GetString(model.MenuId.Value),
                Name = model.Name,
                Target = model.Target == "_self",
                Url = model.Url
            };
        }

        public MenuList ListCreate(Menu model)
        {
#if(DEBUG)
            Debug.Assert(model.MenuId != null, "model.MenuId != null");
#endif
            return new MenuList()
            {
                Id = model.Id,
                IsSubMenu = model.MenuId == null,
                MenuId = encode.GetString(model.MenuId.Value),
                Name = model.Name,
                Target = model.Target == "_self" ? GlobalResources.CurrentPage : GlobalResources.NewPage,
                Url = model.Url,
                MenuName = service.Menues.Get(model.MenuId.Value).Name
            };
        }

        public core.DataModel.Utilities.Slider Create(SliderViewModel model)
        {
            return new core.DataModel.Utilities.Slider()
            {
                BackgroundUrl = model.BackgroundUrl,
                Endable = model.Endable,
                EndDate = model.Endable?persianCalendar.GregorianDateTime(model.EndDate): new DateTime(),
                ShowCaption = model.ShowCaption,
                ShowTitle = model.ShowTitle,
                StartDate = persianCalendar.GregorianDateTime(model.StartDate),
                Title = model.Title,
                Name = model.Name,
                LinkName = model.LinkName,
                LinkUrl = model.LinkUrl,
                Id = model.Id?? new long()
            };
        }

        public SliderViewModel ListCreate(core.DataModel.Utilities.Slider model)
        {
            return new SliderViewModel()
            {
                BackgroundUrl = model.BackgroundUrl,
                Endable = model.Endable,
                EndDate = model.EndDate != null ? persianCalendar.PersianDateTime(model.EndDate.Value):String.Empty,
                ShowCaption = model.ShowCaption,
                ShowTitle = model.ShowTitle,
                StartDate = persianCalendar.PersianDateTime(model.StartDate),
                Title = model.Title,
                Name = model.Name,
                LinkName = model.LinkName,
                LinkUrl = model.LinkUrl,
                Id = model.Id
            };
        }
    }
}