using eTickets.Models;

namespace eTickets.Data.Services;

public interface IActorsServices
{
    public Task<IEnumerable<Actor>> GetAllActors();
    public Actor GetActorById(int id);
    public void AddActor(Actor actor);
    public Actor UpdateActor(int id, Actor newActor);
    public void DeleteActor(int id);
}