using RestApiStockify.Data.Converter.Contract;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Data.Converter.Implementations
{
    public class AddressConverter : IParser<AddressVO, Address>, IParser<Address, AddressVO>
    {
        public Address Parse(AddressVO origin)
        {
            if (origin == null) return null;
            return new Address
            {
                Id = origin.Id,
                Cep = origin.Cep,
                AddressValue = origin.AddressValue,
                Neighborhood = origin.Neighborhood,
                City = origin.City,
                Uf = origin.Uf,
                Country = origin.Country,
                Latitude = origin.Latitude,
                Longitude = origin.Longitude,
            };
        }

        public AddressVO Parse(Address origin)
        {
            if (origin == null) return null;
            return new AddressVO
            {
                Id = origin.Id,
                Cep = origin.Cep,
                AddressValue = origin.AddressValue,
                Neighborhood = origin.Neighborhood,
                City = origin.City,
                Uf = origin.Country,
                Country = origin.Country,
                Latitude = origin.Latitude,
                Longitude = origin.Longitude,
            };
        }

        public List<Address> Parse(List<AddressVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<AddressVO> Parse(List<Address> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
