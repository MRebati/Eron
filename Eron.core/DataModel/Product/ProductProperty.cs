using System;

namespace Eron.core.DataModel.Product
{
    public enum PropertyType
    {
        Bool,
        String,
        Integer
    }

    public class ProductProperty:EntityBase
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public PropertyType PropertyType { get; set; }
    }
}