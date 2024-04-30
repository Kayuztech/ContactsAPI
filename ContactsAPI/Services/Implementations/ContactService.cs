using ContactsAPI.Data.Repositories.Interfaces;
using ContactsAPI.Data;
using ContactsAPI.Domain.DTO;
using ContactsAPI.Domain.Entities;
using ContactsAPI.Domain.Generic;
using ContactsAPI.Services.Interfaces;

namespace ContactsAPI.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly ContactDbContext _db;
        private readonly IContactRepository _contactRepository;

        public ContactService(ContactDbContext db, IContactRepository contactRepository)
        {
            _db = db;
            _contactRepository = contactRepository;
        }
        public async Task<Result<AddContactResponseDTO>> AddContact(AddContactRequestDTO requestDTO, string userId)
        {
            var result = new Result<AddContactResponseDTO>();
            try
            {
                var user = _db.AppUsers.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "User not found";
                    return result;
                }

                var newContact = new Contact
                {
                    Address = requestDTO.Address,
                    AppUserId = user.Id,
                    Email = requestDTO.Email,
                    LinkedInHandle = requestDTO.LinkedInHandle,
                    PhoneNumber = requestDTO.PhoneNumber,
                    Name = requestDTO.Name
                };

                await _contactRepository.AddContactAsync(newContact);

                var contactResponse = new AddContactResponseDTO
                {
                    AddedBy = user.Name,
                    Email = newContact.Email,
                    LinkedInHandle = newContact.LinkedInHandle,
                    Id = newContact.Id,
                    Name = newContact.Name,
                    PhoneNumber = newContact.PhoneNumber,
                };

                result.IsSuccess = true;
                result.Message = "Contact added successfully";
                result.Content = contactResponse;


            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
