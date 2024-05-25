using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame.TakePizzaStrategies
{
    public interface ITakePizzaStrategy
    {
        int TakePizzas(IEnumerable<int> validMoves);
    }
}
