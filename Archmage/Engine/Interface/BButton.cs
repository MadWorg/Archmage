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

namespace Archmage.Engine.Interface
{
    public class BButton
    {

        public string file;
        public Rectangle pos;

        public BButton()
        {

        }

        public virtual void LoadContent()
        {

        }

        public virtual void UnloadContent()
        {

        }

        public virtual void OnPress()
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}