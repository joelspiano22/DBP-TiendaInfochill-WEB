using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
using ProyectoDBP_TIENDA.Service.Repository;

namespace ProyectoDBP_TIENDA.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        private readonly IFactura _facturaRepository;
        private readonly IDetalleFactura _detalleFacturaRepository;
        public TemporalVentaController(ITemporalVenta temporal,IFactura factura, IDetalleFactura detalle)
        {
            
            _temporalVenta = temporal;
            _facturaRepository = factura;
            _detalleFacturaRepository = detalle;
        }
     
        public IActionResult Index(TemporalVenta temporal)
       {
            
            var existingItem = _temporalVenta.GetByProductId(temporal.IdPro);
            if (existingItem != null)
            {
                existingItem.cantidad += temporal.cantidad;
            }
            else
            {
                _temporalVenta.add(temporal);
            }
            return RedirectToAction("ProductoPrincipal", "Producto");
       }
     
        public IActionResult VerCarrito()
        {
            return View(_temporalVenta.GetAllTemporarySale());
        }
        public IActionResult Factura()
        {
            return View("DetalleFactura", "Index");
        }

   
        public IActionResult Operacion()
        {
            var objSesion = HttpContext.Session.GetString("sesionUsuario");

            if (objSesion != null)
            {
                // Deserializar el objeto
                var objSesionUsuario = JsonConvert.DeserializeObject<TbUsuario>(objSesion);

                // Obtener el código de usuario
                int codUsuario = objSesionUsuario.CodUsu;

                // Crear una nueva factura asociada al usuario
                TbFactura factura = _facturaRepository.CrearFactura(codUsuario);
                // Obtener los productos del carrito desde la tabla temporal
                List<TemporalVenta> productosEnCarrito = _temporalVenta.GetAllTemporarySale().ToList();


                // Iterar sobre los productos en el carrito y crear los detalles de la factura
                foreach (var producto in productosEnCarrito)
                {
                    TbDetalleFactura detalleFactura = new TbDetalleFactura
                    {
                        IdFac = factura.IdFac,
                        IdPro = producto.IdPro,
                        CanVen = producto.cantidad,
                        PreVen = producto.PrePro
                    };

                    _detalleFacturaRepository.CrearDetalleFactura(detalleFactura);

                }

                return RedirectToAction("ProductoPrincipal", "Producto");

            }
            else
            {
                return RedirectToAction("Index", "Usuario");
            }
        }


        //EDIT
        [Route("TemporalVenta/Edit/{cod}")]
        public IActionResult Edit(int cod)
        {
            return View(_temporalVenta.GetProducto(cod));
        }
        public IActionResult EditDetails(TemporalVenta producto)
        {
            _temporalVenta.Update(producto);
            return RedirectToAction("VerCarrito");
        }


        //DELETE
 
        public IActionResult Delete(int cod)
        {
            _temporalVenta.Delete(cod);
            return RedirectToAction("VerCarrito");
        }
    }
}

