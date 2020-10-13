using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Chess_MP
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AssetManager _assetManager;

        private Image _board;

        private Player _player;
        private Hover _hover;

        private List<Field> _fields;
        
        public event EventHandler<SpriteBatch> OnDraw;

        public event EventHandler<GameTime> OnUpdate; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _assetManager = new AssetManager(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Misc
            _assetManager.LoadTexture("board", "board");
            _assetManager.LoadTexture("hover", "hover_field");
            
            // White
            _assetManager.LoadTexture("white-pawn", "white_pawn");
            _assetManager.LoadTexture("white-knight", "white_knight");
            _assetManager.LoadTexture("white-rook", "white_castle");
            _assetManager.LoadTexture("white-bishop", "white_bishop");
            _assetManager.LoadTexture("white-king", "white_king");
            _assetManager.LoadTexture("white-queen", "white_queen");

            // Black
            _assetManager.LoadTexture("black-pawn", "black_pawn");
            _assetManager.LoadTexture("black-knight", "black_knight");
            _assetManager.LoadTexture("black-rook", "black_castle");
            _assetManager.LoadTexture("black-bishop", "black_bishop");
            _assetManager.LoadTexture("black-king", "black_king");
            _assetManager.LoadTexture("black-queen", "black_queen");

            _player = new Player(this, 1, "Sebastian", GameColor.White);
            
            _hover = new Hover(this, new Vector2(2, 3));
            
            _board = new Image(this, _assetManager.GetTexture("board"), Vector2.Zero);
            
            _fields = new List<Field>();

            for (int xIndex = 0; xIndex < 8; xIndex++)
            {
                for (int y = 0; y < 8; y++)
                {
                    _fields.Add(new Field(this, new Vector2(xIndex, y)));
                }
            }
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            OnUpdate?.Invoke(this, gameTime);

            KeyboardState state = Keyboard.GetState();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_assetManager.GetTexture("board"), Vector2.One, Color.White);
            
            _spriteBatch.End();
            
            OnDraw?.Invoke(this, _spriteBatch);

            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        /**
         * Gets the AssetManager.
         * @returns The AssetManager.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public AssetManager AssetManager => _assetManager;

        /**
         * Gets the field in the specific position.
         * @returns The specified Piece.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public Field this[Vector2 position] => _fields.First(field => field.Id == position);
        
        /**
         * Returns the list of Fields as readonly.
         * @returns The Fields.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public List<Field> Fields => _fields;
    }
}