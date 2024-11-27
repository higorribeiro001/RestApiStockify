using RestApiStockify.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestApiStockify.Data.VO
{
    public class DepositVO
    {
        public long Id { get; set; }
        public string DepositName { get; set; }
        public int Limit { get; set; }
        public bool IsActive { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
    }
}
