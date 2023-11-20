using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdmin objAdmin;

        public AdminController(IAdmin adminObj) {
            objAdmin = adminObj;
        }
        [Route("admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("admin/VistaCliente")]
        public IActionResult vistaClientes() {
            return View();
        }
        [Route("admin/VistaCliente")]
        public IActionResult vistaProductos()
        {
            return View();
        }
        [Route("admin/VistaProveedor")]
        public IActionResult vistaProveedores()
        {
            return View();
        }
        [Route("admin/VistaUsuario")]
        public IActionResult vistaUsuario()
        {
            return View();
        }
        [Route("admin/VistaDetalleFactura")]
        public IActionResult vistaDetalleFactura()
        {
            return View();
        }
        [Route("admin/Login")]
        public IActionResult Login()  
        {
            return View();
        }
        /*---Validar-----------------------------------------------------------------*/
        [Route("admin/Validar")]
        public IActionResult Validar(TbAdmin admin)
        {
            var Objadmin = objAdmin.Validar(admin); // Busca el usuario en la base de datos 

            if (Objadmin == null)
            {
                // Si el usuario no se encuentra en la base de datos index
                return View("Login");
            }
            else
            {
                return View("Index");
            }
        }


        /*---MANTENIMIENTOS-----------------------------------------------------------------*/
        //LISTAR
        [Route("admin/listar")]
        public IActionResult Listar()
        {
            return View(objAdmin.GetAllAdmin());
        }


        //GRABAR
        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Grabar(TbAdmin admin)
        {

            objAdmin.Add(admin);
            return RedirectToAction("Listar");
        }



        //EDIT

        [Route("admin/Edit/{cod}")]
        public IActionResult Edit(int cod)
        {
            return View(objAdmin.GetAdmin(cod));
        }
        public IActionResult EditDetails(TbAdmin admin)
        {
            objAdmin.Update(admin);
            return RedirectToAction("Listar");
        }


        //DELETE

        [Route("admin/Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            objAdmin.Delete(cod);
            return RedirectToAction("Listar");
        }

    }
}
