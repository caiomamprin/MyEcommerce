using Ecommerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Login
{
    public class LoginCollaborator
    {
        readonly string Key = "Login.Collaborator";
        private readonly Session.Session _session;
        public LoginCollaborator(Session.Session session)
        {
            _session = session;
        }

        public void LoginSession(Collaborator collaborator)
        {
            //SERIALIZER FROM OBJECT TO STRING
            string collaboratorString = JsonConvert.SerializeObject(collaborator);
            _session.SetSession(Key, collaboratorString);
        }

        public Collaborator GetSessionCollaborator()
        {
            if (_session.ExistsSession(Key))
            {
                //DESERIALIZER FROM STRING TO OBJECT
                Collaborator collaborator = JsonConvert.DeserializeObject<Collaborator>(_session.GetSession(Key));
                return collaborator;
            }
            return null;
        }

        public void Logout()
        {
            _session.RemoveAllSession();
        }
    }
}
