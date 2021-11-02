using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IHandler<ClientCreated> _handlerCreated;

        public ClientService(IRepository<Client> repositoryClient, IHandler<ClientCreated> handlerCreated)
        {
            _clientRepository = repositoryClient;
            _handlerCreated = handlerCreated;
        }

        public void CreateClient(Client client)
        {
            //guard condition
            EnsureNameClientNotExists(client);

            //save changes
            _clientRepository.Create(client);

            //publish
            _handlerCreated.Handle(new ClientCreated(client));
        }

        private void EnsureNameClientNotExists(Client client)
        {
            if (_clientRepository.GetAll().Any(c => c.Name == client.Name))
            {
                throw new System.Exception("the name is not available");
            }
        }

        public IEnumerable<Client> Clients => _clientRepository.GetAll();
    }
}