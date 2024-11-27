using RestApiStockify.Data.Converter.Contract;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Data.Converter.Implementations
{
    public class CategoryConverter : IParser<CategoryVO, Category>, IParser<Category, CategoryVO>
    {
        public Category Parse(CategoryVO origin)
        {
            if (origin == null) return null;
            return new Category
            {
                Id = origin.Id,
                NameCategory = origin.NameCategory,
            };
        }

        public CategoryVO Parse(Category origin)
        {
            if (origin == null) return null;
            return new CategoryVO
            {
                Id = origin.Id,
                NameCategory = origin.NameCategory,
            };
        }

        public List<Category> Parse(List<CategoryVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CategoryVO> Parse(List<Category> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
