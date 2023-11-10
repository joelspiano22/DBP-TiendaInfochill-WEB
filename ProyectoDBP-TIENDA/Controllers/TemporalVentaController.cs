using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        public TemporalVentaController(ITemporalVenta temporal)
        {
            _temporalVenta = temporal;
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
            return View();
        }
        public IActionResult Operacion()
        {
            
            var factura = _temporalVenta.GetAllTemporarySale();

            return View("Factura");
        }
    }
}
