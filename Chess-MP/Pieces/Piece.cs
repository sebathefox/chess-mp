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

            hovers = new List<Hover>();

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
                if (hovers.Count > 0)
                {
                    foreach (Hover hover in hovers)
                    {
                        hover.OnClicked -= OnHoverClicked;
                        hover.Disable();
                    }
                    this.hovers.Clear();
                }
                
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
                else
                {
                    if (hovers.Count > 0)
                    {
                        bool anyClicked = true;
                        
                        foreach (Hover hover in hovers)
                        {
                            if (!hover.Rect.Contains(pos))
                            {
                                hover.OnClicked -= OnHoverClicked;
                                hover.Disable();
                            }
                            else
                            {
                                anyClicked = false;
                            }
                        }
                        
                        if(!anyClicked)
                            hovers.Clear();
                    }
                }
            }
            
            // Resets the state.
            _mouse.Swap();
        }

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
            position = pos;
            
            _image.SetPosition(new Vector2(pos.X * 64, pos.Y * 64));

            Hover obj = sender as Hover;
            
            // Removes this hover.
            obj.Disable();
            
            // Removes all hovers / Resets the state.
            ClearHovers();
        }

        public void Disable()
        {
            _shouldUpdate = false;
            _image.Disable();
        }

        public void ClearHovers()
        {
            foreach (Hover hover in hovers)
            {
                hover.OnClicked -= OnHoverClicked;
                hover.Disable();
            }
            this.hovers.Clear();
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