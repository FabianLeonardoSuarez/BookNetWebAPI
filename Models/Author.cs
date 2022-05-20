using System;
using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Models;

public class Author{
    [Required]
    [Key]
    public int AuthorId { get; set;}

    [MaxLength(150)]
    public string FirstName { get; set; }
    [MaxLength(150)]
    public string LastName { get; set; }
}
