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

namespace Archmage.Engine.Interface
{
    public class TP
    {

        public string type;
        public Vector2 pos;

        public TP(string type, Vector2 pos)
        {
            this.type = type;
            this.pos = pos;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", type, pos);
        }

    }
}