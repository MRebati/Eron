using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Location;

namespace Eron.core.DataAccess.Repositories.Location
{
    public class LanguageRepository: Repository<Language>
    {
        public LanguageRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}