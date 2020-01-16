using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Archmage.Entity;
using Archmage.SaveGame;

namespace Archmage.Engine.Screens
{
    public class ScreenManager
    {

        static GameScreen curScreen, newScreen;
        ContentManager content;
        static bool swap;
        string next;
        Dictionary<string, GameScreen> screens = new Dictionary<string, GameScreen>();
        List<GameScreen> scrs = new List<GameScreen>();
        public static Game1 game;

        public ScreenManager()
        {

            content = Globals.Content;
            curScreen = new TitleScreen();
            swap = false;



            screens.Add("MainMenu", new MainMenu());
            screens.Add("LevelScreen", new LevelScreen());
            screens.Add("GameOver", new GameOver());
            screens.Add("ColorPick", new ColorPick());


        }

        public void LoadSave(Rebuilder data)
        {
            try
            {
                Globals.Player = data.BuildPlayer();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not load save data.\nError: ");
                Console.ResetColor();
                Console.WriteLine(e.StackTrace);
            }
        }

        public void ChangeScreen(string screen)
        {
            Console.WriteLine(screen);
            next = screen;
            Type t = Type.GetType("Archmage.Engine.Screens." + screen);

            if (!screens.ContainsKey(screen))
            {
                try
                {
                    newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Archmage.Engine.Screens." + screen)); // fix this
                    swap = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    Console.WriteLine("#########################################################");
                    Console.WriteLine("#########################################################");
                    Console.WriteLine("Oh no Mr. Frodo, they got a ballista!");
                    Console.WriteLine("#########################################################");
                    Console.WriteLine("#########################################################");
                }
            }
            swap = true;  

        }

        public void LoadContent()
        {
            curScreen.LoadContent();
        }

        public void UnloadContent()
        {
            curScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            curScreen.Update(gameTime);
            if (swap)
            {
                MediaPlayer.Stop();
                Transition();
                LoadContent();
            }

        }

        public void Transition()
        {
            Console.WriteLine("Transitioning to:    " + next);
            curScreen.UnloadContent();

            //GameScreen g = screens[next];

            curScreen = screens[next];

            if(next.Equals("LevelScreen") && Globals.Player.HP <= 0) // resets the player data if they died
            {
                string oldColor = Globals.Player.Color;
                Globals.Player = new Player
                {
                    Color = oldColor
                };
            }
            swap = false;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            curScreen.Draw(spriteBatch);
        }

    }
}