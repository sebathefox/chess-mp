using System;
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

        private Board.Board _board;

        private Player _player;
        private Hover _hover;
        
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
            
            _board = new Board.Board(this, _assetManager.GetTexture("board"));
            
            _player = new Player(this, 1, "Sebastian", GameColor.White);
            
            _hover = new Hover(this, new Vector2(2, 3));
            
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

        public AssetManager AssetManager => _assetManager;
    }
}