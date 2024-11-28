using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Business
{
    public interface IProductBusiness
    {
        ProductVO Create(ProductVO product);
        ProductVO Update(ProductVO product);
        Product Delete(long id);
    }
}
