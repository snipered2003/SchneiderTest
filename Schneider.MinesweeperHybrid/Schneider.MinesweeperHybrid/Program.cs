using Microsoft.Extensions.DependencyInjection;
using Schneider.MinesweeperHybrid.Game.Board;
using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Models;
using Schneider.MinesweeperHybrid.Models.Board;

var serviceProvider = new ServiceCollection()
           .AddSingleton<IGame, MinesweeperHybridGame>()
           .AddSingleton<IScore, Score>()
           .AddSingleton<IBoard, DefaultBoard>()
           .BuildServiceProvider();

Console.WriteLine("Start a new game?");
var startGame = Console.ReadLine();

if (startGame.ToLower().StartsWith("y"))
{
    var game = serviceProvider.GetService<IGame>();
    game.SetStartingCell();

    Console.WriteLine($"{game.GetPlayerPosition()} - Score({game.GetScore()}) - Lives({game.GetLives()})");

    while (game.IsGameCompleted() != true && !game.IsGameOver())
    {
        Console.WriteLine("What's your move?");
        var position = Console.ReadLine();

        Enum.TryParse(position?.ToLower(), out MoveType move);
        game.MovePosition(move);
        game.IsGameCompleted();
        Console.WriteLine($"{game.GetPlayerPosition()} - Score({game.GetScore()}) - Lives({game.GetLives()})");
    }

    if (game.IsGameOver())
    {
        Console.WriteLine($"Game Over - You Loose");
    }
    else 
    {
        Console.WriteLine($"whoo hoo - Game complete.  Your score was {game.GetScore()}");
    }
    Console.ReadLine();
}
