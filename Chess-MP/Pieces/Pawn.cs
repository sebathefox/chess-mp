using System;
using System.Collections.Generic;
using System.Linq;
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

            if (!(IsOnBottom() || IsOnTop()) && game[front].Piece == null)
            {
                hovers.Add(new Hover(game, front));

                front = OneFront(front);

                if (!_hasMoved  && game[front].Piece == null)
                {
                    hovers.Add(new Hover(game, front));
                }
            }


            foreach (Piece piece in game.Players.Where(player => player.Color != Color).First().Pieces)
            {
                if (!(IsOnBottom() || IsOnTop()) && !IsOnLeft() && piece.Position == left)
                {
                    hovers.Add(new Hover(game, left));
                }
                else if (!(IsOnBottom() || IsOnTop()) && !IsOnRight() && piece.Position == right)
                {
                    hovers.Add(new Hover(game, left));
                }
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