using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedores objP;

        public ProveedorController(IProveedores proveedorObj)
        {
            objP = proveedorObj;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Route("proveedor/listar")]
        public IActionResult Listar()
        {
            return View(objP.GetAllProveedores());
        }
        //grabados
        public IActionResult Agregar() 
        {
            return View();
        }

        [Route("proveedor/grabar")]
        public IActionResult Grabar(TbProveedor provee)
        {
            objP.Add(provee);
            //return View("Producto");
            return RedirectToAction("Listar");
        }

        //editados
        [Route("proveedor/Edit/{cod}")]
        public IActionResult Edit(string cod)
        {
            return View(objP.GetProveedor(cod));
        }
        public IActionResult EditDetails(TbProveedor tbprovee)
        {
            objP.Update(tbprovee);
            return RedirectToAction("Listar");
        }

        //borrados
        [Route("proveedor/Delete/{cod}")]
        public IActionResult Delete(string cod)
        {
            objP.Delete(cod);
            return RedirectToAction("Listar");
        }

     
    }
}
