using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP
{
    class Label
    {
        private GameController _gameController;

        private string _text;
        private Rectangle _rectangle;

        public Label(GameController gamecontroller, string text, Rectangle rectangle)
        {
            _gameController = gamecontroller;
            _text = text;
            _rectangle = rectangle;

            // Register events
            _gameController.Game.OnDraw += Draw;
        }
        protected virtual void Draw(object sender, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(_gameController.Game.Font, _text, _rectangle.Location.ToVector2(), Color.Red);

            spriteBatch.End();
        }

        public void Disable()
        {
            _gameController.Game.OnDraw -= Draw;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public Rectangle Rectangle
        {
            get => _rectangle;
            set => _rectangle = value;
        }
    }
}
