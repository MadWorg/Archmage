//using Archmage.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using Archmage.Engine.Screens;
using Archmage.Engine.Interface;
using Microsoft.Xna.Framework.Audio;
using System.IO.IsolatedStorage;
using Archmage.SaveGame;
using Archmage.Engine.Particles;

namespace Archmage
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        // state
        //private GameState _gameState;

        // saving

        IsolatedStorageFile savegameStorage;


        // graphics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        // menu textures
        private Texture2D titleScreen;

        // interface
        private TouchCollection tc;

        // asset reading

        public enum GameState
        {
            Title,
            Menu,
            Playing,
            Paused
        }

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            tc = new TouchCollection();

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

            savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();

            // cant find a good XNA GameService tutorial, so global variable it is

            Globals.ScrWidth = GraphicsDevice.Viewport.Width;
            Globals.ScrHeight = GraphicsDevice.Viewport.Height;
            Globals.Content = Content;
            Globals.IM = new InputManager(tc);
            Globals.SM = new ScreenManager();

            Globals.scrCenter = new Vector2(Globals.ScrWidth / 2, Globals.ScrHeight / 2);
            Globals.sfx = Content.Load<SoundEffect>("audio/button");


            //TODO: learn how this works
            // reading a file -> load game
            Console.WriteLine("Loading save files!");

            if (savegameStorage.FileExists("ArchSave"))
            {
                Globals.SM.LoadSave(LoadGame());
            }



            base.Initialize();
        }


        // saves the game
        public void OnExit(string x)
        {
            Console.WriteLine("Saving!");
            SaveGame();
            Console.WriteLine("Exiting!");
            //Exit();
        }

        protected void SaveGame()
        {
            savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();

            Console.WriteLine("Saving data now.");

            string typedText = String.Format("{0}|{1}", 
                Globals.Player.ToString(), "gibberish"); // remove "gibberish" later

            Console.WriteLine(typedText);

            IsolatedStorageFileStream fs = null;

            fs = savegameStorage.OpenFile("ArchSave", System.IO.FileMode.Create);

            if (fs != null)
            {

                fs.WriteByte(0); // gameState goes here

                if ((typedText != null))
                {
                    fs.Write(System.Text.Encoding.UTF8.GetBytes(typedText), 0, typedText.Length);
                }
                Console.WriteLine("Saving successful.");
                fs.Close();

            }
            
        }

        protected Rebuilder LoadGame() // returns an object that remakes the player/enemy/level
        {

            string typedText = "";

            IsolatedStorageFileStream fs = null;
            try
            {
                fs = savegameStorage.OpenFile("ArchSave", System.IO.FileMode.Open);
            }
            catch (IsolatedStorageException e)
            {
                // The file couldn't be opened, even though it's there.
                // You can use this knowledge to display an error message
                // for the user (beyond the scope of this example).
                Console.WriteLine(e.StackTrace);

            }



            if (fs != null)
            {
                //reload last state of the game
                byte[] saveBytes = new byte[256];
                int count = fs.Read(saveBytes, 0, 256);
                if (count > 0)
                {
                    // bytes of info
                    if (count > 1)
                    {
                        typedText = System.Text.Encoding.UTF8.GetString(saveBytes, 1, count - 1);
                    }
                    Console.WriteLine("Successfully loaded save data.");
                    fs.Close();
                }

            }

            return new Rebuilder(typedText);
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            Globals.SM.LoadContent();


            titleScreen = Content.Load<Texture2D>("background/room");
            // TODO: use this.Content to load your game content here




        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

            Globals.SM.UnloadContent();

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if(!this.IsActive)
            {
                Console.WriteLine("Lost focus!");
            }

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            Globals.SM.Update(gameTime);


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

            // draw here

            Globals.SM.Draw(spriteBatch);

            //spriteBatch.Draw(titleScreen, new Rectangle(0, 0, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        



    }
}
