using Schneider.MinesweeperHybrid.Models.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;

namespace Schneider.MinesweeperHybrid.Game.Board
{
    public interface IBoard
    {
        void SetPosition(Cell cell);

        bool HasBomb(Cell cell);

        int GetSize();
    }
}
