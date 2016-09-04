namespace Eron.core.DataModel.Location
{
    public class GoogleMap:EntityBase
    {
        public decimal Lat { get; set; }

        public decimal Lng { get; set; }

        public string Name { get; set; }
    }
}