using ProyectoDBP_TIENDA.Models;

namespace ProyectoDBP_TIENDA.Service.Interface
{
    public interface IUsuario
    {
        //mantenimientos
        void Add(TbUsuario usuario);
        void Update(TbUsuario usuario);
        //completo
        void UpdateUsuario(TbUsuario usuario);
        void Delete(string id);
        TbUsuario GetUsuario(string id);

        TbUsuario GetValidarUsuarioCreado(TbUsuario usuario);

        //no contraseña
        TbUsuario GetValidarUsuario(TbUsuario usuario);


        IEnumerable<TbUsuario> GetAllUsuario();

    }
}