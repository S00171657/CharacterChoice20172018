﻿using Engine.Engines;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace TexturesExercise
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Dictionary<string, Sprite> Badges = new Dictionary<string, Sprite>();
        Dictionary<string, SoundEffect> sfx = new Dictionary<string, SoundEffect>();
        bool CharactersOnScreen = true;

        Player player;

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
            IsMouseVisible = true;
            new InputEngine(this);
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
            // Craete start point
            Point startPoint = new Point(10, 100);
            // create and load first texture
            Texture2D tx = Content.Load<Texture2D>(@"Badges\Badges_0");
            // Add first Character
            Badges.Add("Badges_0", 
                new Sprite(tx,new Rectangle(startPoint,new Point(tx.Width,tx.Height)))
                );
            Badges["Badges_0"].CharacterName = "Badges_0";

            // Move Rectangle position along
            startPoint.X += tx.Width + 10;
            // Add Badges_1
            tx = Content.Load<Texture2D>(@"Badges\Badges_1");
            Badges.Add("Badges_1",
                new Sprite(tx,new Rectangle(startPoint, new Point(tx.Width, tx.Height)))
                );
            Badges["Badges_1"].CharacterName = "Badges_1";

            // Move Rectangle position along
            startPoint.X += tx.Width + 10;
            // Add Badges_2
            tx = Content.Load<Texture2D>(@"Badges\Badges_2");
            Badges.Add("Badges_2",
                new Sprite(tx, new Rectangle(startPoint, new Point(tx.Width, tx.Height)))
                );
            Badges["Badges_2"].CharacterName = "Badges_2";

            // Move Rectangle position along
            startPoint.X += tx.Width + 10;
            // Add Badges_3
            tx = Content.Load<Texture2D>(@"Badges\Badges_3");
            Badges.Add("Badges_3",
                new Sprite(tx, new Rectangle(startPoint, new Point(tx.Width, tx.Height)))
                );
            Badges["Badges_3"].CharacterName = "Badges_3";

            // Move Rectangle position along
            startPoint.X += tx.Width + 10;
            // Add Badges_4
            tx = Content.Load<Texture2D>(@"Badges\Badges_4");
            Badges.Add("Badges_4",
                new Sprite(tx, new Rectangle(startPoint, new Point(tx.Width, tx.Height)))
                );
            Badges["Badges_4"].CharacterName = "Badges_4";


            // Setup Player and give him a default character
            player = new Player(Badges["Badges_0"].Tx,new Rectangle(10, 10,tx.Width, tx.Height));
            player.CharacterName = "Badges_0";
            

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update the player for movement
            //player.Update();
            // TODO: Add your update logic here
            if(InputEngine.IsKeyPressed(Keys.C))
            {
                CharactersOnScreen = !CharactersOnScreen;
            }

            if (CharactersOnScreen)
            {
                // Update to catch the mouse click
                foreach (var entry in Badges)
                {
                    entry.Value.Update();
                }
                // Find if one was clicked
                Sprite found = null;
                foreach (var item in Badges)
                {
                    // Found one
                    if (item.Value.Selected)
                    {
                        found = item.Value;
                        break;
                    }
                }
                // if found reset for next time and set player image
                if (found != null)
                {
                    found.Selected = false;
                    player.Tx = found.Tx;
                }
            }
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
            if(CharactersOnScreen)
                foreach (var entry in Badges)
                {
                    entry.Value.Draw(spriteBatch);
                }
            player.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
