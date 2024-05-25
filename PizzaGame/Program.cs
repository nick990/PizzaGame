using PizzaGame;


Player player1 = new Player { Name = "PLAYER 1"};
Player player2 = new Player { Name = "PLAYER 2" };
Game game = new Game(10, player1, player2);
game.Play();
