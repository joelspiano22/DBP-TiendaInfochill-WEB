using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private BdInfochill bdChill = new BdInfochill();
        public IEnumerable<TbUsuario> GetAllUsuario()
        {
            return bdChill.TbUsuarios;
        }

        //CREAR CONTRASEÑA
        public void Add(TbUsuario password)
        {
            try
            {
                bdChill.TbUsuarios.Add(password);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Cuando quiere crear contraseña, primero valida codAlum CREADO
        public TbUsuario GetValidarUsuario(TbUsuario usuario)
        {
            var obj = (from tusuario in bdChill.TbUsuarios
                       where tusuario.CodCliente == usuario.CodCliente &&
                                tusuario.ContraUsu == usuario.ContraUsu
                       select tusuario).FirstOrDefault();
            return obj;
        }


        //Valida cuando se crea contra
        public TbUsuario GetValidarUsuarioCreado(TbUsuario usuario)
        {
            var obj = (from tusuario in bdChill.TbUsuarios
                       where tusuario.CodCliente == usuario.CodCliente &&
                                tusuario.ContraUsu == usuario.ContraUsu
                       select tusuario).FirstOrDefault();
            return obj;
        }
    }
}
