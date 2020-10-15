using System;
using System.Collections.Generic;
using Chess_MP.Board;
using Chess_MP.States;
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
        protected GameController GameController;
        // private readonly Player _player;
        private Image _image;
        private MouseStateMachine _mouse;
        protected Vector2 position;
        protected Direction direction;
        protected List<Hover> hovers;
        private GameColor _color;

        private bool _shouldUpdate;

        
        /**
         * Constructor
         * @param game The Game reference.
         * @param player The reference to this piece's owner.
         * @param texture The texture of this Piece.
         * @param position The position of this Piece in normalized coordinates.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        protected Piece(GameController gameController, GameColor color, Texture2D texture, Vector2 position)
        {
            this.GameController = gameController;



            _color = color;
            
            this.position = position;

            if (color == GameColor.White)
                direction = Direction.Up;
            else if (color == GameColor.Black)
                direction = Direction.Down;
            
            _image = new Image(gameController.Game, texture, new Vector2(position.X * 64, position.Y * 64));

            _mouse = new MouseStateMachine(Mouse.GetState());

            _shouldUpdate = true;
            
            gameController.Game.OnUpdate += Update;
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
            if (!_shouldUpdate)
            {
                return;
            }
            
            // Updates the state.
            _mouse.Update(Mouse.GetState());

            if (_mouse.LeftClicked())
            {
                Point pos = _mouse.GetPosition();

                if (_image.Rectangle.Contains(pos))
                {
                    hovers = new List<Hover>(GetPossibleFields());
                    foreach (Hover hover in hovers)
                    {
                        hover.OnClicked += OnHoverClicked;
                    }
                }
            }
            
            // Resets the state.
            _mouse.Swap();
        }

        /**
         * Validates if the other piece is a enemy.
         * @param other The other Piece.
         * @author Sebastian Davaris
         * @date 15-10-2020
         */
        // public bool IsEnemy(Piece other)
        // {
        //     if (other == null)
        //         return false;
        //     
        //     // return Color != other.Color;
        // }
        //
        // protected Vector2 OneFront(Vector2 @base)
        // {
        //     switch (direction)
        //     {
        //         case Direction.Down:
        //             return new Vector2(@base.X, @base.Y + 1);
        //         default:
        //             return new Vector2(@base.X, @base.Y - 1);
        //     }
        // }
        //
        // protected Vector2 OneLeft(Vector2 @base)
        // {
        //     if (@base.X < 1)
        //         return @base;
        //     
        //     return new Vector2(@base.X - 1, @base.Y);
        // }
        //
        // protected Vector2 OneRight(Vector2 @base)
        // {
        //     if (@base.X >= 7)
        //         return @base;
        //     
        //     return new Vector2(@base.X + 1, @base.Y);
        // }
        //
        // protected Vector2 OneUp(Vector2 @base)
        // {
        //     if (@base.Y < 1)
        //         return @base;
        //
        //     return new Vector2(@base.X, @base.Y - 1);
        // }
        //
        // protected Vector2 OneDown(Vector2 @base)
        // {
        //     if (@base.Y >= 7)
        //         return @base;
        //
        //     return new Vector2(@base.X, @base.Y + 1);
        // }
        //
        // protected Vector2 OneUpLeft(Vector2 @base)
        // {
        //     if (@base.Y < 1 || @base.X < 1)
        //         return @base;
        //
        //     return new Vector2(@base.X - 1, @base.Y - 1);
        // }
        //
        // protected Vector2 OneUpRight(Vector2 @base)
        // {
        //     if (@base.Y < 1 || @base.X >= 7)
        //         return @base;
        //
        //     return new Vector2(@base.X + 1, @base.Y - 1);
        // }
        //
        // protected Vector2 OneDownLeft(Vector2 @base)
        // {
        //     if (@base.Y >= 7 || @base.X < 1)
        //         return @base;
        //
        //     return new Vector2(@base.X - 1, @base.Y + 1);
        // }
        //
        // protected Vector2 OneDownRight(Vector2 @base)
        // {
        //     if (@base.Y >= 7 || @base.X >= 7)
        //         return @base;
        //
        //     return new Vector2(@base.X + 1, @base.Y + 1);
        // }
        //
        // protected bool IsOnLeft()
        // {
        //     return position.X <= 0;
        // }
        //
        // protected bool IsOnRight()
        // {
        //     return position.X >= 7;
        // }
        //
        // protected bool IsOnTop()
        // {
        //     return position.Y <= 0;
        // }
        //
        // protected bool IsOnBottom()
        // {
        //     return position.Y >= 7;
        // }
        
        protected virtual void OnHoverClicked(object sender, Vector2 pos)
        {
            if (!GameController.IsInState<InGameState>())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }

            InGameState state = GameController.State as InGameState;

            Piece other = state.PieceManager.GetPieceOnPosition(pos);

            if (other != null)
            {
                state.PieceManager.KillPiece(other);
            }

            state.PieceManager.MovePiece(this, pos);
            
            // state[this.position].SetPiece(null);
            
            this.position = pos;
            
            _image.SetPosition(new Vector2(pos.X * 64, pos.Y * 64));

            foreach (Hover hover in hovers)
            {
                hover.OnClicked -= OnHoverClicked;
                hover.Disable();
            }
            this.hovers.Clear();

            // state[pos].SetPiece(this);
        }
        
        public int Id { get; protected set; }

        /**
         * Returns the piece's colour
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        public GameColor Color => _color;
        
        public Vector2 Position => position;
    }
}