using Microsoft.Extensions.DependencyInjection;
using Schneider.MinesweeperHybrid.Game.Board;
using Schneider.MinesweeperHybrid.Game.Game;
using Schneider.MinesweeperHybrid.Models;
using Schneider.MinesweeperHybrid.Models.Board;

namespace Schneider.MinesweeperHybrid.ServiceProvider
{
    public class Services
    {
        public IServiceProvider provider;

        public Services()
        {
            provider = new ServiceCollection()
           .AddSingleton<IGame, MinesweeperHybridGame>()
           .AddSingleton<IScore, Score>()
           .AddSingleton<IBoard, DefaultBoard>()
           .BuildServiceProvider();
        }
    }
}
