namespace ContactsAPI.Domain.Entities
{
    public class Contact
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BVN { get; set; }
        public string? Address { get; set; }
        public string? LinkedInHandle { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
