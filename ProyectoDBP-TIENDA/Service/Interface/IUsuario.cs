using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IUsuario
    {
        void Add(TbUsuario usuario);
        void Update(TbUsuario usuario);
        void Delete(int id);
        TbUsuario GetUsuario(int id);

        void AddContra(TbUsuario password);
        //si contraseña
        TbUsuario GetValidarUsuarioCreado(TbUsuario usuario);
        //no contraseña
        TbUsuario GetValidarUsuario(TbUsuario usuario);

        IEnumerable<TbUsuario> GetAllUsuario();

    }
}