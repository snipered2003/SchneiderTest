using Schneider.MinesweeperHybrid;
using Schneider.MinesweeperHybrid.Actions;
using Schneider.MinesweeperHybrid.Utilities.Constants;


var startup = new Startup();

GameActions.OutputToUser(ProgramConstants.StartText);
var startGame = Console.ReadLine();
GameActions.GameShell(startGame, startup);