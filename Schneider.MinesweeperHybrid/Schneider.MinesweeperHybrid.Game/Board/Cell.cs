namespace Schneider.MinesweeperHybrid.Models.Board
{
    public class Cell
    {
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public bool Occupied { get; set; }

        public bool HasBomb { get; set; }
    }
}
