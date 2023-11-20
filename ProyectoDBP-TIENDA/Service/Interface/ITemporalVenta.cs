using ProyectoDBP_TIENDA.Models;
namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface ITemporalVenta
    {
        void add(TemporalVenta temporalVenta);
        IEnumerable<TemporalVenta> GetAllTemporarySale();
        void Update(TemporalVenta producto);
        void Delete(int id);
        TemporalVenta GetProducto(int id);
        TemporalVenta GetByProductId(int productId);
    }
}
