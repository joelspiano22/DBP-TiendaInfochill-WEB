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

        public void Add(TbUsuario usuario)
        {
            try
            {
                bdChill.TbUsuarios.Add(usuario);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(string id)
        {
            var obj = (from tusu in bdChill.TbUsuarios
                       where tusu.CodCliente == id
                       select tusu).Single();
            bdChill.TbUsuarios.Remove(obj);//delete from <tabla> where <campo>=id
            bdChill.SaveChanges();
        }


        public TbUsuario GetUsuario(string id)
        {
            var obj = (from tusu in bdChill.TbUsuarios
                       where tusu.CodCliente == id
                       select tusu).Single();
            return obj;
        }

        public void Update(TbUsuario usuModificado)
        {
            var objAModificado = (from tusu in bdChill.TbUsuarios
                                  where tusu.CodCliente == usuModificado.CodCliente
                                  select tusu).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.CodCliente = usuModificado.CodCliente;
                objAModificado.ContraUsu = usuModificado.ContraUsu;

                bdChill.SaveChanges();
            }
        }




        //REGISTRAR
        //Cuando quiere crear contraseña, primero valida codAlum CREADO
        public TbUsuario GetValidarUsuario(TbUsuario usuario)
        {
            var obj = (from tusuario in bdChill.TbUsuarios
                       where tusuario.CodCliente == usuario.CodCliente
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


        //contraseña add
        public void AddContra(TbUsuario password)
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
    }
}
