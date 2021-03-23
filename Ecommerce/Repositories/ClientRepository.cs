using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ClientRepository : IClientRepository
    {

        private readonly LojaVirtualContext _database;
        public ClientRepository(LojaVirtualContext database)
        {
            _database = database;
        }

        public void DeleteClient(int id)
        {
            Client client = GetClientById(id);
            _database.Remove(client);
            _database.SaveChanges();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _database.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return _database.Clients.Find(id);
        }

        public Client Login(string email, string password)
        {
            Client client =  _database.Clients.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
            return client;
        }

        public void RegisterClient(Client client)
        {
            _database.Add(client);
            _database.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _database.Update(client);
            _database.SaveChanges();
        }
    }
}
