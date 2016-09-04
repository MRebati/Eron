using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eron.core.Encode
{
    public interface IEncode
    {
        Guid GetGuid(string code);
        string GetString(Guid code);
        Guid CreateGuid();
    }
}