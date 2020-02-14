﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Vector2> xwingBulletPos = new List<Vector2>();
        List<Enemy> enemyList = new List<Enemy>();
        xwing Xwing;
        Texture2D XwingText;
        KeyboardState KNewState;
        KeyboardState k0ldState;
                    

        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            XwingText = Content.Load<Texture2D>("xwing");
            Xwing = new xwing(XwingText);

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //  Exit();
            if (KNewState.IsKeyDown(Keys.Escape))
                Exit();
            KNewState = Keyboard.GetState();
            // TODO: Add your update logic here


            Xwing.Update();

            /*if (KNewState.IsKeyDown(Keys.Right))
                if (xwingPos.X < 700)
                    xwingPos.X += 10;
            if (KNewState.IsKeyDown(Keys.Left))
                if(xwingPos.X > 0)
                    xwingPos.X -= 10;
                    */

            if (KNewState.IsKeyDown(Keys.Space) && k0ldState.IsKeyUp(Keys.Space))
            {
                xwingBulletPos.Add(xwingPos + new Vector2(2,27));
                xwingBulletPos.Add(xwingPos + new Vector2(xwing.Width - 11, 27));
            }

            for(int i = 0; i < xwingBulletPos.Count; i++)
            {
                xwingBulletPos[i] = xwingBulletPos[i] - new Vector2(0,5);
            }

            //for (int i = 0; i < enemyList.Count; i++)
         //   {
           //     enemyList[i] = enemyList[i] - new Enemy(0, 10);
            //}

            k0ldState = KNewState;

            base.Update(gameTime);



        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Xwing.Draw(spriteBatch);

            foreach (Vector2 bulletPos in xwingBulletPos)
            {
                Rectangle rec = new Rectangle();
                rec.Location = bulletPos.ToPoint();
                rec.Size = new Point(10, 10);


                spriteBatch.Draw(xwing, rec, Color.Red);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here.

            base.Draw(gameTime);
        }
    }
}
