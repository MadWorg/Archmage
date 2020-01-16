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
using Archmage.Engine.Interface;
using Archmage.Entity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Archmage.Engine.Screens
{
    class LevelScreen : GameScreen 
    {

        Texture2D hp, left, right, back;
        BButton exit;
        SpriteFont f;
        Random rnd = new Random();

        Texture2D test;

        public LevelScreen()
        {

        }

        public void Reload(string color)
        {
            string oldColor = Globals.Player.Color;
            Globals.Player = new Player
            {
                Color = oldColor
            };
        }

        public override void LoadContent()
        {

            test = Globals.Content.Load<Texture2D>("test");

            bg = Globals.Content.Load<Texture2D>("background/room");
            song = Globals.Content.Load<Song>("audio/plc_dng");
            hp = Globals.Content.Load<Texture2D>("hud/health");
            left = Globals.Content.Load<Texture2D>("hud/hand" + Globals.Player.Color);
            right = Globals.Content.Load<Texture2D>("hud/handR" + Globals.Player.Color);
            back = Globals.Content.Load<Texture2D>("button/exit");

            f = Globals.Content.Load<SpriteFont>("fonts/basic");

            exit = new navButton("exit", "", "MainMenu", 0, 0, 0.3f);

            //exit.LoadContent();

            PlayMusic();
        }

        private void PlayMusic()
        {
            MediaPlayer.Volume = 1.0f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
        }

        public override void Update(GameTime gameTime)
        {

            TP touch = Globals.IM.Input();

            if(exit.pos.Contains(touch.pos) && touch.type.Equals("P"))
            {
                Globals.SM.ChangeScreen("MainMenu");
            }
            else if (touch.type.Equals("P"))
            {
                Globals.Player.HP -= rnd.Next(10, 25);
            }


            if(Globals.Player.HP <= 0)
            {
                Globals.SM.ChangeScreen("GameOver");
                Reload(Globals.Player.Color);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Rectangle(0, 0, Globals.ScrWidth, Globals.ScrHeight), Color.White);
            spriteBatch.Draw(left, new Rectangle(0, Globals.ScrHeight - left.Height/3, left.Width/3, left.Height/3), Color.White);
            spriteBatch.Draw(right, new Rectangle(Globals.ScrWidth - right.Width/3, Globals.ScrHeight - right.Height/3, right.Width/3, right.Height/3), Color.White);
            spriteBatch.Draw(hp, new Rectangle(Globals.ScrWidth - hp.Width, 0, hp.Width, hp.Height), Color.White);

            exit.Draw(spriteBatch);

            spriteBatch.DrawString(f, Globals.Player.HP.ToString(), new Vector2(Globals.ScrWidth - hp.Width + 40, 0 + hp.Height/3), Color.Red);

            spriteBatch.Draw(test, new Rectangle((int)Globals.scrCenter.X - test.Width / 2, (int)Globals.scrCenter.Y - test.Height / 2, test.Height, test.Width), Color.White);
        }

    }
}