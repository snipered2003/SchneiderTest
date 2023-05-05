using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Models.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;
using Schneider.MinesweeperHybrid.Utilities.Helpers;

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

        public void MovePosition(MoveType move)
        {
            switch (move)
            {
                case MoveType.left:
                    currentCell.Row--;

                    break;
                case MoveType.right:
                    currentCell.Row++;

                    break;
                case MoveType.up:
                    currentCell.Col++;

                    break;
                case MoveType.down:
                    currentCell.Col--;
                    break;
                default:
                    break;
            }
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
