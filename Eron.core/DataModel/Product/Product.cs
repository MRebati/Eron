using System;
using System.Collections.Generic;

namespace Eron.core.DataModel.Product
{
    public class Product:ReportingBase<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public string Keywords { get; set; }

        public decimal Rate { get; set; }

        public long Price { get; set; }

        public ICollection<File.File> Images { get; set; }

        public ICollection<ProductProperty> ProductProperties { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}