
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class RelacionFac : IRelacionesFac
    {
        private readonly IFactura _factura;
        private readonly IDetalleFactura _detalleFactura;

        public RelacionFac()
        {
        }

        public RelacionFac(IFactura facturaRepository, IDetalleFactura detalleFacturaRepository)
        {
            _factura = facturaRepository;
            _detalleFactura = detalleFacturaRepository;
        }

        public void AgregarFacturaConDetalle(TbFactura factura, TbDetalleFactura detalleFactura)
        {
            _factura.Add(factura);
            detalleFactura.IdFac = factura.IdFac; // Asigna el IdFac generado al DetalleFactura
            _detalleFactura.Add(detalleFactura);
        }
    }
}
