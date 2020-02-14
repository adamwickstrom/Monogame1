using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Template
{
    class xwing
    {

        private Texture2D xwingTex;
        private Vector2 xwingPos;
        private KeyboardState KNewState;
        private KeyboardState k0ldState;

        public xwing(Texture2D xwing)
        {
            this.xwingTex = xwing;
            this.xwingPos = new Vector2(100, 350);
        }

        public void Update()
        {
            if (KNewState.IsKeyDown(Keys.Right))
                if (xwingPos.X < 700)
                    xwingPos.X += 10;
            if (KNewState.IsKeyDown(Keys.Left))
                if (xwingPos.X > 0)
                    xwingPos.X -= 10;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(xwingTex, xwingPos, Color.White);
        }
    }
}
