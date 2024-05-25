using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaGame.TakePizzasStrategies;

namespace PizzaGame
{
    public class Player
    {
        public string Name { get; set; }
        public ITakePizzasStrategy TakePizzasStrategy { get; set; }
        /// <summary>
        /// Return the number of pizzas to take given the valid moves.
        /// Calls the TakePizzas method of the ITakePizzaStrategy (Strategy Pattern).
        /// </summary>
        /// <param name="validMoves"></param>
        /// <returns></returns>
        public int TakePizzas(IEnumerable<int> validMoves)
        {
            return TakePizzasStrategy.TakePizzas(validMoves);
        }
    }
}
