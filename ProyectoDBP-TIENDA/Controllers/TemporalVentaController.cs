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
        private BdInfochill bdChill = new BdInfochill();
        private readonly ITemporalVenta _temporalVenta;
        private readonly IFactura _facturaRepository;
        private readonly IDetalleFactura _detalleFacturaRepository;
        private readonly IProducto _producto;
        public TemporalVentaController(ITemporalVenta temporal,IFactura factura, IDetalleFactura detalle, IProducto producto)
        {
            
            _temporalVenta = temporal;
            _facturaRepository = factura;
            _detalleFacturaRepository = detalle;
            _producto = producto;
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

                var objSesionUsuario = JsonConvert.DeserializeObject<TbUsuario>(objSesion);

                int codUsuario = objSesionUsuario.CodUsu;
                TbFactura factura = _facturaRepository.CrearFactura(codUsuario);
                List<TemporalVenta> productosEnCarrito = _temporalVenta.GetAllTemporarySale().ToList();

                foreach (var productoEnCarrito in productosEnCarrito)
                {

                    TbProducto producto = _producto.GetProducto(productoEnCarrito.IdPro);

                    if (producto != null && producto.StkAct >= productoEnCarrito.cantidad)
                    {
                        TbDetalleFactura detalleFactura = new TbDetalleFactura
                        {
                            IdFac = factura.IdFac,
                            IdPro = productoEnCarrito.IdPro,
                            CanVen = productoEnCarrito.cantidad,
                            PreVen = productoEnCarrito.PrePro
                        };

                        producto.StkAct -= productoEnCarrito.cantidad;bdChill.SaveChanges();
                        // Agregar el detalle de la factura a la base de datos
                        _detalleFacturaRepository.CrearDetalleFactura(detalleFactura);
                    }
                    else
                    {
                        // Manejar el caso donde no hay suficiente stock
                        // Puedes redirigir a una página de error o realizar alguna acción específica
                        return RedirectToAction("Error");
                    }
                }
                _temporalVenta.clear();
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
            return RedirectToAction("VerCarrito","TemporalVenta");
        }
    }
}

