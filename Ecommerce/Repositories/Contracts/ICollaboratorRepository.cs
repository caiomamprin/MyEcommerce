using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Contracts
{
    public interface ICollaboratorRepository
    {
        Collaborator Login(string email, string password);
        void RegisterCollaborator(Collaborator collaborator);
        void UpdateCollaborator(Collaborator collaborator);
        void DeleteCollaborator(int id);
        Collaborator getCollaboratorById(int id);
        IEnumerable<Collaborator> GetAllCollaborator();
    }
}
