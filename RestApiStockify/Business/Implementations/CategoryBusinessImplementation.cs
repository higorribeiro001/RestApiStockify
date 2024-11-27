using RestApiStockify.Data.Converter.Implementations;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;
using RestApiStockify.Repository.Generic;

namespace RestApiStockify.Business.Implementations
{
    public class CategoryBusinessImplementation : ICategoryBusiness
    {
        private readonly IRepository<Category> _repository;
        private readonly CategoryConverter _converter;

        public CategoryBusinessImplementation(IRepository<Category> repository) 
        {
            _repository = repository;
            _converter = new CategoryConverter();
        }
        public List<CategoryVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CategoryVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public CategoryVO Create(CategoryVO category)
        {
            var categoryEntity = _converter.Parse(category);
            categoryEntity = _repository.Create(categoryEntity);

            return _converter.Parse(categoryEntity);
        }

        public CategoryVO Update(CategoryVO category)
        {
            var categoryEntity = _converter.Parse(category);
            categoryEntity = _repository.Update(categoryEntity);

            return _converter.Parse(categoryEntity);
        }
        public Category Delete(long id)
        {
            _repository.Delete(id);
            return null;
        }
    }
}
