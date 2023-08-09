using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Models
{
    public interface IClientRepository
    {
        void add(ClientTable c);
        void update(ClientTable c);
        void delete(int id);
       /* IEnumerable<ClientTable> GetAll();
        IEnumerable<ClientTable> GetByValue(string s);*/
    }
}
