using ProyectoDBP_TIENDA.Models;
using ProyectoDBP_TIENDA.Service.Interface;

namespace ProyectoDBP_TIENDA.Service.Repository
{
    public class ClienteRepository : ICliente
    {
        private BdInfochill bdChill = new BdInfochill();

        public IEnumerable<TbCliente> GetAllClientes()
        {
            return bdChill.TbClientes;
        }
        public void Add(TbCliente cliente)
        {
            try
            {
                bdChill.TbClientes.Add(cliente);
                bdChill.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(int id)
        {
            var obj = (from tcliente in bdChill.TbClientes
                       where tcliente.CodCliente == id
                       select tcliente).Single();
            bdChill.TbClientes.Remove(obj);//delete from <tabla> where <campo>=id
            bdChill.SaveChanges();
        }


        public TbCliente GetCliente(int id)
        {
            var obj = (from tcliente in bdChill.TbClientes
                       where tcliente.CodCliente == id
                       select tcliente).Single();
            return obj;
        }

        public void Update(TbCliente cliModificado)
        {
            var objAModificado = (from tcliente in bdChill.TbClientes
                                  where tcliente.CodCliente == cliModificado.CodCliente
                                  select tcliente).FirstOrDefault();
            if (objAModificado != null)
            {
                objAModificado.CodCliente = cliModificado.CodCliente;
                objAModificado.NomCli = cliModificado.NomCli;
                objAModificado.ApeCli = cliModificado.ApeCli;
                objAModificado.DniCli = cliModificado.DniCli;
                objAModificado.TlfCli = cliModificado.TlfCli;
                objAModificado.CorreoCli = cliModificado.CorreoCli;
                objAModificado.Estado = cliModificado.Estado;
                objAModificado.IdUsu = cliModificado.IdUsu;
                bdChill.SaveChanges();
            }
        }
    }
}
