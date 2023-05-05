using Schneider.MinesweeperHybrid.Utilities.Constants;

namespace Schneider.MinesweeperHybrid.Game.Game
{
    public class Score : IScore
    {
        int currentScore = GameConstants.DefaultZero;

        public void UpdateScore(int amount = 1)
        {
            currentScore = currentScore + amount;
        }

        public void DecreaseScore(int amount = 1)
        {
            currentScore = currentScore - amount;
        }

        public int GetCurrentScore()
        { 
            return currentScore; 
        }
    }
}
