using System;
using System.Linq;
using Chess_MP.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP.Board
{
    /**
     * Contains the logic for fields.
     * @author Sebastain Davaris
     * @date 12-10-2020
     */
    public class Field
    {
        private readonly GameController _gameController;
        private readonly Vector2 _id;
        private Piece _piece;
        private readonly Rectangle _rect;
        private MouseStateMachine _mouse;

        /**
         * Contains the values a field requires
         * @author Kasper Gr�n
         * @date 13-10-2020
         */
        public Field(GameController gameController, Vector2 id)
        {
            _gameController = gameController;
            _id = id;
            _piece = null;
            _rect = new Rectangle(new Point((int) (id.X * 64), (int) (id.Y * 64)), new Point(64, 64));

            _mouse = new MouseStateMachine(Mouse.GetState());
            
            _gameController.Game.OnUpdate += Update;
        }

        private void Update(object sender, GameTime gameTime)
        {
            _mouse.Update(Mouse.GetState());

            if (_mouse.LeftClicked())
            {
                Point position = _mouse.GetPosition();

                if (_rect.Contains(position))
                {
                    Console.WriteLine("CLICKED: " + _id);
                }
            }
            
            _mouse.Swap();
        }

        public void SetPiece(Piece piece)
        {
            if (_piece != null)
            {
            }
            
            _piece = piece;

        }

        /**
         * Gets the ID of the field.
         * @author Kasper Gr�n
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