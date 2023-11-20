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
        //añadir
        public void Add(TbUsuario usuario)
        {
            try
            {
                 bdChill.TbUsuarios.Add(usuario);
                 bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "");
            }
        }
        public void AddContra(TbUsuario usuario)
        {
            var usu= usuario.ContraUsu;
            try
            {
                bdChill.TbUsuarios.Add(usuario);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "existe, no puede crear contraseña");
            }
        }
        //eliminar
        public void Delete(string id)
        {
            var obj = (from tusu in bdChill.TbUsuarios
                       where tusu.IdUsu == id
                       select tusu).Single();
            bdChill.TbUsuarios.Remove(obj);//delete from <tabla> where <campo>=id
            bdChill.SaveChanges();
        }

        //return obj= codCli == id
        public TbUsuario GetUsuario(string id)
        {
            var obj = (from tusu in bdChill.TbUsuarios
                       where tusu.IdUsu == id
                       select tusu).Single();
            return obj;
        }
        public TbUsuario GetUsuarioEditar(string id)
        {
            var obj = (from tusu in bdChill.TbUsuarios
                       where tusu.IdUsu == id
                       select tusu).Single();
            return obj;
        }

        //actualiza
        public void Update(TbUsuario usuModificado)
        {
            var objAModificado = (from tusu in bdChill.TbUsuarios
                                  where tusu.IdUsu == usuModificado.IdUsu
                                  select tusu).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.IdUsu = usuModificado.IdUsu;
                objAModificado.ContraUsu = usuModificado.ContraUsu;

                bdChill.SaveChanges();
            }
        }
        public void UpdateUsuario(TbUsuario usuModificado)
        {
            var objAModificado = (from tusu in bdChill.TbUsuarios
                                  where tusu.IdUsu == usuModificado.IdUsu
                                  select tusu).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.IdUsu = usuModificado.IdUsu;
                objAModificado.ContraUsu = usuModificado.ContraUsu;
                objAModificado.NomCli = usuModificado.NomCli;
                objAModificado.ApeCli = usuModificado.ApeCli;
                objAModificado.DniCli = usuModificado.DniCli;
                objAModificado.TlfCli = usuModificado.TlfCli;
                objAModificado.CorreoCli = usuModificado.CorreoCli;
                objAModificado.Estado = usuModificado.Estado;
                bdChill.SaveChanges();
            }
        }

        //REGISTRAR
        //Cuando quiere crear contraseña, primero valida Idusu CREADO
        public TbUsuario GetValidarUsuario(TbUsuario usuario)
        {
            var obj = (from tusuario in bdChill.TbUsuarios
                       where tusuario.IdUsu == usuario.IdUsu
                       select tusuario).FirstOrDefault();
            return obj;
        }


        //Valida cuando se crea contra
        public TbUsuario GetValidarUsuarioCreado(TbUsuario usuario)
        {
            var obj = (from tusuario in bdChill.TbUsuarios
                       where tusuario.IdUsu == usuario.IdUsu &&
                                tusuario.ContraUsu == usuario.ContraUsu
                       select tusuario).FirstOrDefault();
            return obj;
        }

      
    }
}
