namespace Schneider.MinesweeperHybrid.Game.Game
{
    public interface IScore
    {
        void UpdateScore(int amount = 1);

        void DecreaseScore(int amount = 1);

        int GetCurrentScore();
    }
}
