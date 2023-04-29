using Microsoft.EntityFrameworkCore;
using Tickets.Shared.Entities;

namespace Tickets.API.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>().HasIndex(x => x.TicketId).IsUnique();
        }
    }
}

