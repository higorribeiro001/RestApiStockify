using RestApiStockify.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiStockify.Data.VO
{
    public class ProductVO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string? ProductName { get; set; }
        public string? BlobImage { get; set; }
        public string? Description { get; set; }
        public long CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPurchased { get; set; } = false;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public long DepositId { get; set; }
        [JsonIgnore]
        public Deposit? Deposit { get; set; }
        public string? DocumentName { get; set; }
        public string? DocType { get; set; }
        public string? DocUrl { get; set; }
    }
}
