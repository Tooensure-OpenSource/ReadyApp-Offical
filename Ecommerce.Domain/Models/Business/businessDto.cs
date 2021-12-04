namespace Ecommerce.Domain.Models.Business
{
    public class businessDto
    {
        public Guid businessId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Usernames { get; set; } = string.Empty;

    }
}