using Microsoft.Extensions.DependencyInjection;
using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Utilities.Constants;

namespace Schneider.MinesweeperHybrid.Actions
{
    public static class GameActions
    {
        public static void SetUpGame(ref IGame? game)
        {
            game?.SetStartingCell();
            OutputToUser($"{game?.GetPlayerPosition()} - Score({game?.GetScore()}) - Lives({game?.GetLives()})");
        }

        public static void GameShell(string startGame, IServiceProvider serviceProvider)
        {
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
        }

        public static void WhileGameIsRunning(ref IGame game)
        {
            var parsedMove = MoveType.up;
            OutputToUser(ProgramConstants.GameRunning);
            var position = Console.ReadLine();
            var validMove = true;

            try
            {
                parsedMove = (MoveType)Enum.Parse(typeof(MoveType), position?.ToLower());
                validMove = game.MovePosition(parsedMove);
            }
            catch 
            {
                validMove = false;
            }

            
            if (!validMove)
            {
                ChangeBackground(ConsoleColor.DarkRed);
                OutputToUser(ProgramConstants.IllegalMove);
                ChangeBackground(ConsoleColor.Black);
            }
            game.IsGameCompleted();
            OutputToUser($"{game.GetPlayerPosition()} - Score({game.GetScore()}) - Lives({game.GetLives()})");
        }

        public static void CheckIfGameOverOrCompleted(ref IGame game)
        {
            if (game.IsGameOver())
            {
                ChangeBackground(ConsoleColor.DarkRed);
                OutputToUser(ProgramConstants.GameOver);
                ChangeBackground(ConsoleColor.Black);
            }
            else
            {
                ChangeBackground(ConsoleColor.DarkGreen);
                OutputToUser($"{ProgramConstants.GameCompleted} {game.GetScore()}");
                ChangeBackground(ConsoleColor.Black);
            }
        }

        public static void OutputToUser(string text)
        {
            Console.WriteLine($"{text}");   
        }

        private static void ChangeBackground(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
    }
}
