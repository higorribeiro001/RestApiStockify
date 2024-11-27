using RestApiStockify.Data.VO;
using RestApiStockify.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiStockify.Model
{
    [Table("address")]
    public class Address : BaseEntity
    {
        [Column("cep")]
        [Required]
        [StringLength(9)]
        public string Cep {  get; set; }
        [Column("address_value")]
        [Required]
        [StringLength(255)]
        public string AddressValue { get; set; }
        [Column("neighborhood")]
        [Required]
        [StringLength(200)]
        public string Neighborhood { get; set; }
        [Column("city")]
        [Required]
        [StringLength(200)]
        public string City { get; set; }
        [Column("uf")]
        [Required]
        [StringLength(3)]
        public string Uf { get; set; }
        [Column("country")]
        [Required]
        [StringLength(120)]
        public string Country { get; set; }
        [Column("latitude")]
        [Required]
        public double Latitude { get; set; }
        [Column("longitude")]
        [Required]
        public double Longitude { get; set; }
        public Deposit Deposit { get; set; }
    }
}
