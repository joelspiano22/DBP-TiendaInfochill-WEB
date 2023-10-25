using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;
namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class ProveedorRepository : IProveedores
    {
        private BdInfochill bd = new BdInfochill();

        public IEnumerable<TbProveedor> GetAllProveedores()
        {
            return bd.TbProveedors;
        }
        public void Add(TbProveedor proveedor)
        {
            try
            {
                bd.TbProveedors.Add(proveedor);
                bd.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public TbProveedor GetProveedor(string id)
        {
            var obj = (from tproveedor in bd.TbProveedors
                       where tproveedor.CodProveedor == id
                       select tproveedor).Single();
            return obj;
        }

        public void Update(TbProveedor provModi)
        {
            var objModificado = (from tproveedor in bd.TbProveedors
                                 where tproveedor.CodProveedor == provModi.CodProveedor
                                 select tproveedor).FirstOrDefault();
            if (objModificado != null)
            {
                objModificado.CodProveedor = provModi.CodProveedor;
                objModificado.RazSocial = provModi.RazSocial;
                objModificado.DirProveedor = provModi.DirProveedor;
                objModificado.TlfProveedor = provModi.TlfProveedor;
                objModificado.RepVenta = provModi.RepVenta;
                bd.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            var obj = (from tproveedor in bd.TbProveedors
                       where tproveedor.CodProveedor == id
                       select tproveedor).Single();
            bd.TbProveedors.Remove(obj);
            bd.SaveChanges();
        }
    }
}