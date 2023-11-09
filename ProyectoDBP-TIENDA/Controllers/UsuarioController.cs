using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

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
            var Objusuario = _usuario.GetValidarUsuario(usuario); // Busca el usuario en la base de datos 

            if (Objusuario.IdUsu == null)
            {
                // Si el usuario no se encuentra en la base de datos index
                return View("ValidarCodigo");
            }
            else
            {
                return View("Agregar");
            }
        }
        public IActionResult Agregar()
        {
            return View();
        }
        public IActionResult Grabar(TbUsuario usuario)
        {

            _usuario.Add(usuario);
            return RedirectToAction("Listar");
        }


        //Valida cuando se crea contra
        public IActionResult ValidarCreado(TbUsuario usuario)
        {

            var Objusuario = _usuario.GetValidarUsuarioCreado(usuario);

            if (usuario == null || usuario.IdUsu != usuario.IdUsu  &&   
                                   usuario.ContraUsu != usuario.ContraUsu  )
            {
                return RedirectToAction("Listar");
            }

            // Usuario validado correctamente
            // Almacena el usuario en la sesión
            HttpContext.Session.SetString("UsuarioId", Objusuario.ToString());

            return View("Producto","ProductoPrincipal");
        }


        /*---MANTENIMIENTOS-----------------------------------------------------------------*/
        //LISTAR
        [Route("usu/listar")]
        public IActionResult Listar()
        {
            return View(_usuario.GetAllUsuario());
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

        [Route("usu/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _usuario.Delete(id);
            return RedirectToAction("Listar");
        }

    }

}
