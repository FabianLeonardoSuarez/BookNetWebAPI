using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Dtos;
public record AuthorDTO{
    [Required]
    public int id {get; set;}
    public int idBook {get; set;}
    public string firstName {get; set;}
    public string lastName {get; set;}
    public List<int> books { get; set; }
}
