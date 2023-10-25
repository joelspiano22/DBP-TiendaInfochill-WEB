using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface ICliente
    {
        IEnumerable<TbCliente> GetAllClientes();
        void Add(TbCliente cliente);
        void Update(TbCliente cliente);
        void Delete(string id);
        TbCliente GetCliente(string id);
    }
}