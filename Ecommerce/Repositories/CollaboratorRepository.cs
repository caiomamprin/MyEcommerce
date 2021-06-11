using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ecommerce.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly IConfiguration _config;
        private readonly  LojaVirtualContext _database;

        public CollaboratorRepository(LojaVirtualContext database, IConfiguration config)
        {
            _database = database;
            _config = config;
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

        public IPagedList<Collaborator> GetAllCollaborator(int? pageIndex)
        {
            int pageSize = _config.GetValue<int>("PageSize");
            int pageNumber = pageIndex ?? 1;
            return _database.Collaborators.Where(model => model.Type != "M").ToPagedList<Collaborator>(pageNumber, pageSize);
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
