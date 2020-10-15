using System;
using Chess_MP.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP
{
    /**
     * The class that contains the hovering logic.
     * @author Sebastian Davaris
     * @date 13-10-2020
     */
    public class Hover
    {
        private Game1 _game;
        private Vector2 _position;
        private Image _image;
        private MouseStateMachine _mouse;
        private bool _shouldUpdate;

        public event EventHandler<Vector2> OnClicked; 

        /**
         * Constructor
         * @param game The game reference.
         * @param position The position of the hover in normalized coordinates.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public Hover(Game1 game, Vector2 position)
        {
            _game = game;
            _position = position;
            _image = new Image(game, game.AssetManager.GetTexture("hover"), new Vector2(position.X * 64, position.Y * 64));
            _mouse = new MouseStateMachine(Mouse.GetState());

            Console.WriteLine("HOVER: " + position);
            
            _shouldUpdate = true;
            
            _game.OnUpdate += Update;
        }

        /**
         * Runs on every game 'tick'.
         * @param sender The sender of the event.
         * @param gameTime The currently elapsed gametime.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        private void Update(object sender, GameTime gameTime)
        {
            if(!_shouldUpdate)
                return;
            
            _mouse.Update(Mouse.GetState());

            if (_mouse.LeftClicked())
            {
                Point position = _mouse.GetPosition();

                if (_image.Rectangle.Contains(position))
                {
                    Console.WriteLine("CLICKED: " + _position.ToString());
                    OnClicked?.Invoke(this, _position);
                }
            }
            
            _mouse.Swap();
        }

        public void Disable()
        {
            _image.Disable();
            _shouldUpdate = false;
        }
    }
}