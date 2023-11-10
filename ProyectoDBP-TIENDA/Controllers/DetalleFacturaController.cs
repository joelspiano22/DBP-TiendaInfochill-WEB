using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class DetalleFacturaController : Controller
    {
        private readonly IDetalleFactura objFac;
        public DetalleFacturaController(IDetalleFactura obj)
        {
            objFac = obj;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View(objFac.GetAllFacturas());
        }

        public IActionResult Agregar()
        {
            return View();
        }
        public IActionResult Grabar(TbDetalleFactura fac)
        {
            objFac.Add(fac);
            return RedirectToAction("Listar");
        }

        public IActionResult Edit(int cod)
        {
            return View(objFac.GetFactura(cod));
        }
        public IActionResult EditDetails(TbDetalleFactura fac)
        {
            objFac.Update(fac);
            return RedirectToAction("Listar");
        }
        public IActionResult Delete(int cod)
        {
            objFac.Delete(cod);
            return RedirectToAction("Listar");
        }

    }
}
