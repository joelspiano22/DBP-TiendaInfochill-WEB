using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IRelacionesFac
    {
        void AgregarFacturaConDetalle(TbFactura factura, TbDetalleFactura detalleFactura);

    }    
}
