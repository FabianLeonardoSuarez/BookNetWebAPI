using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Dtos;
public record BookDTO{
    [Required]
    public int id {get; set;}
    public string title {get; set;}
    public string description {get; set;}
    public int pagecount {get; set;}
    public string excerpt {get; set;}
    public DateTime publishdate {get; set;}
    public string urlcoverimage {get; set;}

}