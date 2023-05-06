using Schneider.MinesweeperHybrid.Models;
using Schneider.MinesweeperHybrid.Models.Board;

namespace Schneider.MinesweeperHybrid.UnitTests.Game.Board
{
    public class DefaultBoardTests
    {

        [Fact]
        public void HasBomb_FindsACellWithABomb()
        {
            //Arrange
            var board = CreateStrut();
            Cell cell = new Cell(1, 1);

            //Act
            var bomb = board.HasBomb(cell);

            //Assert
            Assert.False(bomb);
        }

        [Fact]
        public void GetSize_ReturnsCorrectAmount()
        {
            //Arrange
            var board = CreateStrut();
            var expectedSize = 8;

            //Act
            var size = board.GetSize();

            //Assert
            Assert.Equal(expectedSize, size);
        }

        private DefaultBoard CreateStrut()
        {
            return new DefaultBoard(8);
        }
    }
}
