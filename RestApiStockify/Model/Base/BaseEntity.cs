using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiStockify.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
