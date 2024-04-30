using ContactsAPI.Domain.DTO;
using ContactsAPI.Domain.Generic;
using ContactsAPI.Services.Implementations;

namespace ContactsAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Result<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO);
        Task<Result<AppUserDTO>> Register(RegistrationRequestDTO requestDTO);

        Task<Result<bool>> AssignRole(string email, string roleName);
    }
}
