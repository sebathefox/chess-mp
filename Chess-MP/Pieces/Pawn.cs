using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        
        /// <inheritdoc />
        public Pawn(Game1 game, Player player, Vector2 position) : base(game, player, game.AssetManager.GetTexture(player.Color.ToString().ToLower() + "-pawn"), position)
        {
            _hasMoved = false;
        }

        /// <inheritdoc />
        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();

            Vector2 front = OneFront(position);

            Vector2 left = OneLeft(front);
            Vector2 right = OneRight(front);

            if (game[front].Piece == null)
            {
                hovers.Add(new Hover(game, front));

                front = OneFront(position);

                if (game[front].Piece == null && !_hasMoved)
                {
                    hovers.Add(new Hover(game, front));
                }
            }

            if (game[left].Piece != null && IsEnemy(game[left].Piece))
            {
                hovers.Add(new Hover(game, left));
            }
            
            if (game[right].Piece != null && IsEnemy(game[right].Piece))
            {
                hovers.Add(new Hover(game, right));
            }
            
            return hovers;
        }
    }
}