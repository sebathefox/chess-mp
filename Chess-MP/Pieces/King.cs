using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class King : Piece
    {

        private bool _hasMoved;

        public King(GameController game, Player player, Vector2 position) : base(game, player, game.Game.AssetManager.GetTexture(player.Color.ToString().ToLower() + "-king"), position)
        {
            _hasMoved = false;
        }


        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();

            if (IsOnTop() && IsOnRight())
            {
                
                hovers.Add(new Hover(game, OneDown(position)));
                hovers.Add(new Hover(game, OneDownLeft(position)));
                hovers.Add(new Hover(game, OneLeft(position)));

                
            }
            else if (IsOnTop() && IsOnLeft())
            {
                hovers.Add(new Hover(game, OneDown(position)));
                hovers.Add(new Hover(game, OneDownRight(position)));
                hovers.Add(new Hover(game, OneRight(position)));
            }
            else if (IsOnBottom() && IsOnRight())
            {
                hovers.Add(new Hover(game, OneUpLeft(position)));
                hovers.Add(new Hover(game, OneLeft(position)));
                hovers.Add(new Hover(game, OneUp(position)));
            }
            else if (IsOnBottom() && IsOnLeft())
            {
                hovers.Add(new Hover(game, OneUp(position)));
                hovers.Add(new Hover(game, OneRight(position)));
                hovers.Add(new Hover(game, OneUpRight(position)));
            }
            else if (IsOnRight())
            {
                hovers.Add(new Hover(game, OneUp(position)));
                hovers.Add(new Hover(game, OneLeft(position)));
                hovers.Add(new Hover(game, OneDownLeft(position)));
                hovers.Add(new Hover(game, OneUpLeft(position)));
                hovers.Add(new Hover(game, OneDown(position)));
            }
            else if (IsOnLeft())
            {
                hovers.Add(new Hover(game, OneUp(position)));
                hovers.Add(new Hover(game, OneRight(position)));
                hovers.Add(new Hover(game, OneDownRight(position)));
                hovers.Add(new Hover(game, OneUpRight(position)));
                hovers.Add(new Hover(game, OneDown(position)));
                Vector2 up = OneUp(position);
                Vector2 right = OneRight(position);
                Vector2 downRight = OneDownRight(position);
                Vector2 upRight = OneUpRight(position);
                Vector2 down = OneDown(position);
            }
            else if (IsOnTop())
            {
                hovers.Add(new Hover(game, OneDownRight(position)));
                hovers.Add(new Hover(game, OneLeft(position)));
                hovers.Add(new Hover(game, OneDownLeft(position)));
                hovers.Add(new Hover(game, OneRight(position)));
                hovers.Add(new Hover(game, OneDown(position)));
            }
            else if (IsOnBottom())
            {
                hovers.Add(new Hover(game, OneUpRight(position)));
                hovers.Add(new Hover(game, OneLeft(position)));
                hovers.Add(new Hover(game, OneDownLeft(position)));
                hovers.Add(new Hover(game, OneUpLeft(position)));
                hovers.Add(new Hover(game, OneUp(position)));
            }
            else
            {
                hovers.Add(new Hover(game, OneDown(position)));
                hovers.Add(new Hover(game, OneLeft(position)));
                hovers.Add(new Hover(game, OneUp(position)));
                hovers.Add(new Hover(game, OneRight(position)));
                hovers.Add(new Hover(game, OneUpLeft(position)));
                hovers.Add(new Hover(game, OneUpRight(position)));
                hovers.Add(new Hover(game, OneDownRight(position)));
                hovers.Add(new Hover(game, OneDownLeft(position)));
            }

            return hovers;
        }

        protected override void OnHoverClicked(object sender, Vector2 position)
        {
            base.OnHoverClicked(sender, position);
            _hasMoved = true;
        }
    }
}
