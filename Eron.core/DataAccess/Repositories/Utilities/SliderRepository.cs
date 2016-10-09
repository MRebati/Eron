using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eron.core.DataModel.Utilities;
using Eron.core.Encode;

namespace Eron.core.DataAccess.Repositories.Utilities
{
    public class SliderRepository : Repository<Slider, long>
    {
        public SliderRepository(ApplicationDbContext context, Encode.Encode encode) : base(context, encode)
        {
        }
    }
}