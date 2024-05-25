# PizzaGame
## Run
```bash
dotnet run --project PizzaGame
```
## Test
```bash
dotnet test Test
```
## Class Diagram

```mermaid
classDiagram
class Player{
    + Name: string
    + TakePizzasStrategy: ITakePizzasStrategy
    + TakePizzas(IEnumerable< int> validMoves) int
}
class ITakePizzasStrategy  {
    <<interface>>
    + TakePizzas(IEnumerable< int> validMoves) int
}
class HumanTakePizzasStrategy
class CpuTakePizzasStrategy
class PredefinedTakePizzasStrategy{
    - _moves: IEnumerable< int>
}
HumanTakePizzasStrategy ..|> ITakePizzasStrategy
CpuTakePizzasStrategy ..|> ITakePizzasStrategy
PredefinedTakePizzasStrategy ..|> ITakePizzasStrategy
Player --> ITakePizzasStrategy:TakePizzasStrategy
class PlayerFactory{
    + Instance : PlayerFactory$
    + CreatePlayerInteractive() Playe
}
note for PlayerFactory "Singleton"
PlayerFactory --> Player
class Game{
    + Players1: Player
    + Players2: Player
    + Pizzas: int
    + Play() Player
    + CreateNewGameInteractive() Game$
}
Game --> Player
Game --> PlayerFactory
note for HumanTakePizzasStrategy "Ask to the user how many pizzas to take."
note for CpuTakePizzasStrategy "Take a random number of pizzas."
note for PredefinedTakePizzasStrategy "Follow a predefined list of moves.\nFor test purposes."
```
## Esempio
```c#
var playerAMoves = new Queue<int>(new[] { 1, 2, 3 });
var playerBMoves = new Queue<int>(new[] { 3, 1, 1 });
var startingPizzas = 12;
var playerA = new Player { Name = "Player A", TakePizzasStrategy = new PredefinedTakePizzasStrategy(playerAMoves) };
var playerB = new Player { Name = "Player B", TakePizzasStrategy = new PredefinedTakePizzasStrategy(playerBMoves) };
var game = new Game(startingPizzas, playerA, playerB);
game.Play();
```
```
There are 12 pizzas left.
Player A's turn.
Player A took 1 pizza.

There are 11 pizzas left.
Player B's turn.
Player B took 3 pizzas.

There are 8 pizzas left.
Player A's turn.
Player A took 2 pizzas.

There are 6 pizzas left.
Player B's turn.
Player B took 1 pizza.

There are 5 pizzas left.
Player A's turn.
Player A took 3 pizzas.

There are 2 pizzas left.
Player B's turn.
Player B took 1 pizza.

There is 1 pizza left.
Player A's turn.
Player A has to skip this turn.

There is 1 pizza left.
Player B's turn.
Player B has to take the last pizza and loses.

Pizzas are over...Game over!
Player A wins!
```
