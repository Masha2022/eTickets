namespace eTickets.Models;
//связующая таблица для реализации связи "многие ко многим" между актёрами (Actor) и фильмами (Movie)
public class Actor_Movie
{
    //внешний ключ к таблице фильмов (Movie)
    public int MovieId { get; set; }
    public Movie Movie{ get; set; }
    
    //ActorId — внешний ключ к таблице актёров (Actor)
    public int ActorId { get; set; }
    public Actor Actor { get; set; }
}