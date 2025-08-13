using BookRadar.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookRadar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BusquedaLibro> HistorialBusquedas { get; set; }
    }
}
