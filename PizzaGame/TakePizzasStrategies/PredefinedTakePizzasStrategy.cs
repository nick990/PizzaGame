using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame.TakePizzasStrategies
{
    public class PredefinedTakePizzasStrategy : ITakePizzasStrategy
    {
        private readonly Queue<int> _moves;
        public PredefinedTakePizzasStrategy(Queue<int> moves)
        {
            _moves = moves;
        }
        public int TakePizzas(IEnumerable<int> validMoves)
        {
            return _moves.Dequeue();
        }
    }
}
