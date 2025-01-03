using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApiStockify.Model.Base;

namespace RestApiStockify.Model
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(120)]
        public string? Name { get; set; }
        [Column("blob_image")]
        [Required]
        public string? BlobImage { get; set; }
        [Column("description")]
        [StringLength(255)]
        [Required]
        public string? Description { get; set; }
        [ForeignKey("category_id")]
        [Required]
        public long CategoryId { get; set; }
        public Category? Category { get; set; }
        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; } = true;
        [Column("is_purchased")]
        [Required]
        public bool IsPurchased { get; set; } = false;
        [Column("price")]
        [Required]
        public decimal Price { get; set; }
        [Column("created_at")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("deposit_id")]
        [Required]
        public long DepositId { get; set; }
        public Deposit? Deposit { get; set; }
    }
}
