namespace Eron.core.DataModel.Location
{
    public class Country:EntityBase<long>
    {
        public string CountryName { get; set; }

        public string MainLanguage { get; set; }

        public string NationalCode { get; set; }
    }

    public class State:EntityBase<long>
    {
        public string Name { get; set; }
    }

    public class SubState:EntityBase<long>
    {
        public string Name { get; set; }
    }


}