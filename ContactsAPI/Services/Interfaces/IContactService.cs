using ContactsAPI.Domain.DTO;
using ContactsAPI.Domain.Generic;

namespace ContactsAPI.Services.Interfaces
{
    public interface IContactService
    {
        Task<Result<AddContactResponseDTO>> AddContact(AddContactRequestDTO requestDTO, string userId);
    }
}
