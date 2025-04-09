using Microsoft.AspNetCore.Identity;

namespace TaskDotNet.Entities.IdentityEntities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
