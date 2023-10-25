using ProyectoDBP_TIENDA.Models;
using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA.Service.Interface;
using ProyectoDBP_TIENDA.Service.Repository;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin obj;

        public AdminController(IAdmin adminObj) { 
            obj=adminObj;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult vistaClientes() { 
            return View();
        }
        public IActionResult vistaProductos()
        {
            return View();
        }
        public IActionResult vistaProveedores()
        {
            return View();
        }
        public IActionResult vistaTrabajadores()
        {
            return View();
        }


        //clientes productos proveedores trabajadores
    }
}
