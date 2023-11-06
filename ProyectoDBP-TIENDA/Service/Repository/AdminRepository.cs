using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class AdminRepository : IAdmin
    {
        private BdInfochill bdChill = new BdInfochill();

        public IEnumerable<TbAdmin> GetAllAdmin()
        {
            return bdChill.TbAdmins;
        }

        //añadir
        public void Add(TbAdmin admin)
        {
            try
            {
                bdChill.TbAdmins.Add(admin);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, "existe, no puede crear contraseña");
            }
        }
        //eliminar
        public void Delete(int id)
        {
            var obj = (from tadmin in bdChill.TbAdmins
                       where tadmin.IdAdmin == id
                       select tadmin).Single();
            bdChill.TbAdmins.Remove(obj);//delete from <tabla> where <campo>=id
            bdChill.SaveChanges();
        } 

        //return obj= idAdmin == id
        public TbAdmin GetAdmin(int id)
        {
            var obj = (from tadmin in bdChill.TbAdmins
                       where tadmin.IdAdmin == id
                       select tadmin).Single();
            return obj;
        }

        public void Update(TbAdmin adminModificado)
        {
            var objAModificado = (from tadmin in bdChill.TbAdmins
                                  where tadmin.IdAdmin == adminModificado.IdAdmin
                                  select tadmin).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.CodAdmin = adminModificado.CodAdmin;
                objAModificado.PassAdmin = adminModificado.PassAdmin;

                bdChill.SaveChanges();
            }
        }

        public TbAdmin Validar(TbAdmin usuario)
        {
            var obj = (from tadmin in bdChill.TbAdmins
                       where tadmin.CodAdmin == usuario.CodAdmin &&
                                tadmin.PassAdmin == usuario.PassAdmin
                       select tadmin).FirstOrDefault();
            return obj;
        }
    }
}
