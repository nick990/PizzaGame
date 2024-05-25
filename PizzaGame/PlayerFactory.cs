using PizzaGame.TakePizzaStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame
{
    public class PlayerFactory
    {
        private static readonly Lazy<PlayerFactory> instance = new Lazy<PlayerFactory>(() => new PlayerFactory());
        public static PlayerFactory Instance => instance.Value;
        private PlayerFactory() { }
        public Player CreatePlayerInteractive()
        {
            Console.WriteLine("Enter player name:");
            var name = Console.ReadLine();
            return new Player
            {
                Name = name,
                TakePizzaStrategy = SelectStrategyInteractive()
            };
        }

        private ITakePizzaStrategy SelectStrategyInteractive()
        {
            Console.WriteLine("Select Player Type: 1 - Human, 2 - CPU");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    return new HumanTakePizzaStrategy();
                case "2":
                    return new CpuTakePizzaStrategy();
                default:
                    Console.WriteLine("Invalid choice!");
                    return SelectStrategyInteractive();
            }
        }
    }
}
