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
using Microsoft.Xna.Framework.Graphics;
using Archmage.Engine.Interface;
using Archmage.Entity;

namespace Archmage.Engine.Screens
{
    class MainMenu : GameScreen
    {

        public List<navButton> buttons = new List<navButton>();
        

        public MainMenu()
        {
            buttons.Add(new navButton("playButton", "", "LevelScreen",0,0,0.6f));
            buttons.Add(new navButton("bgButton", "Customize", "ColorPick", 50, 400, 0.6f));
            Globals.Player = new Player();
            //Console.WriteLine(Globals.IM.Input());
        }

        public override void LoadContent()
        {
            bg = Globals.Content.Load<Texture2D>("background/mainMenu");
            
            foreach(BButton b in buttons)
            {
                b.LoadContent();
            }
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {

            TP touch = Globals.IM.Input();

            foreach(navButton b in buttons)
            {
                if (b.pos.Contains(touch.pos) && touch.type.Equals("P"))
                {
                    b.OnPress();
                }

            }
            

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if(bg == null)
            {
                Console.WriteLine("Wat?!");
            }

            

            spriteBatch.Draw(bg, new Rectangle(0, 0, Globals.ScrWidth, Globals.ScrHeight), Color.White);

            foreach (BButton b in buttons)
            {
                b.Draw(spriteBatch);
                //spriteBatch.Draw(b.img, b.pos, Color.White);
            }
            base.Draw(spriteBatch);
        }
    }
}