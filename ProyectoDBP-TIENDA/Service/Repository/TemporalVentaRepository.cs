using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class TemporalVentaRepository : ITemporalVenta
    {
        private BdInfochill bdChill = new BdInfochill();
        private List<TemporalVenta> _temporalVentaList = new List<TemporalVenta>();
        public void add(TemporalVenta temporalVenta)
        {
            _temporalVentaList.Add(temporalVenta);
        }
        public void Delete(int id)
        {
            var obj = _temporalVentaList.SingleOrDefault(temp => temp.IdPro == id);

            if (obj != null)
            {
                _temporalVentaList.Remove(obj);
            }
        }


        public IEnumerable<TemporalVenta> GetAllTemporarySale()
        {
            return _temporalVentaList;
        }

        public TemporalVenta GetProducto(int id)
        {
            var obj = _temporalVentaList.SingleOrDefault(temp => temp.IdPro == id);
            return obj;
        }
        public void Update(TemporalVenta productoModi)
        {
            // Buscar el objeto en la colección en memoria (TemporalVenta)
            var objModificado = _temporalVentaList.SingleOrDefault(temp => temp.IdPro == productoModi.IdPro);

            if (objModificado != null)
            {
                // Actualizar propiedades en memoria
                objModificado.IdPro = productoModi.IdPro;
                objModificado.DesPro = productoModi.DesPro;
                objModificado.PrePro = productoModi.PrePro;
                objModificado.StkAct = productoModi.StkAct;
                objModificado.cantidad = productoModi.cantidad;

                // No necesitas guardar cambios en la base de datos ya que estás trabajando en memoria.
            }
        }

    }
}
