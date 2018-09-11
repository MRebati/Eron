using Eron.Business.Core.Services.Financial.Shop.Product.Dto;

namespace Eron.Business.Core.Services.Financial.Shop.ProductPrice.Dto
{
    public class ProductPriceDto
    {
        public bool IsValid { get; set; }

        public long ProductId { get; set; }

        public virtual ProductDto Product { get; set; }

        public long Price { get; set; }

        public string Description { get; set; }
    }

    public class ProductPriceWithoutProductDto
    {
        public bool IsValid { get; set; }        

        public long Price { get; set; }

        public string Description { get; set; }
    }
}
