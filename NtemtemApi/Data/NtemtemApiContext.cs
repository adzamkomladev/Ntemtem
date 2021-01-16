using Microsoft.EntityFrameworkCore;
using NtemtemApi.Models;

namespace NtemtemApi.Data
{
    public class NtemtemApiContext : DbContext
    {
        public NtemtemApiContext(DbContextOptions<NtemtemApiContext> options) : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; init; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}