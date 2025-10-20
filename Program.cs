using GameStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.MapGet("games", () => games);

app.MapGet("games/{id}", (int id) => games.Find(games => games.Id == id));

app.Run();
