using System;

namespace Eron.core.DataModel.Location
{
    public class GoogleMap:EntityBase<Guid>
    {
        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public string Name { get; set; }
    }
}