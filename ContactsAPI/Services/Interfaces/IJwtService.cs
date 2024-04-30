using ContactsAPI.Domain.Entities;

namespace ContactsAPI.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(AppUser appUser, IEnumerable<string> roles);
    }
}
