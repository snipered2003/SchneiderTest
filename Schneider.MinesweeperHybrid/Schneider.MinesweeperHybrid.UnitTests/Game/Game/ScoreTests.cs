using Schneider.MinesweeperHybrid.Game.Game;
using System.Runtime.CompilerServices;

namespace Schneider.MinesweeperHybrid.UnitTests.Game.Game
{
    public class ScoreTests
    {
        [Fact]
        public void DefaultScore_ReturnsDefault()
        { 
            //Arrange
            var score = new Score();
            var expectedScore = 0;

            //Act
            var currentScore = score.GetCurrentScore();

            //Assert
            Assert.Equal(expectedScore, currentScore);
        }

        [Fact]
        public void UpdateScore_ReturnsIncrementedScore() 
        {
            //Arrange
            var score = new Score();
            var expectedScore = 1;

            //Act
            score.UpdateScore();
            var currentScore = score.GetCurrentScore();

            //Assert
            Assert.Equal(expectedScore, currentScore);
        }

        [Fact]
        public void DecreaseScore_ReturnsDecreasedScore()
        {
            //Arrange
            var score = new Score();
            var expectedScore = 2;

            //Act
            score.UpdateScore();
            score.UpdateScore();
            score.UpdateScore();
            score.DecreaseScore();
            var currentScore = score.GetCurrentScore();

            //Assert
            Assert.Equal(expectedScore, currentScore);
        }

        private Score CreateStrut()
        {
            return new Score();
        }
    }
}
