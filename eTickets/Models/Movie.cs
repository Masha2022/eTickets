using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTickets.Data;

namespace eTickets.Models;

public class Movie
{
    // Первичный ключ таблицы Movie
    [Key]
    public int Id { get; set; }
    public string Name{ get; set; }
    public string Description{ get; set; }
    public double Price{ get; set; }
    public string ImageUrl{ get; set; }
    public DateTime StartDate{ get; set; }
    public DateTime EndDate{ get; set; }
    public MovieCategory MovieCategory{ get; set; }

    // Список связей между актерами и фильмами (отношение "многие ко многим")
    public List<Actor_Movie> ActorMoviesList{ get; set; }

    // ID кинотеатра, где будет показан фильм
    public int CinemaId { get; set; }

    // Навигационное свойство для кинотеатра, связанное через внешний ключ CinemaId
    [ForeignKey("CinemaId")]
    public Cinema Cinema{ get; set; }

    // ID продюсера фильма
    public int ProducerId { get; set; }

    // Навигационное свойство для продюсера, связанное через внешний ключ ProducerId
    [ForeignKey("ProducerId")]
    public Producer Producer{ get; set; }
}