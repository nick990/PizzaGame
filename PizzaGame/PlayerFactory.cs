using PizzaGame.TakePizzasStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaGame
{
    public class PlayerFactory
    {
        private static readonly Lazy<PlayerFactory> instance = new Lazy<PlayerFactory>(() => new PlayerFactory());
        public static PlayerFactory Instance => instance.Value;
        private PlayerFactory() { }
        /// <summary>
        /// Create a player by asking the user for the player name and strategy.
        /// usedName is the name of the other player, to avoid having two players with the same name.
        /// </summary>
        /// <returns></returns>
        public Player CreatePlayerInteractive(string? usedName=null)
        {
            
            return new Player
            {
                Name = AskForName(usedName),
                TakePizzasStrategy = AskForStrategy()
            };
        }
        private string AskForName(string? usedName=null)
        {
            Console.Write("Enter player name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Choose a name, use a bit of imagination!");
                return AskForName(usedName);
            }
            name = name.Trim();
            name = Regex.Replace(name, @"\s", "_");
            name = name.Length > 10 ? name.Substring(0, 10) : name;
            if (usedName != null && name == usedName)
            {
                Console.WriteLine("Choose another name, you can't play against yourself.");
                return AskForName(usedName);
            }
            return name;
        }
        private ITakePizzasStrategy AskForStrategy()
        {
            Console.WriteLine("Select Player Type:\n 1 - Human\n 2 - CPU");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    return new HumanTakePizzasStrategy();
                case "2":
                    return new CpuTakePizzasStrategy();
                default:
                    Console.WriteLine("Invalid choice!");
                    return AskForStrategy();
            }
        }
    }
}
