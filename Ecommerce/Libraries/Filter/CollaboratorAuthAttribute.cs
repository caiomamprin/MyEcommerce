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
    public class CollaboratorAuthAttribute : Attribute, IAuthorizationFilter
    {
        LoginCollaborator _loginCollaborator;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCollaborator = (LoginCollaborator)context.HttpContext.RequestServices.GetService(typeof(LoginCollaborator));

            Collaborator collaborator= _loginCollaborator.GetSessionCollaborator();
            if (collaborator == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
