using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP
{
    class Button
    {
        int buttonX, buttonY;

        public int ButtonX
        {
            get
            {
                return buttonX;
            }
        }

        public int ButtonY
        {
            get
            {
                return buttonY;
            }
        }

        public Button(string name, Texture2D texture, int buttonX, int buttonY)
        {
            //this.Name = name;
            //this.Texture = texture;
            this.buttonX = buttonX;
            this.buttonY = buttonY;
        }
    }
}
