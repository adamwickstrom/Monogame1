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
        private Texture2D enemy;
        private Random enemyspawn = new Random();
        private Vector2 enemyPos = new Vector2();

        public Enemy(Texture2D enemy)
        {
            this.enemy = enemy;
            enemyPos.X = enemyspawn.Next(0, 800);

        }

        public void Update()
        {
            enemyPos.Y--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemy, new Rectangle((int)enemyPos.X, (int)enemyPos.Y, 30, 40), Color.White);
        }
    }

    
}
