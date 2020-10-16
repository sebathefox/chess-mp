using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP
{
    public class Button
    {
        private GameController _gameController;
        
        private string _text;
        private Texture2D _texture;
        private Rectangle _rectangle;

        private MouseStateMachine _mouse;

        private bool _enabled;

        public event EventHandler OnClick;
        
        public Button(GameController gamecontroller, string text, Texture2D texture, Rectangle rectangle)
        {
            _gameController = gamecontroller;
            _text = text;
            _texture = texture;
            _rectangle = rectangle;

            _enabled = true;

            _mouse = new MouseStateMachine(Mouse.GetState());
            
            // Register events
            _gameController.Game.OnUpdate += Update;
            _gameController.Game.OnDraw += Draw;
        }

        protected virtual void Update(object sender, GameTime gameTime)
        {
            _mouse.Update(Mouse.GetState());

            Point pos = _mouse.GetPosition();
            
            if (_rectangle.Contains(pos))
            {
                if (_mouse.LeftClicked())
                {
                    OnClick?.Invoke(this, EventArgs.Empty);
                }
            }
                
            _mouse.Swap();
        }

        protected virtual void Draw(object sender, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            spriteBatch.Draw(_texture, _rectangle, Color.White);
            
            spriteBatch.DrawString(_gameController.Game.Font, _text, _rectangle.Location.ToVector2(), Color.Black);
            
            spriteBatch.End();
        }

        public void Disable()
        {
            _gameController.Game.OnDraw -= Draw;
            _gameController.Game.OnUpdate -= Update;
        }
        
        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public Texture2D Texture => _texture;

        public Rectangle Rectangle
        {
            get => _rectangle;
            set => _rectangle = value;
        }
    }
}
