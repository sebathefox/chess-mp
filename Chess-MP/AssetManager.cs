using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP
{
    public sealed class AssetManager
    {
        private Game1 _game;
        private Dictionary<string, Texture2D> _textures;
        
        public AssetManager(Game1 game)
        {
            _game = game;
            _textures = new Dictionary<string, Texture2D>();
        }

        public void LoadTexture(string key, string path)
        {
            if (_textures.ContainsKey(key))
                _textures.Remove(key);
            _textures.Add(key, _game.Content.Load<Texture2D>(path));
        }

        public Texture2D GetTexture(string key)
        {
            return _textures[key];
        }
    }
}