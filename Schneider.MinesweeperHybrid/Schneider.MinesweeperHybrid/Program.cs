using Schneider.MinesweeperHybrid.Actions;
using Schneider.MinesweeperHybrid.ServiceProvider;
using Schneider.MinesweeperHybrid.Utilities.Constants;

var serviceProvider = new Services().provider;

GameActions.OutputToUser(ProgramConstants.StartText);
var startGame = Console.ReadLine();
GameActions.GameShell(startGame, serviceProvider);