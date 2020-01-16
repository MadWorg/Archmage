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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Archmage.Engine.Interface
{
    class navButton : BButton
    {

        string text; // button text
        string scr; // which screen to swap to
        float scale;
        Texture2D texture;
        SpriteFont font;

        public navButton(string file, string text, string scr, int x, int y, float scale)
        {
            this.file = file;
            this.text = text;
            this.scr = scr;          
            this.scale = scale;
            LoadContent();
            pos = new Rectangle(x, y, (int) (texture.Width*scale), (int)(texture.Height*scale));
        }

        public override void OnPress()
        {
            Globals.sfx.Play();
            Globals.SM.ChangeScreen(scr);
        }

        public override void LoadContent()
        {
            texture = Globals.Content.Load<Texture2D>("button/" + file);
            if (!text.Equals(""))
            {
                font = Globals.Content.Load<SpriteFont>("fonts/basic");
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, pos, Color.White);
            if (!text.Equals(""))
            {
                spriteBatch.DrawString(font, text, new Vector2(pos.X, pos.Y), Color.Gold);
            }
                
        }

    }
}