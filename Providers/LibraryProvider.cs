using System;
using System.Collections.Generic;
using BookNetWebAPI.Models;
using BookNetWebAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookNetWebAPI.Data;
    public class LibraryProvider: ILibrary
    {
        private LibraryContext _context;
        private HttpClient client = new HttpClient();
        private string APIPATH = "https://fakerestapi.azurewebsites.net/api/v1/";

        public LibraryProvider(LibraryContext context){
            _context = context;
        }
        public Author GetAuthorById(int authorid){
            return _context.Authors.Include(x=>x.Books).FirstOrDefault(x=>x.AuthorId==authorid);
        }
        public List<Author> GetAuthors(){
            return _context.Authors.ToList();
        }
        public Book GetBookById(int bookid){
            return _context.Books.Include(x=>x.Authors).FirstOrDefault(x=>x.BookId==bookid);
        }
        public List<Book> GetBooks(){
            return _context.Books.ToList();
        }
        public async Task SyncDataBase(){
            //Get CoverPhotos
            var streamTask = client.GetStreamAsync(APIPATH + "CoverPhotos");
            var coverList = await JsonSerializer.DeserializeAsync<ICollection<CoverPhotoDTO>>(await streamTask);

            //Get and Syncronize Books
            streamTask = client.GetStreamAsync(APIPATH + "Books");
            var bookList = await JsonSerializer.DeserializeAsync<ICollection<BookDTO>>(await streamTask);
            var NewBooks = bookList.Select((book)=> {
               book.urlcoverimage = coverList.FirstOrDefault(x=>x.idBook==book.id).url;
               return ConvertDTOtoBook(book);
            }).ToList();
            _context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Books]; DBCC CHECKIDENT ('Books', RESEED, 0);");
            NewBooks.ForEach((book)=> _context.Books.Add(book));
            _context.Activities.Add(new Activitie {Title = "Sync Books", DueDate = DateTime.Now, Completed = true});
            _context.SaveChanges();
            
            //Get and Syncronize Authors
            streamTask = client.GetStreamAsync(APIPATH + "Authors");
            var authorList = await JsonSerializer.DeserializeAsync<ICollection<AuthorDTO>>(await streamTask);
            var NewAuthors = authorList.Select((author)=> ConvertDTOtoAuthor(author)).ToList();
            _context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Authors]; DBCC CHECKIDENT ('Authors', RESEED, 0);");
            NewAuthors.ForEach((author)=> _context.Authors.Add(author));
            _context.Activities.Add(new Activitie {Title = "Sync Authors", DueDate = DateTime.Now, Completed = true});
            _context.SaveChanges();

            //Syncronize BooksByAuthors
            _context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[BooksByAuthor];");
           authorList.ToList().ForEach((author)=>{
                _context.BooksByAuthor.Add(new BookByAuthor{ BookId=author.idBook,AuthorId=author.id });
           });
            
           _context.SaveChanges();
        }

        private Author ConvertDTOtoAuthor(AuthorDTO author){
            return new Author{
                FirstName = author.firstName,
                LastName = author.lastName
            };
        }
        private Book ConvertDTOtoBook(BookDTO book){
            return new Book{
                 Title = book.title, 
                 Description = book.description,
                 PageCount = book.pagecount, 
                 Excerpt = book.excerpt, 
                 PublishDate = book.publishdate,
                 UrlCoverImage = book.urlcoverimage
            };
        }
    }
    
