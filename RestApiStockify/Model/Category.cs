using RestApiStockify.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiStockify.Model
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        [Column("name_category")]
        public string NameCategory {  get; set; }
    }
}
