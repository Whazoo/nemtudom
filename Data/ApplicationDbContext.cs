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
    public DbSet<ContactModel> Contacts { get; set; }
    public DbSet<ContentModel> Contents { get; set; }
    public DbSet<DownloadModel> Downloads { get; set; }
}

