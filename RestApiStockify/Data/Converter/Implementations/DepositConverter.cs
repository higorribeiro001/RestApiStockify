﻿using RestApiStockify.Data.Converter.Contract;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Data.Converter.Implementations
{
    public class DepositConverter : IParser<DepositVO, Deposit>, IParser<Deposit, DepositVO>
    {
        private readonly AddressConverter _addressConverter = new AddressConverter();

        public DepositConverter()
        {
            _addressConverter = new AddressConverter();
        }

        public Deposit Parse(DepositVO origin)
        {
            if (origin == null) return null;
            return new Deposit
            {
                Id = origin.Id,
                DepositName = origin.DepositName,
                Limit = origin.Limit,
                IsActive = origin.IsActive,
                AddressId = origin.AddressId,
            };
        }

        public DepositVO Parse(Deposit origin)
        {
            if (origin == null) return null;
            return new DepositVO
            {
                Id = origin.Id,
                DepositName = origin.DepositName,
                Limit = origin.Limit,
                IsActive = origin.IsActive,
                AddressId = origin.AddressId,
            };
        }

        public List<Deposit> Parse(List<DepositVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<DepositVO> Parse(List<Deposit> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}