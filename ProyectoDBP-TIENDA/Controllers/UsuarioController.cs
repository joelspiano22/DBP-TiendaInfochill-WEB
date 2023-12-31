﻿using ProyectoDBP_TIENDA.Models;
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

        //REGISTRAR
        //Cuando quiere crear contraseña, primero valida codAlum CREADO

        public IActionResult Validar(TbUsuario usuario)
        {
            var Objusuario = _usuario.GetValidarUsuario(usuario); // Busca el usuario en la base de datos 

            if (Objusuario.IdUsu == null)
            {
                // Si el usuario no se encuentra en la base de datos index
                return RedirectToAction("ValidarCodigo");
            }
            else
            {
                return  RedirectToAction("Edit");
            }
        }


        public IActionResult ValidarCodigo()
        {
            return View();
        }

        //CREAR CONTRASEÑA
        
        public IActionResult Edit(string cod)
        {
            return View(_usuario.GetUsuario(cod));
        }

        public IActionResult EditUsuario(string cod)
        {
            return View(_usuario.GetUsuario(cod));
        }

        public IActionResult EditDetails(TbUsuario tbUsu)
        {
            _usuario.Update(tbUsu);
            return RedirectToAction("Index");
        }

        //Valida cuando se crea contra
    
        public IActionResult ValidarCreado(TbUsuario usuario)
        {
            var objUsuario = _usuario.GetValidarUsuarioCreado(usuario);
            if (objUsuario != null)
            {
                HttpContext.Session.SetString("sesionUsuario", JsonConvert.SerializeObject(objUsuario));
                return RedirectToAction("ProductoPrincipal","Producto");   
            }
            else
            {
                return View("Index","Usuario");
            } 
        }

        /*---MANTENIMIENTOS-----------------------------------------------------------------*/
   
        public IActionResult Agregar()
        {
            return View();
        }
     
        public IActionResult Grabar(TbUsuario usuario)
        {

            _usuario.Add(usuario);
            return RedirectToAction("Listar");
        }
        
        
        //LISTAR

        public IActionResult Listar()
        {
            return View(_usuario.GetAllUsuario());
        }

        //DELETE

        [Route("usu/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            _usuario.Delete(id);
            return RedirectToAction("Listar");
        }

    }

}
