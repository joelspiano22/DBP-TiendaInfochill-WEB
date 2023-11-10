using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class DetalleFacturaRepository : IDetalleFactura
    {
        private BdInfochill bdChill = new BdInfochill();

        public IEnumerable<TbDetalleFactura> GetAllFacturas()
        {
            return bdChill.TbDetalleFacturas;
        }

        public void Add(TbDetalleFactura fac)
        {
            try
            {
                bdChill.TbDetalleFacturas.Add(fac);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {
            var obj = (from tfac in bdChill.TbDetalleFacturas
                       where tfac.IdFac == id
                       select tfac).Single();
            bdChill.TbDetalleFacturas.Remove(obj);//delete from <tabla> where <campo>=id
            bdChill.SaveChanges();
        }

        public TbDetalleFactura GetFactura(int id)
        {
            var obj = (from tfac in bdChill.TbDetalleFacturas
                       where tfac.IdFac == id
                       select tfac).Single();
            return obj;
        }

        public void Update(TbDetalleFactura facModificado)
        {
            var objModificado = (from tfac in bdChill.TbDetalleFacturas
                                 where tfac.IdFac == facModificado.IdFac
                                  select tfac).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.IdFac = facModificado.IdFac;
                objModificado.CodUsu = facModificado.CodUsu;
                objModificado.IdPro = facModificado.IdPro;
                objModificado.CanVen = facModificado.CanVen;
                objModificado.PreVen = facModificado.PreVen;
                bdChill.SaveChanges();
            }
        }
    }
}
