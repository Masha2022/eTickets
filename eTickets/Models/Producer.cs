﻿using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;

public class Producer
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "Profile Picture")]
    public string ProfilePictureURL { get; set; }
    [Display(Name = "Full Name")]
    public string FullName{ get; set; }
    [Display(Name = "Biography")]
    public string Biography{ get; set; }
    
    //отношение один ко многим
    public List<Movie> Movies{ get; set; }
}