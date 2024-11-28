using RestApiStockify.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace RestApiStockify.Model
{
    [Table("deposits")]
    public class Deposit : BaseEntity
    {
        [Column("deposit_name")]
        [Required]
        [StringLength(100)]
        public string DepositName { get; set; }
        [Column("limit")]
        [Required]
        public int Limit { get; set; } = 50;
        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; } = true;
        [ForeignKey("address_id")]
        [Required]
        public long AddressId { get; set; }

        public Address? Address { get; set; }
        public List<Product>? Products { get; set; }
    }
}
