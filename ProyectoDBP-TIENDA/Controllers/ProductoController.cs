using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using ProyectoDBP_TIENDA.Service.Repository;
using Newtonsoft.Json;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProducto obj;

        public ProductoController (IProducto productoObj)
        {
            obj = productoObj;
        }
        [Route("producto/Index")]
        public IActionResult Index(TbProducto producto)
        {
           return View();
            //return View();
        }
        [Route("producto/Carrito")]
        public IActionResult Carrito()
        {
            return View();
        }
        [Route("producto/IndexProd")]
        public IActionResult IndexProd()
        {
            return View(obj.GetAllProductos());
        }
        [Route("producto/Comprar")]
        public IActionResult Comprar(int id)
        {
            ViewData["codigo"] = obj.GetProducto(id).IdPro;
            ViewData["DesPro"] = obj.GetProducto(id).DesPro;
            ViewData["PrePro"] = obj.GetProducto(id).PrePro;
            ViewData["StkAct"] = obj.GetProducto(id).StkAct;


            return View();
        }
       
        [Route("producto/listar")]
        public IActionResult Listar()
        {
            return View(obj.GetAllProductos());
        }

        [Route("producto/ADD")]
        public IActionResult Agregar() 
        {
            return View();  
        }
        [Route("producto/grabar")]
        public IActionResult Grabar(TbProducto producto, IFormFile imagenArchivo)
        {
            obj.Add(producto);
            return RedirectToAction("Listar");
        }


        [Route("Producto/Edit/{cod}")]
        public IActionResult Edit(int cod)
        {
            return View(obj.GetProducto(cod));
        }

        [Route("Producto/Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            obj.Delete(cod);
            return RedirectToAction("Listar");
        }
        [Route("producto/EditDetails")]
        public IActionResult EditDetails(TbProducto tbProducto)
        {
            obj.Update(tbProducto);
            return RedirectToAction("Listar");
        }
        [Route("producto/ProductoPrincipal")]
        public IActionResult ProductoPrincipal()
        {
            var objSesion = HttpContext.Session.GetString("sesionUsuario");
            if (objSesion != null)
            {
                //Deserializar el objeto
                var ObjSesionUsuario = JsonConvert.DeserializeObject<TbUsuario>
                                 (HttpContext.Session.GetString("sesionUsuario"));

                // Obtener el nombre y apellido del usuario
                string nombreCompleto = $"{ObjSesionUsuario.NomCli} {ObjSesionUsuario.ApeCli}";

                // Pasar el nombre completo como modelo adicional
                ViewData["NombreCompleto"] = nombreCompleto;
                return View(obj.GetAllProductos());
            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }
        [Route("producto/Nosotros")]
        public IActionResult Nosotros()
        {
            return View();
        }
        [Route("producto/Terms&Conditions")]
        public IActionResult TerminosYCondiciones()
        {
            return View();
        }
    }
}
