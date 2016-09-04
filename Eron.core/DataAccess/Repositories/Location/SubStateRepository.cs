using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Location;

namespace Eron.core.DataAccess.Repositories.Location
{
    public class SubStateRepository:Repository<SubState>
    {
        public SubStateRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}