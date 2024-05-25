using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaGame.TakePizzaStrategies
{
    public class HumanTakePizzaStrategy : ITakePizzaStrategy
    {
        public int TakePizzas(IEnumerable<int> validMoves)
        {
            Console.WriteLine($"How many pizzas do you want to take?");
            int pizzasToTake;
            bool isNumber;
            do
            {
                isNumber = int.TryParse(Console.ReadLine(), out pizzasToTake);
                if (!isNumber)
                {
                    Console.WriteLine("Please enter a number.");
                }
            } while (!isNumber);

            if (!validMoves.Contains(pizzasToTake))
            {
                Console.WriteLine($"You can only take {string.Join(", ", validMoves.Select(m => m.ToString()))} pizzas.");
                return TakePizzas(validMoves);
            }
            return pizzasToTake;
        }
    }
}
