using PizzaGame;
using PizzaGame.TakePizzaStrategies;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class Test
    { 
        [Fact]
        public void Test1()
        {
            var playerAMoves = new Queue<int>(new[] { 1, 2, 3 });
            var playerBMoves = new Queue<int>(new[] { 3, 1, 2 });
            var startingPizzas = 12;
            var playerA = new Player { Name = "Player A", TakePizzaStrategy = new PredefinedTakePizzaStrategy(playerAMoves) };
            var playerB = new Player { Name = "Player B", TakePizzaStrategy = new PredefinedTakePizzaStrategy(playerBMoves) };
            var game = new Game(startingPizzas, playerA, playerB);
            var winner  = game.Play();
            Assert.Equal(playerA, winner);
        }
    }
}