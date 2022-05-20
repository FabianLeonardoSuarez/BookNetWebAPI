using System;
using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Models;
public class BookByAuthor{
    public int AuthorId { get; set; }
    public int BookId { get; set; }
}
    
