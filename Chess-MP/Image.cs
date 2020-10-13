using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP
{
    public class Image
    {
        private Game1 _game;
        private Texture2D _texture;
        private Vector2 _targetPosition;

        public Image(Game1 game, Texture2D texture, Vector2 position)
        {
            _game = game;
            _texture = texture;
            _targetPosition = position;

            _game.OnDraw += Draw;
        }

        public void SetPosition(Vector2 position)
        {
            _targetPosition = position;
        }

        public Vector2 Position => _targetPosition;
        
        private void Draw(object sender, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_texture, _targetPosition, Color.White);
            spriteBatch.End();
        }
    }
}