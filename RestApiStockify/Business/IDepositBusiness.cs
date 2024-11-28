using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Business
{
    public interface IDepositBusiness
    {
        DepositVO Create(DepositVO deposit);
        DepositVO Update(DepositVO deposit);
        Deposit Delete(long id);
    }
}
