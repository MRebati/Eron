using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Areas.admin.Controllers;
using Eron.web.Areas.admin.Models.Page;
using Eron.web.Models.FileHelper;
using FluentAssertions;
using Moq;
using MvcContrib.TestHelper;
using Xunit;

namespace Eron.web.Test.Areas.admin.Controllers
{
    public class PageControllerTest
    {
        //[Fact]
        //public void Create()
        //{
        //    var service = new Mock<IRepositoryService>();
        //    var encode = new Mock<IEncode>();
        //    var fileHelper = new Mock<IFileHelper>();
        //    var pageModel = new Mock<PageCreate>();
        //    pageModel.SetupAllProperties();
        //    PageController controller = new PageController(service.Object, encode.Object, fileHelper.Object);

        //    controller.Create(pageModel.Object).Result.AssertActionRedirect().ToAction("Index");
        //}

        //[Fact]
        //public void Edit()
        //{
        //    var service = new Mock<IRepositoryService>();
        //    var encode = new Mock<IEncode>();
        //    var fileHelper = new Mock<IFileHelper>();
        //    var pageModel = new Mock<PageCreate>();
        //    pageModel.SetupAllProperties();
        //    PageController controller = new PageController(service.Object,encode.Object,fileHelper.Object);

        //    controller.Edit(pageModel.Object).Result.AssertActionRedirect().ToAction("Index");
        //}
    }
}
