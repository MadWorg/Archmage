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

namespace Archmage.Items
{
    public class Item
    {
        string name;

        public Item()
        {
            name = "testItem";
        }

        public Item(string name)
        {
            this.name = name;
        }
    }
}