
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Contactsbook.Models
{
    public class Users : IdentityUser
    {
         public string FullName { get; set; }
    }
}
