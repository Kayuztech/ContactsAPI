using ContactsAPI.Domain.Entities;

namespace ContactsAPI.Data.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> AddContactAsync(Contact contact);
    }
}
