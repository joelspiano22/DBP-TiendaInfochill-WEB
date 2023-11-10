using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IDetalleFactura
    {
        void Add(TbDetalleFactura fac);
        void Update(TbDetalleFactura facModificado);
        void Delete(int id);
        TbDetalleFactura GetFactura(int id);

        IEnumerable<TbDetalleFactura> GetAllFacturas();
    }
}
