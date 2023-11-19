using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class FacturaRepository : IFactura
    {
        private BdInfochill bdChill = new BdInfochill();


        public TbFactura GetFactura(int id)
        {
            var obj = (from tFac in bdChill.TbFacturas
                       where tFac.IdFac == id
                       select tFac).Single();
            return obj;
        }
        public void Add(TbFactura factura)
        {
            try
            {
                bdChill.TbFacturas.Add(factura);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<TbFactura> GetAllFactura()
        {
            return bdChill.TbFacturas.ToList();
        }
        public TbFactura CrearFactura(int codUsuario)
        {       
            TbFactura factura = new TbFactura
            {
                CodUsu = codUsuario,
                FechaReg = DateTime.Now
            };

            bdChill.TbFacturas.Add(factura);
            bdChill.SaveChanges();

            return factura;
        }
    }
}

