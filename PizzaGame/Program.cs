using PizzaGame;
using PizzaGame.TakePizzaStrategies;

var playerFactory = PlayerFactory.Instance;
Player player1 = playerFactory.CreatePlayerInteractive();
Player player2 = playerFactory.CreatePlayerInteractive();
Game game = new Game(10, player1, player2);
game.Play();
