using Microsoft.EntityFrameworkCore;

namespace PeliculasAPI;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
}
