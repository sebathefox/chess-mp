using Chess_MP.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Board
{
    /**
     * Contains the logic for fields.
     * @author Sebastain Davaris
     * @date 12-10-2020
     */
    public class Field
    {

        private readonly Game1 _game;
        private readonly Vector2 _id;
        private Piece _piece;
        private readonly Rectangle _rect;

        /**
         * Contains the values a field requires
         * @author Kasper Grøn
         * @date 13-10-2020
         */

        public Field(Game1 game, Vector2 id, Point rectOffset)
        {
            _game = game;
            _id = id;
            _piece = null;
            _rect = new Rectangle(rectOffset, new Point(64, 64));

            _game.OnUpdate += Update;
        }

        private void Update(object sender, GameTime gameTime)
        {

        }

        /**
         * Gets the ID of the field.
         * @author Kasper Grøn
         * @date 13-10-2020
         */
        public Vector2 Id => _id;

        public Rectangle Rect => _rect;

        /**
         * Gets the piece currently on the field.
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        public Piece Piece => _piece;
    }
}