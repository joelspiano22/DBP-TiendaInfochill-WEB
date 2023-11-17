using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class DetalleFacturaRepository : IDetalleFactura
    {
        private BdInfochill bdChill = new BdInfochill();

        public IEnumerable<TbDetalleFactura> GetAllDetalleFacturas()
        {
            return bdChill.TbDetalleFacturas.ToList();
        }
        public void Add(TbDetalleFactura detalleFactura)
        {
            try
            {
                bdChill.TbDetalleFacturas.Add(detalleFactura);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public TbDetalleFactura GetDetalle(int id)
        {
            var obj = (from Tdet in bdChill.TbDetalleFacturas
                       where Tdet.IdFac == id
                       select Tdet).Single();
            return obj;
        }
    }
}
