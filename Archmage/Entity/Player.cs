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
using Archmage.Items;

namespace Archmage.Entity
{
    public class Player
    {
        public string Color;
        public int HP;
        public int Mana;
        public List<Item> items = new List<Item>(); // maybe turn this to array, since inventory is limited
        public List<StatusEffect> se = new List<StatusEffect>();

        public Player()
        {
            Color = "red";
            HP = 100;
            Mana = 2;
        }

        public Player(string color, string hp, string mana)
        {
            Color = color;
            HP = int.Parse(hp);
            Mana = int.Parse(mana);
        }

        public override string ToString() // prepare player info for saving
        {
            return String.Format("{0};{1};{2}",Color,HP,Mana);
        }
    }
}