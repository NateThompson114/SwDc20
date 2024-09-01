using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SwDc20.BlazorApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        
    }
}
