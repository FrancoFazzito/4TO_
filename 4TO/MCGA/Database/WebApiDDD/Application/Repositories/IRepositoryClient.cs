using Domain;
using System.Collections.Generic;

namespace Application
{
    public interface IRepositoryClient
    {
        IEnumerable<Client> GetAll();

        public Client GetById(int id);

        public Client GetByName(string name);

        public bool Create(Client value);

        bool Delete(int id);

        bool Update(Client value);
    }
}