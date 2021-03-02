using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Contracts
{
    public interface IClientRepository
    {

        Client Login(string email, string password);
        Client GetClientById(int id);

        void RegisterClient(Client client);

        void UpdateClient(Client client);

        void DeleteClient(int id);

        IEnumerable<Client> GetAllClients();

    }
}
