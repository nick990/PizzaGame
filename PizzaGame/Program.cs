using PizzaGame;
using PizzaGame.TakePizzaStrategies;


Player player1 = new Player { Name = "PLAYER 1", TakePizzaStrategy = new HumanTakePizzaStrategy()};
Player player2 = new Player { Name = "PLAYER 2", TakePizzaStrategy = new CpuTakePizzaStrategy() };
Game game = new Game(10, player1, player2);
game.Play();
