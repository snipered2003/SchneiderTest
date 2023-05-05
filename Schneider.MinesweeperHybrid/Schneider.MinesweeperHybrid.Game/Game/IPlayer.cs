using Schneider.MinesweeperHybrid.Game.Enums;

namespace Schneider.MinesweeperHybrid.Game.Game
{
    public interface IPlayer
    {
        void MovePosition(MoveType move);

        string GetPlayerPosition();

        void DecreaseLives(int amount = 1);

        int GetLives();
    }
}
