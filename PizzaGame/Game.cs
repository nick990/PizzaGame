using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame
{
    public class Game
    {
        const int MIN_PIZZAS = 11;
        const int MAX_PIZZAS = 20;
       
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
        /// Returns the winner Player
        /// </summary>
        public Player Play()
        {
            while (Pizzas > 0)
            {
                Console.WriteLine($"There are {Pizzas} pizzas left.");
                Console.WriteLine($"{_currentPlayer.Name}'s turn.");
                var validMoves = GetValidMoves();
                //If there are no valid moves, the player has to skip their turn
                if (validMoves.Count() == 0)
                {
                    Console.WriteLine($"{_currentPlayer.Name} has to skip this turn.");
                    Console.WriteLine();
                    ChangePlayer();
                    _lastPizzasTaken = null;
                    continue;
                }
                //If the only valid move is to take all the pizzas, the player loses
                if (validMoves.Count() == 1 && validMoves.First() == Pizzas)
                {
                    Console.WriteLine($"{_currentPlayer.Name} has to take the last pizza and loses.");
                    Console.WriteLine();
                    Pizzas = 0;
                    ChangePlayer();
                    break;                    
                }
                var pizzasToTake = _currentPlayer.TakePizzas(validMoves);
                Pizzas -= pizzasToTake;
                _lastPizzasTaken = pizzasToTake;
                Console.WriteLine($"{_currentPlayer.Name} took {pizzasToTake} pizzas.");
                Console.WriteLine();
                ChangePlayer();
            }
            GameOver();
            return _currentPlayer;
        }

        private void ChangePlayer()
        {
            _currentPlayer = _currentPlayer == Player1 ? Player2 : Player1;
        }

        /// <summary>
        /// Return the valid moves for the current player
        /// </summary>
        /// <returns></returns>
        private IEnumerable<int> GetValidMoves()
        {
            List<int> validMoves = new List<int>{1,2,3};
            if (_lastPizzasTaken.HasValue)
            {
                validMoves.Remove(_lastPizzasTaken.Value);
            }
            validMoves.RemoveAll(move => move > Pizzas);
            return validMoves;
        }

        private void GameOver()
        {
            Console.WriteLine("Pizzas are over...Game over!");
            Console.WriteLine($"{_currentPlayer.Name} wins!");
        }

        public static Game CreateNewGameInteractive()
        {
            var playerFactory = PlayerFactory.Instance;
            Player player1 = playerFactory.CreatePlayerInteractive();
            Player player2 = playerFactory.CreatePlayerInteractive();
            var pizzas = new Random().Next(MIN_PIZZAS, MAX_PIZZAS);
            return new Game(pizzas, player1, player2);
        }

    }
}
