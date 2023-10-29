using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Services.Interface;

namespace ProyectoDBP_TIENDA.Services.Repository
{
    public class CarritoRepository : ICarrito
    {
        private List<Carrito> _Carrito = new List<Carrito>();
        public void add(Carrito carrito)
        {
            _Carrito.Add(carrito);
        }

        public IEnumerable<Carrito> GetAllCarritos()
        {
            return _Carrito;
        }
    }
}
