using Ecommerce.Libraries.Login;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Filter
{
    /*
     * Types Filters
     * Authorization
     * Resource
     * Action
     * Exception
     * Result
     */
    public class ClientAuthAttribute : Attribute, IAuthorizationFilter
    {
        LoginClient _loginClient;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginClient = (LoginClient)context.HttpContext.RequestServices.GetService(typeof(LoginClient));
  
            Client client = _loginClient.GetSessionClient();
            if (client == null)
            {
                context.Result = new ContentResult() { Content = "Filter: Usuário não logado" };
            }
        }
    }
}
