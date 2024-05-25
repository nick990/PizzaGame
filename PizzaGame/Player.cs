using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaGame.TakePizzaStrategies;

namespace PizzaGame
{
    public class Player
    {
        public string Name { get; set; }
        public ITakePizzaStrategy TakePizzaStrategy { get; set; }
        public int TakePizzas(IEnumerable<int> validMoves)
        {
            return TakePizzaStrategy.TakePizzas(validMoves);
        }
    }
}
