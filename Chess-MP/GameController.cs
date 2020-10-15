using System.Collections.Generic;
using Chess_MP.Board;
using Chess_MP.States;

namespace Chess_MP
{
    public class GameController
    {
        private Game1 _game;
        private State _currentState;

        public GameController(Game1 game)
        {
            _game = game;
            _currentState = new PreGameState(this);
        }

        public bool IsInGame()
        {
            return (_currentState is InGameState);
        }

        public Game1 Game => _game;

        public State State => _currentState;
    }
}