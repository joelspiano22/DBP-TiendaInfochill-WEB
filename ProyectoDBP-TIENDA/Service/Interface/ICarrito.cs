using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Services.Interface
{
    public interface ICarrito
    {
        void add(Carrito carrito);
        IEnumerable<Carrito> GetAllCarritos();
    }
}
