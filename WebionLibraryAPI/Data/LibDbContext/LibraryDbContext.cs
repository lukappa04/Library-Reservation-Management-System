using Microsoft.EntityFrameworkCore;
using WebionLibraryAPI.Models.Books;
using WebionLibraryAPI.Models.Customers;
using WebionLibraryAPI.Models.Reservations;

namespace WebionLibraryAPI.Data.LibDbContext;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options){}

    //DbSet per ogni mia classe
    public DbSet<CustomerM> Customers { get; set; }
    public DbSet<BookM> Books { get; set; }
    public DbSet<ReservationM> Reservations { get; set; }

    //configuro i miei campi del db
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //CustomerM
        modelBuilder.Entity<CustomerM>()
        .HasIndex(c => c.Email)
        .IsUnique(); //impostiamo il campo email come unique
        
        modelBuilder.Entity<CustomerM>()
        .Property(c => c.RegistrationDate)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

        //BookM
        modelBuilder.Entity<BookM>()
        .HasIndex(c => c.ISBN)
        .IsUnique(); //impostiamo il campo ISBN come unique

        //ReservationM
        modelBuilder.Entity<ReservationM>()
        .HasOne(r => r.Customer) //ogni prenotazione ha un cliente
        .WithMany() //ma un cliente può avere più prenotazioni
        .HasForeignKey(r => r.CustomerId) //FK di CustomerId in ReservationM
        .OnDelete(DeleteBehavior.Cascade); //quando un cliente viene eliminato anche le sue prenotazioni si eliminano

        modelBuilder.Entity<ReservationM>()
        .HasOne(r => r.Book) //ogni prenotazione ha un libro
        .WithMany() 
        .HasForeignKey(r => r.BookId) //FK di BookId in ReservationId
        .OnDelete(DeleteBehavior.Restrict); //non eliminiamo il libro se la prenotazione viene cancellata

        modelBuilder.Entity<ReservationM>()
        .HasIndex(r => new { r.BookId, r.ReservationDate })
        .IsUnique();

    }
}