using Domain;
using System.Collections.Generic;

namespace Application
{
    public interface IClientService
    {
        void CreateClient(Client client);

        IEnumerable<Client> Clients { get; }
    }
}