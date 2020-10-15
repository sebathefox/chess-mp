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
                Vector2 down = OneDown(position);
                Vector2 left = OneLeft(position);
                Vector2 downLeft = OneDownLeft(position);
            }
            else if (IsOnTop() && IsOnLeft())
            {
                Vector2 down = OneDown(position);
                Vector2 right = OneRight(position);
                Vector2 downRight = OneDownRight(position);
            }
            else if (IsOnBottom() && IsOnRight())
            {
                Vector2 up = OneUp(position);
                Vector2 left = OneLeft(position);
                Vector2 upLeft = OneUpLeft(position);
            }
            else if (IsOnBottom() && IsOnLeft())
            {
                Vector2 up = OneUp(position);
                Vector2 right = OneRight(position);
                Vector2 upRight = OneDownRight(position);
            }
            else if (IsOnRight())
            {
                Vector2 up = OneUp(position);
                Vector2 left = OneLeft(position);
                Vector2 downLeft = OneDownLeft(position);
                Vector2 upLeft = OneUpLeft(position);
                Vector2 down = OneDown(position);
            }
            else if (IsOnLeft())
            {
                Vector2 up = OneUp(position);
                Vector2 right = OneRight(position);
                Vector2 downRight = OneDownRight(position);
                Vector2 upRight = OneUpRight(position);
                Vector2 down = OneDown(position);
            }
            else if (IsOnTop())
            {
                Vector2 downRight = OneDownRight(position);
                Vector2 left = OneLeft(position);
                Vector2 downLeft = OneDownLeft(position);
                Vector2 right = OneRight(position);
                Vector2 down = OneDown(position);
            }
            else if (IsOnBottom())
            {
                Vector2 UpRight = OneUpRight(position);
                Vector2 left = OneLeft(position);
                Vector2 downLeft = OneDownLeft(position);
                Vector2 right = OneRight(position);
                Vector2 up = OneUp(position);
            }
            else
            {
                Vector2 up = OneUp(position);
                Vector2 down = OneDown(position);
                Vector2 left = OneLeft(position);
                Vector2 right = OneRight(position);
                Vector2 upLeft = OneUpLeft(position);
                Vector2 upRight = OneUpRight(position);
                Vector2 downLeft = OneDownLeft(position);
                Vector2 downRight = OneDownRight(position);
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
