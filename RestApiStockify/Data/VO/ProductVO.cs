using RestApiStockify.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiStockify.Data.VO
{
    public class ProductVO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string BlobImage { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPurchased { get; set; } = true;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public long DepositId { get; set; }
        [JsonIgnore]
        public Deposit? Deposit { get; set; }
    }
}
