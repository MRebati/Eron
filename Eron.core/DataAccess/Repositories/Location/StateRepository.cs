using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Location;

namespace Eron.core.DataAccess.Repositories.Location
{
    public class StateRepository:Repository<State,long>
    {
        public StateRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}