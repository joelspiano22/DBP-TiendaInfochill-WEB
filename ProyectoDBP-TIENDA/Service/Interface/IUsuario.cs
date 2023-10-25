using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IUsuario
    {
        //si contraseña
        TbUsuario GetValidarUsuarioCreado(TbUsuario usuario);
        //no contraseña
        TbUsuario GetValidarUsuario(TbUsuario usuario);
        IEnumerable<TbUsuario> GetAllUsuario();
        //Crear contra
        void Add(TbUsuario password);
    }
}