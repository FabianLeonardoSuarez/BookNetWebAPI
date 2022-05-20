using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Dtos;
public record AuthorDTO{
    [Required]
    public int id {get; set;}
    public string firstname {get; set;}
    public string lastname {get; set;}
    public List<BookDTO> books {get; set;} = new List<BookDTO>(){};

}