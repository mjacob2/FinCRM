namespace FinCRM.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using FinCRM.DataAccess;
    using FinCRM.DataAccess.Entities;
    using System.Collections.Generic;

    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        //field
        private readonly IRepository<Client> clientRepository;

        // Constructor
        // Wstrzykujemy w niego klasę z konkretnym repozytorium (tzw. dependency injection)
        // Jest to fundamentalna zasada SOLID
        public ClientController(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }


        // Endpointy

        // ten pobiera wszystkich klientów
        [HttpGet]
        [Route("")]
        public IEnumerable<Client> GetAllClients()
        {
            return this.clientRepository.GetAll();
        }


        // Ten pobiera klienta po Id
        [HttpGet]
        [Route("{clientId}")]
        public Client GetClientById(int clientId)
        {
            return this.clientRepository.GetById(clientId);
        }

    }
}
