using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Eron.web.Models.FileHelper
{
    public interface IFileHelper
    {
        string Create(FileType type,HttpPostedFileBase file,string name);

        bool Exist(string direction);

        void Remove(string direction);

        string Update(string direction, HttpPostedFileBase file,string name,FileType type);
    }
}
