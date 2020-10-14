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
        protected Game1 game;
        private readonly Player _player;
        private Image _image;
        private MouseStateMachine _mouse;
        protected Vector2 position;
        protected Direction direction;

        
        /**
         * Constructor
         * @param game The Game reference.
         * @param player The reference to this piece's owner.
         * @param texture The texture of this Piece.
         * @param position The position of this Piece in normalized coordinates.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        protected Piece(Game1 game, Player player, Texture2D texture, Vector2 position)
        {
            game = game;
            _player = player;

            this.position = position;

            if (Color == GameColor.White)
                direction = Direction.Up;
            else if (Color == GameColor.Black)
                direction = Direction.Down;
            
            // TODO: Get a pixel offset and send to image.
            _image = new Image(game, texture, position);

            _mouse = new MouseStateMachine(Mouse.GetState());
            
            game.OnUpdate += Update;
        }
        
        /**
         * Gets the fields this piece can move to.
         * @author Sebastian Davaris
         * @date 12-10-2020
         * @returns The possible moves.
         */
        protected abstract IEnumerable<Hover> GetPossibleFields();

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
            /*
            if(state.IsKeyDown(Keys.W))
                _image.SetPosition(new Vector2(_image.Position.X, _image.Position.Y - 1));
            if(state.IsKeyDown(Keys.S))
                _image.SetPosition(new Vector2(_image.Position.X, _image.Position.Y + 1));
            if(state.IsKeyDown(Keys.A))
                _image.SetPosition(new Vector2(_image.Position.X - 1, _image.Position.Y));
            if(state.IsKeyDown(Keys.D))
                _image.SetPosition(new Vector2(_image.Position.X + 1, _image.Position.Y));
            */
        }

        public bool IsEnemy(Piece other)
        {
            return this.Color != other.Color;
        }
        
        protected Vector2 OneFront(Vector2 @base)
        {
            switch (direction)
            {
                case Direction.Down:
                    return new Vector2(@base.X, @base.Y + 1);
                default:
                    return new Vector2(@base.X, @base.Y - 1);
            }
        }

        protected Vector2 OneLeft(Vector2 @base)
        {
            if (@base.X < 1)
                return @base;
            
            return new Vector2(@base.X - 1, @base.Y);
        }
        
        protected Vector2 OneRight(Vector2 @base)
        {
            if (@base.X >= 7)
                return @base;
            
            return new Vector2(@base.X + 1, @base.Y);
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