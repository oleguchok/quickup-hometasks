using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace QuickOrder.Entities
{
    public class Role : IdentityRole<int>, IEntityBase
    {
    }
}
