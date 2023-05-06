using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Schneider.MinesweeperHybrid.Game.Models;
using Schneider.MinesweeperHybrid.Models;
using Schneider.MinesweeperHybrid.ServiceProvider;

namespace Schneider.MinesweeperHybrid
{
    public class Startup
    {
        public IServiceProvider serviceProvider;

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("settings.json", optional: false);

            IConfiguration config = builder.Build();

            Settings = config.GetSection("Settings").Get<Settings>();

            ConfigureServices();
        }

        private void ConfigureServices()
        {
            serviceProvider = new Services().provider;
        }

        public Settings Settings { get; private set; }
    }
}
