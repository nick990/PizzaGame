using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame.TakePizzaStrategies
{
    public class PredefinedTakePizzaStrategy : ITakePizzaStrategy
    {
        private readonly Queue<int> _moves;
        public PredefinedTakePizzaStrategy(Queue<int> moves)
        {
            _moves = moves;
        }
        public int TakePizzas(IEnumerable<int> validMoves)
        {
            return _moves.Dequeue();
        }
    }
}
