using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QuickOrder.Entities
{
    public class User : IdentityUser<int>, IEntityBase
    {
    }
}
