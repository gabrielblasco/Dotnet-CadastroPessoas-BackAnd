using dotnet_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}