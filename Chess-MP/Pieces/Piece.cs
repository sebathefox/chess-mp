using System.Collections.Generic;
using Chess_MP.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public abstract class Piece
    {
        private Game1 _game;
        private Image _image;

        public Piece(Game1 game, Texture2D texture, Vector2 position)
        {
            _game = game;
            // TODO: Get a pixel offset and send to image.
            _image = new Image(game, texture, position);

            _game.OnUpdate += Update;
        }
        
        /**
         * Gets the fields this piece can move to.
         * @author Sebastian Davaris
         * @date 12-10-2020
         * @returns The possible moves.
         */
        protected abstract IEnumerable<Field> GetPossibleFields();

        protected virtual void Update(object sender, GameTime gameTime)
        {
            
        }

        public int Id { get; protected set; }
        
        /**
         * Returns the piece's colour
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        public GameColor Color { get; protected set; }
    }
}