using SampleDb.Chinook.Entities;
using Microsoft.EntityFrameworkCore;

namespace SampleDb.Chinook.PostgreSQL;

public class PostgresChinookContext : ChinookContext
{
    public PostgresChinookContext(DbContextOptions<PostgresChinookContext> options)
    : base(options)
    {
        // throw new Exception($@"This constructor should not be used : {options.Extensions.ToList().Count}");
    }
    
    public PostgresChinookContext(DbContextOptions options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.Property(e => e.AlbumId).ValueGeneratedNever();
            entity.HasIndex(e => e.ArtistId);
            entity.Property(e => e.Title).HasMaxLength(160);
            entity.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("FK_AlbumArtistId")
                ;
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId);
            
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
            entity.HasIndex(e => e.SupportRepId);
            
            entity.Property(e => e.Address).HasMaxLength(128);
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.State).HasMaxLength(40);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            
            entity.Property(e => e.Company).HasMaxLength(80);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(24);
            
            entity.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.SupportRepId)
                ;
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.BirthDate);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            // 
            entity.Property(e => e.Address).HasMaxLength(70);
            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.State).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            //
            entity.Property(e => e.Phone).HasMaxLength(24);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            
            entity.HasIndex(e => e.ReportsTo);
            entity.Property(e => e.HireDate);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.EmployeeToBeReported)
                .WithMany(p => p.EmployeesToReport)
                .HasForeignKey(d => d.ReportsTo)
                ;
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId);
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);
            entity.HasIndex(e => e.CustomerId);
            
            entity.Property(e => e.BillingAddress).HasMaxLength(70);
            entity.Property(e => e.BillingCity).HasMaxLength(40);
            entity.Property(e => e.BillingCountry).HasMaxLength(40);
            entity.Property(e => e.BillingState).HasMaxLength(40);
            entity.Property(e => e.BillingPostalCode).HasMaxLength(10);

            entity.Property(e => e.InvoiceDate);
            entity.Property(e => e.Total).HasColumnType("numeric(10, 2)");

            entity
                .HasOne(d => d.Customer)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                ;
        });

        modelBuilder.Entity<InvoiceLine>(entity =>
        {
            entity.HasKey(e => e.InvoiceLineId);
            entity.HasIndex(e => e.InvoiceId);
            entity.HasIndex(e => e.TrackId);

            entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            entity
                .HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                ;

            entity
                .HasOne(d => d.Track)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.TrackId)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                ;
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.MediaTypeId);
            entity.Property(e => e.Name).HasMaxLength(120);
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.PlaylistId);
            entity.Property(e => e.Name).HasMaxLength(120);

            entity
                .HasMany(d => d.Tracks)
                .WithMany(p => p.Playlists)
                .UsingEntity<PlaylistTrack>(
                    l => l.HasOne(x => x.Track).WithMany().HasForeignKey(x => x.TrackId),
                    r => r.HasOne(x => x.Playlist).WithMany().HasForeignKey(x => x.PlaylistId)
                    )
                .HasKey(x => new {x.PlaylistId, x.TrackId })
                ;
                // .UsingEntity<Dictionary<string, object>>("PlaylistTrack"
                // , l => l.HasOne<Track>().WithMany().HasForeignKey("TrackId")
                //     // .OnDelete(DeleteBehavior.ClientSetNull)
                // , r => r.HasOne<Playlist>().WithMany().HasForeignKey("PlaylistId")
                //     //.OnDelete(DeleteBehavior.ClientSetNull)
                // , j =>
                // {
                //     j.HasKey("PlaylistId", "TrackId");
                //     j.ToTable("PlaylistTrack");
                //     j.HasIndex(new[] { "TrackId" }, "IFK_PlaylistTrackTrackId");
                // }
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.TrackId);

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Composer).HasMaxLength(220);
            entity.Property(e => e.UnitPrice).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Album)
                .WithMany(p => p.Tracks)
                .HasForeignKey(d => d.AlbumId)
                ;

            entity.HasOne(d => d.Genre)
                .WithMany(p => p.Tracks)
                .HasForeignKey(d => d.GenreId)
                ;

            entity.HasOne(d => d.MediaType)
                .WithMany(p => p.Tracks)
                .HasForeignKey(d => d.MediaTypeId)
                ;
        });
    }
}