using BookNetWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookNetWebAPI.Data;
public class LibraryContext: DbContext{
    public LibraryContext(DbContextOptions<LibraryContext> options): base(options){}

    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<BookByAuthor> BooksByAuthors {get; set;}
    public DbSet<Activitie> Activities {get; set;}
}
