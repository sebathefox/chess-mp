using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP
{
    /**
     * Contains the required code to render a sprite on-screen.
     * @author Sebastian Davaris
     * @date 13-10-2020
     */
    public class Image
    {
        private Game1 _game;
        private Texture2D _texture;
        private Vector2 _targetPosition;

        /**
         * Constructor
         * @param game The Game instance this image belongs to.
         * @param texture The texture to render.
         * @param position The Vector2 position to render the texture.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
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

        public void AddX(float x)
        {
            _targetPosition.X += x;
        }

        public void SubtractX(float x)
        {
            _targetPosition.X -= x;
        }
        
        public void AddY(float y)
        {
            _targetPosition.Y += y;
        }

        public void SubtractY(float y)
        {
            _targetPosition.Y -= y;
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