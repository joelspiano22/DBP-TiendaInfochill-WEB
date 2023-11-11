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
            var obj = (from tempo in bdChill.TbProductos
                       where tempo.IdPro == id
                       select tempo).Single();
            bdChill.TbProductos.Remove(obj);//delete from <tabla> where <campo>=id
            bdChill.SaveChanges();
        }

        
        public IEnumerable<TemporalVenta> GetAllTemporarySale()
        {
            return _temporalVentaList;
        }

        public TbProducto GetProducto(int id)
        {
            var obj = (from tempo in bdChill.TbProductos
                       where tempo.IdPro == id
                       select tempo).Single();
            return obj;
        }

        public void Update(TbProducto productoModi)
        {
            var objModificado = (from tproducto in bdChill.TbProductos
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
                bdChill.SaveChanges();
            }
        }
    }
}
