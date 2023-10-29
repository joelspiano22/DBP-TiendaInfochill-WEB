﻿using Microsoft.AspNetCore.Mvc;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
namespace ProyectoDBP_TIENDA.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        public TemporalVentaController(ITemporalVenta temporal)
        {
            _temporalVenta = temporal;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(TemporalVenta temporal)
        {
            _temporalVenta.add(temporal);

            return RedirectToAction("Index", "Producto");
        }
        public IActionResult VerCarrito()
        {
            return View(_temporalVenta.GetAllTemporarySale());
        }
    }
}
