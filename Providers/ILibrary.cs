using System;
using System.Collections.Generic;
using BookNetWebAPI.Models;

namespace BookNetWebAPI.Data;
    public interface ILibrary
    {
        public Author GetAuthorById(int authorid);
        public List<Author> GetAuthors();
        public Book GetBookById(int bookid);
        public List<Book> GetBooks();
        public Task SyncDataBase();
    }
    
