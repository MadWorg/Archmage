using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Archmage.Engine.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Archmage.Engine.Screens
{
    class ColorPick : GameScreen
    {

        ContentManager Content;
        //public List<rclButton> buttons = new List<rclButton>(); //TODO: merge the lists 
        navButton back;

        List<BButton> buttons = new List<BButton>(); //TODO: merge the lists

        List<string> colors = new List<string>();

        SpriteFont font;

        public ColorPick()
        {
            Content = Globals.Content;
            colors.Add("red");
            colors.Add("green");
            colors.Add("purple");
            buttons.Add(new rclButton("red", 20, Globals.ScrHeight/2, 200f));
            buttons.Add(new rclButton("green", 240, Globals.ScrHeight/2, 200f));
            buttons.Add(new rclButton("purple", 460, Globals.ScrHeight/2, 200f));
            back = new navButton("leftArrow","","MainMenu",0,0,0.5f);

            buttons.Add(back);

        }

        public override void LoadContent()
        {
            bg = Content.Load<Texture2D>("background/paper");
            font = Content.Load<SpriteFont>("fonts/basic");
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {

            TP touch = Globals.IM.Input();

            foreach (BButton b in buttons)
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

            spriteBatch.Draw(bg, new Rectangle(0,0,Globals.ScrWidth,Globals.ScrHeight),Color.White);
            if(buttons.Count > 0)
            {
                foreach(BButton b in buttons)
                {
                    b.Draw(spriteBatch);
                }
            }
            back.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Select your robe color.", new Vector2(20,200), Color.Black);
            spriteBatch.DrawString(font, "Your current color is:", new Vector2(20,300), Color.Black);
            spriteBatch.DrawString(font, Globals.Player.Color.ToUpper(), new Vector2(510, 300), translate());
            

        }

        private Color translate()
        {
            var prop = typeof(Color).GetProperty(cap());
            if(prop != null)
            {
                return (Color)prop.GetValue(null, null);
            }
            return Color.Black;
        }

        private string cap()
        {
            char[] a = Globals.Player.Color.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

    }
}