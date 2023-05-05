using Moq;
using Schneider.MinesweeperHybrid.Game.Board;
using Schneider.MinesweeperHybrid.Game.Enums;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Models;

namespace Schneider.MinesweeperHybrid.UnitTests.Game.Game
{
    public class MinesweeperHybridGameTests
    {
        Mock<IScore> MockedScore = new Mock<IScore>();
        Mock<IBoard> MockedBoard = new Mock<IBoard>();

        [Theory]
        [InlineData(MoveType.up)]
        [InlineData(MoveType.right)]
        public void CheckIfGameIsCompleted_ReturnsFalse(MoveType move)
        {
            //Arrange
            var game = CreateStrut();

            //Act
            game.MovePosition(move);

            //Assert
            Assert.False(game.IsGameCompleted());
        }

        [Fact]
        public void CheckIfGameIsCompleted_ReturnsTrue()
        {
            //Arrange
            var game = CreateStrut();
            MockedBoard.Setup(x => x.GetSize()).Returns(8);

            //Act
            for (var i = 0;i < 7; i++) 
            {
                game.MovePosition(MoveType.up);
            }

            //Assert
            Assert.True(game.IsGameCompleted());
        }

        [Fact]
        public void GetPlayerPosition_ReturnsCorrectPosition()
        {
            //Arrange
            var game = CreateStrut();
            var expectedOutcome = "[A2]";
            MockedBoard.Setup(x => x.GetSize()).Returns(8);

            //Act
            game.MovePosition(MoveType.up);
            var position = game.GetPlayerPosition();

            //Assert
            Assert.Equal(expectedOutcome, position);
        }

        [Fact]
        public void GetScore_ReturnsCorrectly()
        {
            //Arrange
            var game = CreateStrut();
            var expectedScore = 2;
            MockedBoard.Setup(x => x.GetSize()).Returns(8);
            MockedScore.Setup(x => x.GetCurrentScore()).Returns(2);

            //Act
            game.MovePosition(MoveType.up);
            game.MovePosition(MoveType.right);
            int score = game.GetScore();

            //Assert
            Assert.Equal(expectedScore, score);
        }

        [Fact]
        public void GetLives_ReturnsCorrectly()
        {
            //Arrange
            var game = CreateStrut();
            var expectedLives = 3;

            //Act
            game.MovePosition(MoveType.up);
            game.MovePosition(MoveType.right);
            int lives = game.GetLives();

            //Assert
            Assert.Equal(expectedLives, lives);
        }

        private MinesweeperHybridGame CreateStrut()
        {
            var game = new MinesweeperHybridGame(MockedScore.Object, MockedBoard.Object);
            game.SetStartingCell();
            return game;
        }

       
    }
}
