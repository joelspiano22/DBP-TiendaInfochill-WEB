using ProyectoDBP_TIENDA.Controllers;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Repository;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface ITemporalVenta
    {
        void add(TemporalVenta temporalVenta);
        IEnumerable<TemporalVenta> GetAllTemporarySale();
        void Update(TemporalVenta producto);
        void Delete(int id);
        TemporalVenta GetProducto(int cod);
        TemporalVenta GetByProductId(int productId);
        void clear();
    }
}
