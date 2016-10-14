using System.Web;

namespace Eron.core.Models.FileHelper
{
    public interface IFileHelper
    {
        string Create(FileType type,HttpPostedFileBase file,string name);

        bool Exist(string direction);

        void Remove(string direction);

        string Update(string direction, HttpPostedFileBase file,string name,FileType type);
    }
}
