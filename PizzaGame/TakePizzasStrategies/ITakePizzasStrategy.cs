using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame.TakePizzasStrategies
{
    public interface ITakePizzasStrategy
    {
        /// <summary>
        /// Return the number of pizzas to take given the valid moves
        /// </summary>
        /// <param name="validMoves"></param>
        /// <returns></returns>
        int TakePizzas(IEnumerable<int> validMoves);
    }
}
