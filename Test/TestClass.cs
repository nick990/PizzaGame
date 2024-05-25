using PizzaGame;
using PizzaGame.TakePizzasStrategies;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class Test
    {
        /// <summary>
        /// Esempio da https://github.com/Studiofarma/PizzaGame/
        /// B termina mangiando 2 pizze
        /// </summary>
        [Fact]
        public void Test1()
        {
            var playerAMoves = new Queue<int>(new[] { 1, 2, 3 });
            var playerBMoves = new Queue<int>(new[] { 3, 1, 2 });
            var startingPizzas = 12;
            var playerA = new Player { Name = "Player A", TakePizzasStrategy = new PredefinedTakePizzasStrategy(playerAMoves) };
            var playerB = new Player { Name = "Player B", TakePizzasStrategy = new PredefinedTakePizzasStrategy(playerBMoves) };
            var game = new Game(startingPizzas, playerA, playerB);
            var winner  = game.Play();
            Assert.Equal(playerA, winner);
        }

        /// <summary>
        /// Esempio da https://github.com/Studiofarma/PizzaGame/
        /// B termina mangiando 1 pizza
        /// </summary>
        [Fact]
        public void Test2()
        {
            var playerAMoves = new Queue<int>(new[] { 1, 2, 3 });
            var playerBMoves = new Queue<int>(new[] { 3, 1, 1 });
            var startingPizzas = 12;
            var playerA = new Player { Name = "Player A", TakePizzasStrategy = new PredefinedTakePizzasStrategy(playerAMoves) };
            var playerB = new Player { Name = "Player B", TakePizzasStrategy = new PredefinedTakePizzasStrategy(playerBMoves) };
            var game = new Game(startingPizzas, playerA, playerB);
            var winner = game.Play();
            Assert.Equal(playerA, winner);
        }
    }
}