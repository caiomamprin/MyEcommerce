using Ecommerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Login
{
    public class LoginClient
    {
        private readonly string Key = "Login.Client";
        private readonly Session.Session _session;
        public LoginClient(Session.Session session)
        {
            _session = session;
        }

        public void LoginSession(Client client)
        {
            //SERIALIZER FROM OBJECT TO STRING
            string clientString = JsonConvert.SerializeObject(client);
            _session.SetSession(Key, clientString);
        }

        public Client GetSessionClient()
        {
            if (_session.ExistsSession(Key))
            {
            //DESERIALIZER FROM STRING TO OBJECT
            Client client =  JsonConvert.DeserializeObject<Client>(_session.GetSession(Key));
            return client;
            }
            return null;
        }

        public void Logout()
        {
            _session.RemoveAllSession();
        } 
    }
}
