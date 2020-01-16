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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Archmage.Engine.Interface;
using Archmage.Engine.Screens;
using Microsoft.Xna.Framework;
using Archmage.Entity;
using Microsoft.Xna.Framework.Audio;

namespace Archmage
{
    public class Globals
    {

        public static int ScrWidth { get; set; }
        public static int ScrHeight { get; set; }
        public static ContentManager Content { get; set;}
        public static InputManager IM { get; set; }
        public static ScreenManager SM { get; set; }
        public static Vector2 scrCenter { get; set; }
        public static Player Player { get; set; }
        public static SoundEffect sfx { get; set; }

    }
}