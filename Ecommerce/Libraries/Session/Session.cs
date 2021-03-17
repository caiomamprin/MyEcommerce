using Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Session
{
    public class Session
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetSession(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public void UpdateSession(string key, string value)
        {
            if (!ExistsSession(key))
            {
                _httpContextAccessor.HttpContext.Session.Remove(key);
                _httpContextAccessor.HttpContext.Session.SetString(key, value);
            }
        }

        public bool ExistsSession(string key)
        {
            if (_httpContextAccessor.HttpContext.Session.GetString(key) != null)
            {
                return true;
            }
            return false;
        }

        public void RemoveSession(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }


        public string GetSession(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }

        public void RemoveAllSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }


    }
}
