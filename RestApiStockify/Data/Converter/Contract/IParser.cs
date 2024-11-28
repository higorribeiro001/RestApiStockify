using RestApiStockify.Data.VO;
using RestApiStockify.Model;

namespace RestApiStockify.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
