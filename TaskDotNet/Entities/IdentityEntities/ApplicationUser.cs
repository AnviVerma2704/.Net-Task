using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskDotNet.Entities.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
