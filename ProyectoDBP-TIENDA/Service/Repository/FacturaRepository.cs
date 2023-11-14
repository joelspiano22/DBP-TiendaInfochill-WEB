using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class FacturaRepository : IFactura
    {
        private BdInfochill bdChill = new BdInfochill();

        public IEnumerable<TbFactura> GetAllFactura()
        {
            return bdChill.TbFacturas.ToList();
        }
    }
}
