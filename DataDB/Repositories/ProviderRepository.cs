using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Repositories
{
    public class ProviderRepository: IProviderRepository
    {
        private DataClasses1DataContext data;

        public ProviderRepository()
        {
            data = new DataClasses1DataContext();
        }
        /*
        public void add(Provider p)
        {
            throw new NotImplementedException();
        }*/

        public void delete(int id)
        {
            throw new NotImplementedException();
        }
        /*
        public IEnumerable<Provider> GetAll()
        {
            var providerList = (from p in data.Proveedor
                               select new Provider()
                               {
                                   ID = p.idProveedor,
                                   nombre = p.nombre,
                                   direccion = p.direccion,
                                   mail = p.mail,
                                   telefono = p.telefono,
                                   habilitado = p.habilitado
                               });
            return providerList;
        }*/
        /*
        public IEnumerable<Provider> GetByValue(string s)
        {
            var providerList = data.Proveedor
                                .Where(p => p.nombre == s)
                                .Select(pdt => new Provider()
                                {
                                    ID = pdt.idProveedor,
                                    nombre = pdt.nombre,
                                    direccion = pdt.direccion,
                                    mail = pdt.mail,
                                    telefono = pdt.telefono,
                                    habilitado = pdt.habilitado
                                });
            return providerList;
        }*/
        /*
        public void update(Provider p)
        {
            throw new NotImplementedException();
        }*/
    }
}
