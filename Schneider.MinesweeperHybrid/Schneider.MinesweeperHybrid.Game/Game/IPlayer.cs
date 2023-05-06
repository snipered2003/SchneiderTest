using Schneider.MinesweeperHybrid.Game.Enums;

namespace Schneider.MinesweeperHybrid.Game.Game
{
    public interface IPlayer
    {
        bool MovePosition(MoveType move, int boardSize);

        string GetPlayerPosition();

        void DecreaseLives(int amount = 1);

        int GetLives();
    }
}
