using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data;
// Определение класса ApplicationDbContext, который является основным классом для работы с базой данных в Entity Framework
public class ApplicationDbContext : DbContext
{
    // Конструктор, который принимает настройки контекста базы данных. Эти настройки могут включать, например, строку подключения к БД.
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        // Передача параметров в базовый конструктор DbContext
    }

    // Метод OnModelCreating вызывается при первоначальной настройке модели для контекста данных.
    // Здесь задаются некоторые дополнительные настройки, которые не могут быть выведены из сущностей напрямую.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Задается составной первичный ключ для таблицы Actor_Movie, который состоит из ActorId и MovieId
        modelBuilder.Entity<Actor_Movie>().HasKey(am => new
        {
            am.ActorId, MoveId = am.MovieId
        });

        // Устанавливается отношение "один ко многим" между таблицами Movie и Actor_Movie.
        // Каждый фильм может иметь множество записей в Actor_Movie, но каждая запись в Actor_Movie относится к одному фильму.
        modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.ActorMoviesList)
            .HasForeignKey(m => m.MovieId);
        
        // Устанавливается отношение "один ко многим" между таблицами Actor и Actor_Movie.
        // Каждый актер может иметь множество записей в Actor_Movie, но каждая запись в Actor_Movie относится к одному актеру.
        modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movies)
            .HasForeignKey(m => m.ActorId);
        
        // Вызов базовой реализации метода OnModelCreating
        base.OnModelCreating(modelBuilder);
    }
    
    // Наборы данных для каждой из сущностей. Эти наборы данных представляют таблицы в базе данных.
    // Через них можно осуществлять операции добавления, удаления, обновления и выборки записей.
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
}