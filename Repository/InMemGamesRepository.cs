using GameStore.Api.Endpoints;
using System.Collections.Generic;
using GameStore.Api.Entities;

namespace GameStore.Api.Repository; 

    public class InMemGamesRepository : IGamesRepository
    {

        //Methods
          static readonly List<Game> games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "street",
                Genre = "fighting",
                Price= 19.99M,
                ReleaseDate = new DateTime(1991, 2, 1),
                ImageUri = "https://placehold.co/100"
            },

            new Game()
            {
                Id = 2,
                Name = "streeter",
                Genre = "fighting2",
                Price= 19.99M,
                ReleaseDate= new DateTime(1992, 2, 1),
                ImageUri = "https://placehold.co/100"
            }
        };
        
    public IEnumerable<Game> GetAll()
    {
            return games;
    }

    public Game?  Get(int id)
    {
            return games.Find(games => games.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updateGame)
    {
            var index = games.FindIndex(game => game.Id == updateGame.Id);
            games[index] = updateGame;
    }

    public void Delete(int id)
    {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
    }
       
    }

