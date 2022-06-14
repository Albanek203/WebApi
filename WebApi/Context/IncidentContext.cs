using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context;

public class IncidentContext : DbContext {
    public IncidentContext(DbContextOptions<IncidentContext> options) : base(options) { Database.EnsureCreated(); }

    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Incident>().HasKey(x=>x.Name);
        modelBuilder.Entity<Incident>().Property(x=>x.Name).HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<Account>().HasIndex(x=>x.Name).IsUnique();
        modelBuilder.Entity<Contact>().HasIndex(x=>x.Email).IsUnique();
    }
}