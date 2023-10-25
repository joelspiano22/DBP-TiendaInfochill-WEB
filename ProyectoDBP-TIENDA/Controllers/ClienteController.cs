using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICliente objCliente;
        public ClienteController(ICliente obj)
        {
            objCliente = obj;

        }


        public IActionResult Index()
        {
            return View();
        }


        //LISTAR
        [Route("cliente/listar")]
        public IActionResult Listar()
        {
            return View(objCliente.GetAllClientes());
        }


        //GRABAR
        public IActionResult Agregar()
        {
            return View();
        }
        public IActionResult Grabar(TbCliente cliente)
        {
            objCliente.Add(cliente);
            return RedirectToAction("Listar");
        }



        //EDIT

        [Route("Cliente/Edit/{cod}")]
        public IActionResult Edit(string cod)
        {
            return View(objCliente.GetCliente(cod));
        }
        public IActionResult EditDetails(TbCliente tbCliente)
        {
            objCliente.Update(tbCliente);
            return RedirectToAction("Listar");
        }


        //DELETE

        [Route("Cliente/Delete/{cod}")]
        public IActionResult Delete(string cod)
        {
            objCliente.Delete(cod);
            return RedirectToAction("Listar");
        }

    }
}
