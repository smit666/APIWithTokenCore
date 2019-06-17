using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIWithToken.Models
{
    public class User
    {
        private ClaimsPrincipal principal;

        public User(ClaimsPrincipal principal)
        {
            this.principal = principal;
        }
        public string Name => principal.Identity.Name;
        public string Email => principal.FindFirst(ClaimTypes.Email).Value;
    }
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
