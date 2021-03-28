using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CollaboratorRepository : ICategoryepository
    {
        private readonly  LojaVirtualContext _database;

        public CollaboratorRepository(LojaVirtualContext database)
        {
            _database = database;
        }

        public void DeleteCollaborator(int id)
        {
            Collaborator colaborator = getCollaboratorById(id);
            _database.Remove(colaborator);
            _database.SaveChanges();
        }

        public IEnumerable<Collaborator> GetAllCollaborator()
        {
            return _database.Collaborators.ToList();
        }

        public Collaborator getCollaboratorById(int id)
        {
            return _database.Collaborators.Find(id);
        }

        public Collaborator Login(string email, string password)
        {
            Collaborator collaborator = _database.Collaborators.Where(model => model.Email == email && model.Password == password).FirstOrDefault();
            return collaborator;
        }

        public void RegisterCollaborator(Collaborator collaborator)
        {
            _database.Add(collaborator);
            _database.SaveChanges();
        }

        public void UpdateCollaborator(Collaborator collaborator)
        {
            _database.Update(collaborator);
            _database.SaveChanges();
        }
    }
}
