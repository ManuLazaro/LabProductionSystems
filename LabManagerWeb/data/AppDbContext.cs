using Microsoft.EntityFrameworkCore;
using LabManagerWeb.Models;

namespace LabManagerWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Muestra> Muestras => Set<Muestra>();
}
