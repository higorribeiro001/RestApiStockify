using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Business
{
    public interface ICategoryBusiness
    {
        CategoryVO Create(CategoryVO category);
        CategoryVO FindByID(long id);
        List<CategoryVO> FindAll();
        CategoryVO Update(CategoryVO category);
        Category Delete(long id);
    }
}
