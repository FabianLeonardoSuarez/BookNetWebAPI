using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookNetWebAPI.Models;
public class BookByAuthor{
    public int AuthorId { get; set; }
    public int BookId { get; set; }
}
    
