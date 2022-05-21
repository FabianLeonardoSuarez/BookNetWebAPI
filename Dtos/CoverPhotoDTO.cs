using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Dtos;
public record CoverPhotoDTO{
    [Required]
    public int id {get; set;}
    public int idBook {get; set;}
    public string url {get; set;}
}
