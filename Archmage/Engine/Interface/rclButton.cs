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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Archmage.Engine.Interface
{
    class rclButton : BButton // robe color select button
    {

        Texture2D texture;
        private ContentManager Content = Globals.Content;

        public rclButton(string file, int x, int y, float scale)
        {
            this.file = file;
            LoadContent();
            this.pos = new Rectangle(x, y, (int) (texture.Width * scale), (int) (texture.Height * scale));
            
        }

        public override void OnPress()
        {
            Globals.sfx.Play();
            Globals.Player.Color = file;
            Console.WriteLine("Change to color: " + file);
            Console.WriteLine(Globals.Player.Color);
        }

        public override void LoadContent()
        {
            texture = Globals.Content.Load<Texture2D>("hud/colSelect/" + file);
        }

        public override void UnloadContent()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }

        
    }
}