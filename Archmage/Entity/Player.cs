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
        public List<Item> items = new List<Item>();
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
            HP = Int32.Parse(hp);
            Mana = Int32.Parse(mana);
        }

        public override string ToString()
        {
            return String.Format("{0};{1};{2}",Color,HP,Mana);
        }
    }
}