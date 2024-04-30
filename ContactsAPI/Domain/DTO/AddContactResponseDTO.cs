namespace ContactsAPI.Domain.DTO
{
    public class AddContactResponseDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BVN { get; set; }
        public string? Address { get; set; }
        public string? LinkedInHandle { get; set; }
        public string? AddedBy { get; set; }
    }
}
