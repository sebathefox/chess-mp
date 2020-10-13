using System;
using System.Collections.Generic;
using Chess_MP.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP.Pieces
{
    /**
     * Base class for the different types of pieces.
     * @author Sebastian Davaris
     * @date 13-10-2020
     */
    public abstract class Piece
    {
        private Game1 _game;
        private readonly Player _player;
        private Image _image;
        private MouseStateMachine _mouse;
        
        protected Piece(Game1 game, Player player, Texture2D texture, Vector2 position)
        {
            _game = game;
            _player = player;

            // TODO: Get a pixel offset and send to image.
            _image = new Image(game, texture, position);

            _mouse = new MouseStateMachine(Mouse.GetState());
            
            _game.OnUpdate += Update;
        }
        
        /**
         * Gets the fields this piece can move to.
         * @author Sebastian Davaris
         * @date 12-10-2020
         * @returns The possible moves.
         */
        protected abstract IEnumerable<Field> GetPossibleFields();

        protected virtual void Update(object sender, GameTime gameTime)
        {
            // Updates the state.
            _mouse.Update(Mouse.GetState());

            if (_mouse.LeftClicked())
            {
                Point position = _mouse.GetPosition();

                if (_image.Rectangle.Contains(position))
                {
                    throw new Exception("YEET");
                }
            }
            
            // Resets the state.
            _mouse.Swap();

            KeyboardState state = Keyboard.GetState();
            
            if(state.IsKeyDown(Keys.W))
                _image.SetPosition(new Vector2(_image.Position.X, _image.Position.Y - 1));
            if(state.IsKeyDown(Keys.S))
                _image.SetPosition(new Vector2(_image.Position.X, _image.Position.Y + 1));
            if(state.IsKeyDown(Keys.A))
                _image.SetPosition(new Vector2(_image.Position.X - 1, _image.Position.Y));
            if(state.IsKeyDown(Keys.D))
                _image.SetPosition(new Vector2(_image.Position.X + 1, _image.Position.Y));
        }

        public bool IsEnemy(Piece other)
        {
            return this.Color != other.Color;
        }
        
        public int Id { get; protected set; }

        /**
         * Returns the piece's colour
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        public GameColor Color => _player.Color;
    }
}