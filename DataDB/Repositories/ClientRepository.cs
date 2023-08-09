using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private DataClasses1DataContext data;

        public ClientRepository()
        {
            data = new DataClasses1DataContext();
        }

        public void add(ClientTable c)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        /*public IEnumerable<ClientTable> GetAll()
        {
            var clientList = (from c in data.Cliente
                                select new ClientTable()
                                {
                                    ID = c.idCliente,
                                    nombre = c.nombre,
                                    direccion = c.direccion,
                                    mail = c.mail,
                                    telefono = c.telefono,
                                    habilitado = c.habilitado
                                });
            return clientList;
        }*/
        /*
        public IEnumerable<ClientTable> GetByValue(string s)
        {
            var clientList = data.Cliente
                                .Where(c => c.nombre == s)
                                .Select(c => new ClientTable()
                                {
                                    ID = c.idCliente,
                                    nombre = c.nombre,
                                    direccion = c.direccion,
                                    mail = c.mail,
                                    telefono = c.telefono,
                                    habilitado = c.habilitado
                                });
            return clientList;
        }*/

        public void update(ClientTable c)
        {
            throw new NotImplementedException();
        }
    }
}
