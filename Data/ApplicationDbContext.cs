using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nemtudom.Models;

namespace nemtudom.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ContactModel> Contact { get; set; }
    public DbSet<ContentModel> Content { get; set; }
    public DbSet<DownloadModel> Download { get; set; }
}

