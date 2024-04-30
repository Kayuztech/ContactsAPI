using ContactsAPI.Data.Repositories.Interfaces;
using ContactsAPI.Domain.Entities;

namespace ContactsAPI.Data.Repositories.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _db;

        public ContactRepository(ContactDbContext db)
        {
            _db = db;
        }
        public async Task<Contact> AddContactAsync(Contact contact)
        {
            var newContact = await _db.contacts.AddAsync(contact);
            newContact.Entity.CreatedAt = DateTime.UtcNow;
            newContact.Entity.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return newContact.Entity;
        }
    }
}
