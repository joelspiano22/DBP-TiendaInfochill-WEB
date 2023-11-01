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
        public IActionResult ValidarCodigo()
        {
            return View();
        }
        

        //REGISTRAR
        //Cuando quiere crear contraseña, primero valida codAlum CREADO
        public IActionResult Validar(TbUsuario usuario)
        {
            var objUsuario = _usuario.GetValidarUsuario(usuario);

            if (objUsuario != null)
            {
                HttpContext.Session.SetString("sesionUsuario", JsonConvert.SerializeObject(objUsuario));
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View("Agregar");
            }
        }

        //CREAR CONTRA
        public IActionResult CrearContraseña(TbUsuario password)
        {
            _usuario.AddContra(password);
            return RedirectToAction("View");
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


        /*---MANTENIMIENTOS-----------------------------------------------------------------*/
        //LISTAR
        [Route("usu/listar")]
        public IActionResult Listar()
        {
            return View(_usuario.GetAllUsuario());
        }


        //GRABAR
        public IActionResult Agregar()
        {
            return View();
        }

        public IActionResult Grabar(TbUsuario usuario)
        {
            
            _usuario.Add(usuario);
            return RedirectToAction("Listar");
        }



        //EDIT

        [Route("usu/Edit/{cod}")]
        public IActionResult Edit(int cod)
        {
            return View(_usuario.GetUsuario(cod));
        }
        public IActionResult EditDetails(TbUsuario tbUsu)
        {
            _usuario.Update(tbUsu);
            return RedirectToAction("Listar");
        }


        //DELETE

        [Route("usu/Delete/{cod}")]
        public IActionResult Delete(int cod)
        {
            _usuario.Delete(cod);
            return RedirectToAction("Listar");
        }

    }

}
