using Schneider.MinesweeperHybrid.Game.Enums;

namespace Schneider.MinesweeperHybrid.Game.Game
{
    public interface IGame
    {
        void SetStartingCell();

        void MovePosition(MoveType move);

        bool IsGameCompleted();

        bool IsGameOver();

        int GetScore();

        int GetLives();

        string GetPlayerPosition();
    }
}
