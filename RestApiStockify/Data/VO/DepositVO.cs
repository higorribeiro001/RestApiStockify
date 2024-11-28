using RestApiStockify.Model;
using System.Text.Json.Serialization;

namespace RestApiStockify.Data.VO
{
    public class DepositVO
    {
        public long Id { get; set; }
        public string DepositName { get; set; }
        public int Limit { get; set; }
        public bool IsActive { get; set; }
        public long AddressId { get; set; }
        [JsonIgnore]
        public Address? Address { get; set; }
    }
}
