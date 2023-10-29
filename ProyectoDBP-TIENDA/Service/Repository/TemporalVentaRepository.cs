using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class TemporalVentaRepository : ITemporalVenta
    {
        private List<TemporalVenta> _temporalVentaList = new List<TemporalVenta>();
        public void add(TemporalVenta temporalVenta)
        {
            _temporalVentaList.Add(temporalVenta);
        }

        public IEnumerable<TemporalVenta> GetAllTemporarySale()
        {
            return _temporalVentaList;
        }
    }
}
