using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using ProyectoDBP_TIENDA.Service.Repository;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        private readonly IFactura _facturaRepository;
        private readonly IDetalleFactura _detalleFacturaRepository;
        public TemporalVentaController(ITemporalVenta temporal,IFactura factura, IDetalleFactura detalle)
        {
            
            _temporalVenta = temporal;
            this._facturaRepository = factura;
            this._detalleFacturaRepository = detalle;
        }
       public IActionResult Index(TemporalVenta temporal)
       {
            _temporalVenta.add(temporal);

            return RedirectToAction("ProductoPrincipal", "Producto");
       }
        public IActionResult VerCarrito()
        {
            return View(_temporalVenta.GetAllTemporarySale());
        }
        public IActionResult Factura()
        {
            return View("DetalleFactura", "Index");
        }
        public IActionResult Operacion(int id)
        {
            //ViewBag.ListaDeFactura = _facturaRepository.GetAllFactura();
            //ViewBag.ListaDetalleFacturas = _detalleFacturaRepository.GetAllDetalleFacturas();


            
            TbFactura factura = new TbFactura();
            TbDetalleFactura detalleFactura = new TbDetalleFactura()
            {
                IdFacNavigation = factura // Set the correct IdFac for the foreign key
                                   // Set other properties
            };

            // Populate factura and detalleFactura properties from your temporal data

            _facturaRepository.Add(factura);
            _detalleFacturaRepository.Add(detalleFactura);

            // Redirect or perform any other action after saving data
            return RedirectToAction("ProductoPrincipal", "Producto");

        }

        //EDIT
        [Route("TemporalVenta/Edit/{cod}")]
        public IActionResult Edit(int cod)
        {
            return View(_temporalVenta.GetProducto(cod));
        }
        public IActionResult EditDetails(TemporalVenta producto)
        {
            _temporalVenta.Update(producto);
            return RedirectToAction("VerCarrito");
        }


        //DELETE
        [Route("TemporalVenta/Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            _temporalVenta.Delete(cod);
            return RedirectToAction("VerCarrito");
        }
    }
}


/*if(_facturaRepository.IdFac != null)
{
    _facturaRepository.IdFac = Idfac + 1;
    _facturaRepository.FechaReg = DateTime.Now;
    _facturaRepository.IdUsu = CodUsuNavigation;
}
else
{
    _facturaRepository.IdFac = 1;
    _facturaRepository.FechaReg = DateTime.Now;
    _facturaRepository.IdUsu = CodUsuNavigation;
}*/