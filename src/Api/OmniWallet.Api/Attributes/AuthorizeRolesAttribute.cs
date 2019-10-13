using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Api.Attributes
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params UsuarioPapel[] allowedRoles)
        {
            if (allowedRoles.Length == 0)
                throw new ArgumentException(@"É obrigatório informar pelo menos um papel.", nameof(allowedRoles));
            
            var allowedRolesAsStrings = allowedRoles.Select(papel => Enum.GetName(typeof(UsuarioPapel), papel));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}