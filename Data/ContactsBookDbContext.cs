using Contactsbook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contactsbook.Data
{
    public class ContactsBookDbContext : IdentityDbContext<Users>
    {
        public ContactsBookDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ContactsBookDbContext()
        {
        }
    }
}
