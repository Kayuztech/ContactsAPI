using Microsoft.AspNetCore.Identity;

namespace ContactsAPI.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
