using Schneider.MinesweeperHybrid.Game.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;

namespace Schneider.MinesweeperHybrid.Models.Board
{
    public class DefaultBoard : BaseBoard, IBoard
    {
        public DefaultBoard(int size = GameConstants.DefaultBoardSize) 
        {
            CreateBoard(size, BoardConstants.DefaultNoOfBombs);
        }

        public void SetPosition(Cell cell)
        {
            cell.Occupied = true;
        }

        public bool HasBomb(Cell cell)
        {
            return Grid[cell.Row-1, cell.Col-1].HasBomb;
        }

        public int GetSize()
        {
            return Size;
        }
    }
}
