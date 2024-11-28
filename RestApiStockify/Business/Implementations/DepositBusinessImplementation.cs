using Microsoft.EntityFrameworkCore;
using RestApiStockify.Data.Converter.Implementations;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;
using RestApiStockify.Model.Context;
using RestApiStockify.Repository.Generic;
using System.Net;

namespace RestApiStockify.Business.Implementations
{
    public class DepositBusinessImplementation : IDepositBusiness
    {
        private readonly IRepository<Deposit> _repository;
        private readonly DepositConverter _converter;

        public DepositBusinessImplementation(IRepository<Deposit> repository)
        {
            _repository = repository;
            _converter = new DepositConverter();
        }

        public DepositVO Create(DepositVO deposit)
        {
            var depositEntity = _converter.Parse(deposit);
            depositEntity = _repository.Create(depositEntity);

            return _converter.Parse(depositEntity);
        }

        public DepositVO Update(DepositVO deposit)
        {
            var depositEntity = _converter.Parse(deposit);
            depositEntity = _repository.Update(depositEntity);

            return _converter.Parse(depositEntity);
        }
        public Deposit Delete(long id)
        {
            _repository.Delete(id);
            return null;
        }
    }
}
