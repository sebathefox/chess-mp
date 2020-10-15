using System.Collections.Generic;
using System.Linq;
using Chess_MP.Board;
using Microsoft.Xna.Framework;

namespace Chess_MP.States
{
    public class InGameState : State
    {
        private Player[] _players;
        private List<Field> _fields;
        
        /// <inheritdoc />
        public InGameState(GameController gameController) : base(gameController)
        {
        }

        /// <inheritdoc />
        public override void EnterState()
        {
            _fields = new List<Field>();

            for (int xIndex = 0; xIndex < 8; xIndex++)
            {
                for (int y = 0; y < 8; y++)
                {
                    _fields.Add(new Field(_gameController, new Vector2(xIndex, y)));
                }
            }

            _players = new Player[]
            {
                new Player(_gameController, 1, "Sebastian", GameColor.Black),
                new Player(_gameController, 1, "Grøn", GameColor.White)
            };
        }

        /// <inheritdoc />
        public override void ExitState()
        {
            throw new System.NotImplementedException();
        }
        
        /**
         * Gets the field in the specific position.
         * @returns The specified Piece.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public Field this[Vector2 position] => _fields.First(field => field.Id == position);
        
        /**
         * Returns the list of Fields as readonly.
         * @returns The Fields.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public List<Field> Fields => _fields;

        public Player[] Players => _players;
    }
}