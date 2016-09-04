using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Eron.web.Controllers;

namespace Eron.web.Models.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public string Create(FileType type, HttpPostedFileBase file, string name)
        {
            if (file.ContentLength > 0)
            {

                name = name.Replace(" ", "_");
                var directoryName = "default";

                //create directoryName
                directoryName = type.ToString();

                var directory = HttpContext.Current.Server.MapPath("~/Uploads/" + directoryName + "/");
                Directory.CreateDirectory(directory);
                var fileType = Path.GetExtension(file.FileName);
                var imageUrl = name + fileType;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + directoryName), imageUrl);
                file.SaveAs(path);
                var url = "/Uploads/" + directoryName + "/" + imageUrl;

                return url;
            }
            else
            {
                return null;
            }
        }

        public bool Exist(string direction)
        {
            var path = HttpContext.Current.Server.MapPath(direction);
            return System.IO.File.Exists(path);
        }

        public void Remove(string direction)
        {
            var path = HttpContext.Current.Server.MapPath(direction);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }

        public string Update(string direction, HttpPostedFileBase file, string name, FileType type)
        {
            Remove(direction);
            return Create(type, file, name);
        }
    }
}