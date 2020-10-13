using System;
using Chess_MP.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP
{
    public class Hover
    {
        private Game1 _game;
        private Vector2 _position;
        private Image _image;
        private MouseStateMachine _mouse;

        public Hover(Game1 game, Vector2 position)
        {
            _game = game;
            _position = position;
            _image = new Image(game, game.AssetManager.GetTexture("hover"), new Vector2(position.X * 64, position.Y * 64));
            _mouse = new MouseStateMachine(Mouse.GetState());

            _game.OnUpdate += Update;
        }

        private void Update(object sender, GameTime gameTime)
        {
            _mouse.Update(Mouse.GetState());

            if (_mouse.LeftClicked())
            {
                Point position = _mouse.GetPosition();

                if (_image.Rectangle.Contains(position))
                {
                    Console.WriteLine("CLICKED: " + _position.ToString());
                }
            }
            
            _mouse.Swap();
        }
    }
}