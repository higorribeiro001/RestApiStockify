using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestApiStockify.Data.VO
{
    public class AddressVO
    {
        public long Id { get; set; }
        public string? Cep { get; set; }
        public string? AddressValue { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? Uf { get; set; }
        public string? Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
