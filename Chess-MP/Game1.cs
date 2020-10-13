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

        private Image _image;

        public event EventHandler<SpriteBatch> OnDraw; 

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
            
            _assetManager.LoadTexture("board", "board");
            _assetManager.LoadTexture("white-queen", "white_queen");

            _image = new Image(this, _assetManager.GetTexture("white-queen"), Vector2.One);
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
            
            if(state.IsKeyDown(Keys.W))
                _image.SetPosition(new Vector2(_image.Position.X, _image.Position.Y - 1));
            if(state.IsKeyDown(Keys.S))
                _image.SetPosition(new Vector2(_image.Position.X, _image.Position.Y + 1));
            if(state.IsKeyDown(Keys.A))
                _image.SetPosition(new Vector2(_image.Position.X - 1, _image.Position.Y));
            if(state.IsKeyDown(Keys.D))
                _image.SetPosition(new Vector2(_image.Position.X + 1, _image.Position.Y));
            
            
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
    }
}