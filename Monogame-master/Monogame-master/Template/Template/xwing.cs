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
        private List<Vector2> xwingBulletPos = new List<Vector2>();

        public xwing(Texture2D xwing)
        {
            this.xwingTex = xwing;
            this.xwingPos = new Vector2(100, 350);
        }

        public void Update()
        {
            KNewState = Keyboard.GetState();

            if (KNewState.IsKeyDown(Keys.Right))
                if (xwingPos.X < 700)
                    xwingPos.X += 10;
            if (KNewState.IsKeyDown(Keys.Left))
                if (xwingPos.X > 0)
                    xwingPos.X -= 10;

            if (KNewState.IsKeyDown(Keys.Space) && k0ldState.IsKeyUp(Keys.Space))
            {
                xwingBulletPos.Add(xwingPos + new Vector2(2, 27));
                xwingBulletPos.Add(xwingPos + new Vector2(xwingTex.Width - 11, 27));
            }

            for (int i = 0; i < xwingBulletPos.Count; i++)
            {
                xwingBulletPos[i] = xwingBulletPos[i] - new Vector2(0, 5);
            }

            k0ldState = KNewState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(xwingTex, xwingPos, Color.White);

            foreach (Vector2 bulletPos in xwingBulletPos)
            {
                Rectangle rec = new Rectangle();
                rec.Location = bulletPos.ToPoint();
                rec.Size = new Point(10, 10);


                spriteBatch.Draw(xwingTex, rec, Color.Red);
            }
        }
    }
}
