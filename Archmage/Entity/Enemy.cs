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

namespace Archmage.Entity
{
    public class Enemy
    {

        public int HP;
        Texture2D img;
        public StatusEffect se; 


        public Enemy()
        {
            HP = 100;
            img = Globals.Content.Load<Texture2D>("enemy/darkOrc");
        }

        public Enemy(string hp, string image)
        {
            HP = Int32.Parse(hp);
            img = Globals.Content.Load<Texture2D>("enemy/" + image);
        }

        public void Attack()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(img, new Rectangle(), Color.White);
        }

    }
}