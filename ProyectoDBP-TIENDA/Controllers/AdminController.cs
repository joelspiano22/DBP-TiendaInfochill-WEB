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
        public IActionResult vistaUsuario()
        {
            return View();
        }
        public IActionResult Login()  
        {
            return View();
        }
        /*---Validar-----------------------------------------------------------------*/
        public IActionResult Validar(TbAdmin admin)
        {
            var ObjAdmin = objAdmin.Validar(admin);
            if (ObjAdmin != null)
            {
                HttpContext.Session.SetString("sesionAdmin", JsonConvert.SerializeObject(ObjAdmin));
                return RedirectToAction("Login", "Admin");
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
