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
    class Enemy
    {
        private Texture2D texture;
        private Random random = new Random();
        private Vector2 pos = new Vector2();


        public Enemy(Texture2D enemy)
        {
            this.texture = enemy;
            pos.X = random.Next(0, 800);

        }

        public void Update()
        {
            pos.Y++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, 30, 40), Color.White);

        }


    }

    
}
