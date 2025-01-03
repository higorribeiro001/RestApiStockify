using RestApiStockify.Data.Converter.Contract;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Data.Converter.Implementations
{
    public class ProductConverter : IParser<ProductVO, Product>, IParser<Product, ProductVO>
    {
        public Product Parse(ProductVO origin)
        {
            if (origin == null) return null;
            return new Product
            {
                Id = origin.Id,
                Name = origin.ProductName,
                BlobImage = origin.BlobImage,
                Description = origin.Description,
                CategoryId = origin.CategoryId,
                IsActive = origin.IsActive,
                IsPurchased = origin.IsPurchased,
                Price = origin.Price,
                CreatedAt = origin.CreatedAt,
                UpdatedAt = origin.UpdatedAt,
                DepositId = origin.DepositId,
            };
        }

        public ProductVO Parse(Product origin)
        {
            if (origin == null) return null;
            return new ProductVO
            {
                Id = origin.Id,
                ProductName = origin.Name,
                BlobImage = origin.BlobImage,
                Description = origin.Description,
                CategoryId = origin.CategoryId,
                IsActive = origin.IsActive,
                IsPurchased = origin.IsPurchased,
                Price = origin.Price,
                CreatedAt = origin.CreatedAt,
                UpdatedAt = origin.UpdatedAt,
                DepositId = origin.DepositId,
            };
        }

        public List<Product> Parse(List<ProductVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ProductVO> Parse(List<Product> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
