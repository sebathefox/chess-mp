using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        
        /// <inheritdoc />
        public Pawn(GameController game, Player player, Vector2 position) : base(game, player, game.Game.AssetManager.GetTexture(player.Color.ToString().ToLower() + "-pawn"), position)
        {
            _hasMoved = false;
        }

        /// <inheritdoc />
        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();
            
            if (!game.IsInGame())
            {
                return hovers;
            }

            InGameState state = game.State as InGameState;

            Vector2 front = OneFront(position);

            Vector2 left = OneLeft(front);
            Vector2 right = OneRight(front);

            // Console.WriteLine(front.ToString());

            if (!(IsOnBottom() || IsOnTop()) && state[front].Piece == null)
            {
                hovers.Add(new Hover(game.Game, front));

                front = OneFront(front);

                if (!_hasMoved  && state[front].Piece == null)
                {
                    hovers.Add(new Hover(game.Game, front));
                }
            }

            if (!(IsOnBottom() || IsOnTop()) && !IsOnLeft() && state[left].Piece != null && IsEnemy(state[left].Piece))
            {
                hovers.Add(new Hover(game.Game, left));
            }

            Console.WriteLine(state[right].Piece);
            if (!(IsOnBottom() || IsOnTop()) && !IsOnRight() && state[right].Piece != null && IsEnemy(state[right].Piece))
            {
                hovers.Add(new Hover(game.Game, right));
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