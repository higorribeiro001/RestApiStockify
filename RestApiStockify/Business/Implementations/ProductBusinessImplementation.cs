using RestApiStockify.Data.Converter.Implementations;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;
using RestApiStockify.Repository.Generic;

namespace RestApiStockify.Business.Implementations
{
    public class ProductBusinessImplementation : IProductBusiness
    {
        private readonly IRepository<Product> _repository;
        private readonly ProductConverter _converter;

        public ProductBusinessImplementation(IRepository<Product> repository)
        {
            _repository = repository;
            _converter = new ProductConverter();
        }

        public ProductVO Create(ProductVO product)
        {
            var productEntity = _converter.Parse(product);
            productEntity = _repository.Create(productEntity);

            return _converter.Parse(productEntity);
        }

        public ProductVO Update(ProductVO product)
        {
            var productEntity = _converter.Parse(product);
            productEntity = _repository.Update(productEntity);

            return _converter.Parse(productEntity);
        }
        public Product Delete(long id)
        {
            _repository.Delete(id);
            return null;
        }
    }
}
