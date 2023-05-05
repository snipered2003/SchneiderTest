using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Models.Board;

namespace Schneider.MinesweeperHybrid.UnitTests.Game.Game
{
    public class PlayerTests
    {
        [Fact]
        public void GetPlayerPosition_ReturnsCellPosition()
        {
            //Arrange
            Cell cell = new Cell(1,2);
            var player = CreateStrut(cell);
            var expectedPosition = "[A3]";

            //Act
            player.MovePosition(MoveType.up);

            //Assert
            Assert.Equal(expectedPosition, player.GetPlayerPosition());
        }

        [Fact]
        public void GetLives_ReturnsNumberOfLives()
        {
            //Arrange
            Cell cell = new Cell(1, 2);
            var player = CreateStrut(cell);

            //Act
            var lives = player.GetLives();

            //Assert
            Assert.Equal(3, lives);
        }

        [Fact]
        public void DecreaseLives_ReturnsNumberOfLivesLeft()
        {
            //Arrange
            Cell cell = new Cell(1, 2);
            var player = CreateStrut(cell);

            //Act
            player.DecreaseLives();
            var lives = player.GetLives();

            //Assert
            Assert.Equal(2, lives);
        }

        private Player CreateStrut(Cell cell)
        {
            return new Player(ref cell);
        }
    }
}
