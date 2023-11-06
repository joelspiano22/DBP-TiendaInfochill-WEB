using ProyectoDBP_TIENDA.Models;
namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IAdmin
    {
        void Add(TbAdmin admin);
        void Update(TbAdmin adminModificado);
        void Delete(int id);
        TbAdmin GetAdmin(int id);
        TbAdmin Validar(TbAdmin usuario);
        IEnumerable<TbAdmin> GetAllAdmin();

    }
}
