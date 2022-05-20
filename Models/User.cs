using System;
using System.ComponentModel.DataAnnotations;

namespace BookNetWebAPI.Models;
    public class User{
    [Required]
    [Key]
    public short UserId {get; set;}

    [MaxLength(150)]
    public string UserName {get; set;}= "";
    public string Password {get; set;}= "";
    }
