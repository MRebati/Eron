using System.Collections.Generic;

namespace Eron.core.DataModel.Product
{
    public class ProductCategory:EntityBase<long>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}