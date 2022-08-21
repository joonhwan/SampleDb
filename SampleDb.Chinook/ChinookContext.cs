using Microsoft.EntityFrameworkCore;
using SampleDb.Chinook.Entities;

namespace SampleDb.Chinook;

public class ChinookContext : DbContext
{
    protected ChinookContext(DbContextOptions options)
        :base(options)
    {
    }

    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<InvoiceLine> InvoiceLines { get; set; } = null!;
    public DbSet<MediaType> MediaTypes { get; set; } = null!;
    public DbSet<Playlist> Playlists { get; set; } = null!;
    public DbSet<Track> Tracks { get; set; } = null!;
}