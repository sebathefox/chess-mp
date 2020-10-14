using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class King : Piece
    {

        private bool _hasMoved;

        public King(Game1 game, Player player, Vector2 position) : base(game, player, game.AssetManager.GetTexture(player.Color.ToString().ToLower() + "-king"), position)
        {
            _hasMoved = false;
        }


        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();

            Vector2 up = OneUp(position);
            Vector2 down = OneDown(position);
            Vector2 left = OneLeft(position);
            Vector2 right = OneRight(position);
            Vector2 upLeft = OneUpLeft(position);
            Vector2 upRight = OneUpRight(position);
            Vector2 downLeft = OneDownLeft(position);
            Vector2 downRight = OneDownRight(position);

            return hovers;
        }

        protected override void OnHoverClicked(object sender, Vector2 position)
        {
            base.OnHoverClicked(sender, position);
            _hasMoved = true;
        }
    }
}
