using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Business
{
    public interface IAddressBusiness
    {
        AddressVO Create(AddressVO address);
        AddressVO FindByID(long id);
        List<AddressVO> FindAll();
        AddressVO Update(AddressVO address);
        Address Delete(long id);
    }
}
