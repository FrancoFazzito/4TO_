using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public void CreateClient(Client client)
        {
            _clientService.CreateClient(client);
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _clientService.Clients;
        }
    }
}