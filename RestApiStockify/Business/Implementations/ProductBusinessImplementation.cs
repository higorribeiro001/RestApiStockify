using Microsoft.EntityFrameworkCore;
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
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public ProductBusinessImplementation(IRepository<Product> repository, IHttpContextAccessor context)
        {
            _repository = repository;
            _converter = new ProductConverter();
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
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

        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;
            return File.ReadAllBytes(filePath);
        }

        public async Task<ProductVO> SaveFileToDisk(IFormFile file)
        {
            ProductVO fileDetail = new ProductVO();

            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context?.HttpContext?.Request.Host;

            if (fileType.ToLower() == ".png" || fileType.ToLower() == ".jpg" ||
                   fileType.ToLower() == ".png" || fileType.ToLower() == ".jpg")
            {
                var docName = Path.GetFileName(file.FileName);
                if (file != null && file.Length > 0)
                {
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetail.DocumentName = docName;
                    fileDetail.DocType = fileType;
                    fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return fileDetail;
        }
    }
}
