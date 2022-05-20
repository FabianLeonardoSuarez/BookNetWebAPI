using System;
using System.Collections.Generic;
using BookNetWebAPI.Models;
using BookNetWebAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookNetWebAPI.Data;
    public class LibraryProvider: ILibrary
    {
        private LibraryContext _context;

        public LibraryProvider(LibraryContext context){
            _context = context;
        }
        public Author GetAuthorById(int authorid){
            return null;
        }
        public List<Author> GetAuthors(){
            return null;
        }
        public Book GetBookById(int bookid){
            return null;
        }
        public List<Book> GetBooks(){
            return null;
        }
        public bool SyncDataBase(){
                return true;
        }
    }
    
