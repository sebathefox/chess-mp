using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.Board;
using Chess_MP.Pieces;
using Chess_MP.States;
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

        private GameController _gameController;
        
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
            _assetManager.LoadTexture("button", "button");
            _assetManager.LoadTexture("icon", "Icon");

            Font = Content.Load<SpriteFont>("font");
            
            _gameController = new GameController(this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            OnUpdate?.Invoke(this, gameTime);

            KeyboardState state = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_assetManager.GetTexture("board"), Vector2.One, Color.White);
            
            _spriteBatch.End();
            
            OnDraw?.Invoke(this, _spriteBatch);

            Window.AllowUserResizing = true;

            base.Draw(gameTime);
        }

        /**
         * Gets the AssetManager.
         * @returns The AssetManager.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public AssetManager AssetManager => _assetManager;

        public SpriteFont Font { get; set; }
    }
}