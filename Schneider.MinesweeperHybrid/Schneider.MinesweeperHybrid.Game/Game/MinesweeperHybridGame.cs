using Schneider.MinesweeperHybrid.Game.Board;
using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Models.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;

namespace Schneider.MinesweeperHybrid.Models
{
    public class MinesweeperHybridGame : IGame
    {
        public bool completed = false;
        private IBoard board;
        private Cell currentCell;
        private IScore score;
        private Player player;

        public MinesweeperHybridGame(IScore score, IBoard board) 
        {
            this.board = board;
            currentCell = new Cell(GameConstants.DefaultStartingPos, GameConstants.DefaultStartingPos);
            player = new Player(ref currentCell);
            this.score = score;
        }

        public void SetStartingCell()
        {
            board.SetPosition(currentCell);
        }

        public bool MovePosition(MoveType move)
        {
            if (currentCell.Row < board.GetSize())
            {
                var result = player.MovePosition(move, board.GetSize());
                if (result)
                {
                    board.SetPosition(currentCell);
                    CheckIfCellHasBomb();
                }
                return result;
            }
            return false;
        }

        public bool IsGameCompleted()
        {
            completed = currentCell.Col == board.GetSize();
            return completed;
        }

        public string GetPlayerPosition()
        {
            return player.GetPlayerPosition();
        }

        public bool IsGameOver()
        {
            return player.GetLives() == GameConstants.DefaultZero ? true : false; 
        }

        public int GetScore()
        {
            return score.GetCurrentScore();
        }

        public int GetLives()
        {
            return player.GetLives();
        }

        private void CheckIfCellHasBomb()
        {
            if (!board.HasBomb(currentCell))
                score.UpdateScore();
            else
                player.DecreaseLives();
        }
    }
}
