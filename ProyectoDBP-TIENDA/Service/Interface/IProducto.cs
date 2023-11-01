using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IProducto
    {
        IEnumerable<TbProducto> GetAllProductos();
        void Add(TbProducto producto);
        void Update(TbProducto producto);
        void Delete(int id);
        TbProducto GetProducto(int id);
    }
}
