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
using Archmage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Archmage.Engine.Screens
{
    class GameOver : GameScreen
    {

        ContentManager Content;
        //Texture2D bg;

        public GameOver()
        {
            this.Content = Globals.Content;
        }

        public override void LoadContent()
        {
            bg = Content.Load<Texture2D>("background/gameOver");

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Rectangle(0, 0, Globals.ScrWidth, Globals.ScrHeight), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            if (Globals.IM.Input().type.Equals("P"))
            {
                Globals.SM.ChangeScreen("MainMenu");
            }
            base.Update(gameTime);
        }

    }
}