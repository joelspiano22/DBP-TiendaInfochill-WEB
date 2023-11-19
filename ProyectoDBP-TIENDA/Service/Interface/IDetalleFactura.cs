using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IDetalleFactura
    {
        IEnumerable<TbDetalleFactura> GetAllDetalleFacturas();
        void Add(TbDetalleFactura detalleFactura); 
        TbDetalleFactura GetDetalle(int id);
        void CrearDetalleFactura(TbDetalleFactura detalleFactura);

    }
}
