using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuario;
        public UsuarioController(IUsuario usuario)
        {
            _usuario = usuario;
        }
        public IActionResult Index()
        {
            return View();
        }

        //CREAR CONTRA
        public IActionResult CrearContraseña(TbUsuario password)
        {
            _usuario.Add(password);
            return RedirectToAction("View");
        }

        //Cuando quiere crear contraseña, primero valida codAlum CREADO
        public IActionResult ValidarCodigo(TbUsuario usuario)
        {
            var objUsuario = _usuario.GetValidarUsuarioCreado(usuario);
            if (objUsuario != null)
            {
                HttpContext.Session.SetString("sesionUsuario", JsonConvert.SerializeObject(objUsuario));
                return RedirectToAction("CrearContraseña");
            }
            else
            {
                return View("ValidarCodigo");
            }
        }

        //Valida cuando se crea contra
        public IActionResult ValidarCreado(TbUsuario usuario)
        {
            var objUsuario = _usuario.GetValidarUsuarioCreado(usuario);
            if (objUsuario != null)
            {
                HttpContext.Session.SetString("sesionUsuario", JsonConvert.SerializeObject(objUsuario));
                return RedirectToAction("Index", "Producto");
            }
            else
            {
                return View("Index");
            }
        }

    }

}
