using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IFactura
    {
        IEnumerable<TbFactura> GetAllFactura();
    }
}
