using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA.Models;


using AspNetCore;

using ProyectoDBP_TIENDA.Services.Interface;

namespace WebAppVentas202301.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ICarrito carro;
        public TemporalVentaController(ICarrito temporal)
        {
            carro = temporal;
        }
        public IActionResult Index(Carrito carritr)
        {
            carro.add(carritr);

            return RedirectToAction("Index", "Producto");
        }
        public IActionResult VerCarrito()
        {
            return View(carro.GetAllCarritos());
        }
    }
}
