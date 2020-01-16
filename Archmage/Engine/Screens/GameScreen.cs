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
using Microsoft.Xna.Framework.Media;

namespace Archmage.Engine.Screens
{
    class GameScreen
    {

        public Type Type;
        public string file;
        public Song song;
        public Texture2D bg;

        public GameScreen()
        {
            Type = this.GetType();
            file = Type.ToString().Replace("Archmage.Engine.Screens.","");
        }

        public virtual void LoadContent()
        {

        }

        public virtual void UnloadContent()
        {
            
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        
        

    }
}