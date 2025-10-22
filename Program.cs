using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDto> games = [
    new(1,
    "Tekken 8",
    "Fighting",
    20.49M,
    new DateOnly(2024, 7, 15)),
    new(2, 
    "Fifa 25", 
    "Sports", 
    45.60M, 
    new DateOnly(2025, 1, 14)),
    new(3, 
    "GTA V", 
    "RPG", 
    100M, 
    new DateOnly(2013, 5, 2))
];

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(games => games.Id == id))
   .WithName(GetGameEndpointName);
//POST /games
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);

});
app.Run();
