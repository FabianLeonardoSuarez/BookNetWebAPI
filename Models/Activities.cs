using System;
using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Models;
    public class Activitie{
    [Required]
    [Key]
    public Guid IdActivitie {get; set;}

    [MaxLength(150)]
    public string Title {get; set;}
    public DateTime DueDate {get; set;}
    public bool Completed {get; set;}
    }
