using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP
{
    public class MouseStateMachine
    {
        private MouseState _oldState;
        private MouseState _state;

        public MouseStateMachine(MouseState state)
        {
            _state = _oldState = state;
        }

        public void Update(MouseState newState)
        {
            _state = newState;
        }

        public void Swap()
        {
            _oldState = _state;
        }

        public bool LeftClicked()
        {
            return _state.LeftButton == ButtonState.Pressed &&
                   _oldState.LeftButton == ButtonState.Released;
        }

        public Point GetPosition()
        {
            return _state.Position;
        }
    }
}