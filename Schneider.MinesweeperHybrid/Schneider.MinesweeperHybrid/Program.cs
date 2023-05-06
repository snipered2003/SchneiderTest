using Microsoft.Extensions.DependencyInjection;
using Schneider.MinesweeperHybrid.Actions;
using Schneider.MinesweeperHybrid.Game.Board;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Models;
using Schneider.MinesweeperHybrid.Models.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;

var serviceProvider = new ServiceCollection()
           .AddSingleton<IGame, MinesweeperHybridGame>()
           .AddSingleton<IScore, Score>()
           .AddSingleton<IBoard, DefaultBoard>()
           .BuildServiceProvider();

GameActions.OutputToUser(ProgramConstants.StartText);
var startGame = Console.ReadLine();

if (startGame.ToLower().StartsWith(ProgramConstants.StartVal))
{
    var game = serviceProvider.GetService<IGame>();
    GameActions.SetUpGame(ref game);

    while (game.IsGameCompleted() != true && !game.IsGameOver())
    {
        GameActions.WhileGameIsRunning(ref game);
    }

    GameActions.CheckIfGameOverOrCompleted(ref game);
    Console.ReadLine();
}