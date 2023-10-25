using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IProducto
    {
        IEnumerable<TbProducto> GetAllProductos();
        void Add(TbProducto producto);
        void Update(TbProducto producto);
        void Delete(string id);
        TbProducto GetProducto(string id);
    }
}
