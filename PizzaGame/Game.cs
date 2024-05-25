using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame
{
    public class Game
    {
       
        public int Pizzas { get; private set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        private Player _currentPlayer;
        private int? _lastPizzasTaken = null;
        public Game(int pizzas, Player player1, Player player2)
        {
            Pizzas = pizzas;
            Player1 = player1;
            Player2 = player2;
            _currentPlayer = Player1;
        }

        /// <summary>
        /// Starts the game
        /// Returns the winner
        /// </summary>
        public Player Play()
        {
            while (Pizzas > 0)
            {
                Console.WriteLine($"There are {Pizzas} pizzas left.");
                Console.WriteLine($"{_currentPlayer.Name}'s turn.");
                //Se non ho mosse valide, salto il turno
                var validMoves = GetValidMoves();
                if (validMoves.Count() == 0)
                {
                    Console.WriteLine($"{_currentPlayer.Name} has to skip this turn.");
                    break;
                }
                var pizzasToTake = _currentPlayer.TakePizzas(validMoves);
                Pizzas -= pizzasToTake;
                _lastPizzasTaken = pizzasToTake;
                Console.WriteLine($"{_currentPlayer.Name} took {pizzasToTake} pizzas.");
                Console.WriteLine();
                _currentPlayer = _currentPlayer == Player1 ? Player2 : Player1;
            }
            GameOver();
            return _currentPlayer;
        }

        private IEnumerable<int> GetValidMoves()
        {
            List<int> validMoves = new List<int>{1,2,3};
            if (_lastPizzasTaken.HasValue)
            {
                validMoves.Remove(_lastPizzasTaken.Value);
            }
            return validMoves;
        }

        private void GameOver()
        {
            Console.WriteLine("Game over!");
            Console.WriteLine($"{_currentPlayer.Name} wins!");
        }

    }
}
