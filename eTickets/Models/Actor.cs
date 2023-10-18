using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }
    
    //при отображении этого свойства пользователю в пользовательском интерфейсе
    //вместо названия свойства ProfilePictureURL должно отображаться имя "Profile Picture URL"
    [Display(Name = "Profile Picture")] 
    public string ProfilePictureURL { get; set; }
    
    [Display(Name = "Full Name")]
    public string FullName{ get; set; }
    
    [Display(Name = "Biography")]
    public string Biography{ get; set; }
    
    // у одного актёра может быть много записей в Actor_Movies
    //и у одного фильма также может быть много записей в Actor_Movies
    //отношение "многие ко многим" через связующую таблицу
    public  List<Actor_Movie> Actor_Movies{ get; set; }
}