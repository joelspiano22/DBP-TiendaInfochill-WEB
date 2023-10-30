using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto obj;

        public ProductoController (IProducto productoObj)
        {
            obj = productoObj;
        }
        public IActionResult Index(TbProducto producto)
        {
           return View();
            //return View();
        }
        public IActionResult VerProducto()
        {
            return View();
            
        }
        public IActionResult Carrito()
        {
            return View();
        }

        public IActionResult IndexProd()
        {
            return View(obj.GetAllProductos());
        }
        public IActionResult Comprar(string cod)
        {
            ViewData["codigo"] = obj.GetProducto(cod).IdPro;
            ViewData["descripcion"] = obj.GetProducto(cod).DesPro;
            ViewData["precio"] = obj.GetProducto(cod).PrePro;
            ViewData["stock"] = obj.GetProducto(cod).StkAct;

            return View();
        }


        [Route("producto/listar")]
        public IActionResult Listar()
        {
            return View(obj.GetAllProductos());
        }

        //grabados
        public IActionResult Agregar() 
        {
            return View();  
        }
        [Route("producto/grabar")]
        public IActionResult Grabar(TbProducto producto)
        {
            obj.Add(producto);
            return RedirectToAction("Listar");
        }


        [Route("Producto/Edit/{cod}")]
        public IActionResult Edit(string cod)
        {
            return View(obj.GetProducto(cod));
        }

        [Route("Producto/Delete/{cod}")]
        public IActionResult Delete(string cod)
        {
            obj.Delete(cod);
            return RedirectToAction("Listar");
        }

        public IActionResult EditDetails(TbProducto tbProducto)
        {
            obj.Update(tbProducto);
            return RedirectToAction("Listar");
        }

        public IActionResult ProductoPrincipal()
        {
            return View(obj.GetAllProductos());
        }

    }
}
