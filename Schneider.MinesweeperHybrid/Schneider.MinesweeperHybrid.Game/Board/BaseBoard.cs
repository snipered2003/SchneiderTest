using Schneider.MinesweeperHybrid.Models.Board;
using Schneider.MinesweeperHybrid.Utilities.Constants;

namespace Schneider.MinesweeperHybrid.Game.Board
{
    public abstract class BaseBoard
    {
        public int Size { get; set; }

        public Cell[,]? Grid { get; set; }

        public virtual void CreateBoard(int size, int noOfBombs)
        {
            Size = size;

            Grid = new Cell[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new Cell(row, col);
                }
            }
            SetBombs(noOfBombs);
        }

        private void SetBombs(int noOfBombs)
        {
            int maxNoBombs = (Size * Size) - 2;

            if (noOfBombs > maxNoBombs)
            {
                noOfBombs = maxNoBombs;
            }

            for (int i = 0; i < noOfBombs; i++)
            {
                Random rand = new Random();
                int randomRow = rand.Next(BoardConstants.DefaultRandomMin, Size);
                int randomCol = rand.Next(BoardConstants.DefaultRandomMin, Size);
                Grid[randomRow, randomCol].HasBomb = true;
            }

        }
    }
}
