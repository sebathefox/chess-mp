using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Board
{
    public class Board
    {
        private Game1 _game;
        private Image _image;

        public Board(Game1 game, Texture2D texture)
        {
            _game = game;
            _image = new Image(_game, texture, Vector2.Zero);
        }
    }
}