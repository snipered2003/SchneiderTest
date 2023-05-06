using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Models.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;
using Schneider.MinesweeperHybrid.Utilities.Helpers;
using System.Runtime.CompilerServices;

namespace Schneider.MinesweeperHybrid.Game.Game
{
    public class Player : IPlayer
    {
        int lives = GameConstants.DefaultNoOfLives;
        Cell currentCell;

        public Player(ref Cell currentCell)
        {
            this.currentCell = currentCell;
        }

        public bool MovePosition(MoveType move, int boardSize)
        {
            switch (move)
            {
                case MoveType.left:
                    if (currentCell.Row == 1)
                        return false;
                    currentCell.Row--;
                    break;
                case MoveType.right:
                    if (currentCell.Row > boardSize)
                        return false;
                    currentCell.Row++;
                    break;
                case MoveType.up:
                    if (currentCell.Col > boardSize)
                        return false;
                    currentCell.Col++;
                    break;
                case MoveType.down:
                    if (currentCell.Col == 1)
                        return false;
                    currentCell.Col--;
                    break;
                default:
                    return false;
            }
            return true;
        }

        public string GetPlayerPosition()
        {
            var convertRowToLetter = ConvertHelper.ConvertRowToLetter(currentCell.Row);

            return $"[{convertRowToLetter}{currentCell.Col}]";
        }

        public void DecreaseLives(int amount = 1)
        {
            lives = lives - amount;
        }

        public int GetLives()
        {
            return lives;
        }
    }
}
