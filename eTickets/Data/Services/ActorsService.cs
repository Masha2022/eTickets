using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services;

public class ActorsService: IActorsServices
{
    private readonly ApplicationDbContext _context;

    public ActorsService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Actor>> GetAllActors()
    {
        var result = await _context.Actors.ToListAsync();
        return result;
    }

    public Actor GetActorById(int id)
    {
        throw new NotImplementedException();
    }

    public void AddActor(Actor actor)
    {
        throw new NotImplementedException();
    }

    public Actor UpdateActor(int id, Actor newActor)
    {
        throw new NotImplementedException();
    }

    public void DeleteActor(int id)
    {
        throw new NotImplementedException();
    }

    //public Actor GetActorById(int id)
   //{
   //    
   //}

   //public void AddActor(Actor actor)
   //{
   // 
   //}

   //public Actor UpdateActor(int id, Actor newActor)
   //{
   //   
   //}

   //public void DeleteActor(int id)
   //{
   //   
   //}
}