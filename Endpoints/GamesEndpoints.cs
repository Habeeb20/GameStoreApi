using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repository;

namespace GameStore.Api.Endpoints
{

    //ROUTES ****
    public static class GamesEndpoints
    {

        const string GetGameEndPOintName = "GetGame";
      
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {


            var group = routes.MapGroup("/games")
               .WithParameterValidation();

            group.MapGet("/", (IGamesRepository repository) => 
            repository.GetAll().Select(game => game.AsDto()));





            group.MapGet("/{id}", (IGamesRepository repository, int id) =>
            {
                Game? game = repository.Get(id);
                return game is null ? Results.NotFound() : Results.Ok(game.AsDto);

            })
            .WithName(GetGameEndPOintName);





            group.MapPost("/",(IGamesRepository repository, CreateGameDto gameDto) =>
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUri = gameDto.ImageUri

                };

                repository.Create(game);
                return Results.CreatedAtRoute(GetGameEndPOintName, new {id = game.Id}, game);

            });






            group.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existinGame = repository.Get(id);

                if (existinGame is null)
                {
                    return Results.NotFound();
                }
                existinGame.Name = updatedGameDto.Name;
                existinGame.Genre = updatedGameDto.Genre;
                existinGame.Price = updatedGameDto.Price;
                existinGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existinGame.ImageUri = updatedGameDto.ImageUri;

                repository.Update(existinGame);

                return Results.NoContent();
                


            });

            group.MapDelete("/{id}", (IGamesRepository repository,int id) =>
            {
                Game? game = repository.Get(id);
                if(game is not null)
                {
                    repository.Delete(id);
                }

                return Results.NoContent();
                

                

            });

            return group;
        }
        
        
    }
};