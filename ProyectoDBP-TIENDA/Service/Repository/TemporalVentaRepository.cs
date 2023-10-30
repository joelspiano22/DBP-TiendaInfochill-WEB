using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class TemporalVentaRepository : ITemporalVenta
    {
        private BdInfochill bd = new BdInfochill();
        private List<TemporalVenta> _temporalVentaList = new List<TemporalVenta>();
        public void add(TemporalVenta temporalVenta)
        {
            _temporalVentaList.Add(temporalVenta);
        }

        public IEnumerable<TemporalVenta> GetAllTemporarySale()
        {
            return _temporalVentaList;
        }

        public void Update(TbProducto productoModi)
        {
            var objModificado = (from tproducto in bd.TbProductos
                                 where tproducto.IdPro == productoModi.IdPro
                                 select tproducto).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.IdPro = productoModi.IdPro;
                objModificado.DesPro = productoModi.DesPro;
                objModificado.PrePro = productoModi.PrePro;
                objModificado.StkAct = productoModi.StkAct;
                objModificado.StkMin = productoModi.StkMin;
                objModificado.CatePro = productoModi.CatePro;
                bd.SaveChanges();
            }
        }
    }
}
