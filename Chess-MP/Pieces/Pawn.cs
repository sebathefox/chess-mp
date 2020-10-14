using System;
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

            Console.WriteLine(front.ToString());

            if (game[front].Piece == null)
            {
                hovers.Add(new Hover(game, front));

                front = OneFront(front);

                if (game[front].Piece == null && !_hasMoved)
                {
                    hovers.Add(new Hover(game, front));
                }
            }

            if (!IsOnLeft() && game[left].Piece != null && IsEnemy(game[left].Piece))
            {
                hovers.Add(new Hover(game, left));
            }
            
            if (!IsOnRight() && game[right].Piece != null && IsEnemy(game[right].Piece))
            {
                hovers.Add(new Hover(game, right));
            }
            
            return hovers;
        }

        /// <inheritdoc />
        protected override void OnHoverClicked(object sender, Vector2 position)
        {
            base.OnHoverClicked(sender, position);
            _hasMoved = true;
        }
    }
}