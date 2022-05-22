using System;
using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Models;
public class Book{
    [Required]
    [Key]
    public int BookId { get; set; }

    [MaxLength(250)]
    public string Title { get; set; } = "";
    public string Description { get; set; }= "";
    public int PageCount { get; set; }
    public string Excerpt { get; set; }= "";
    public DateTime PublishDate { get; set; }
    [MaxLength(250)]
    public string UrlCoverImage { get; set; }= "";
    public List<BookByAuthor> Authors { get; set; } = null;
}
