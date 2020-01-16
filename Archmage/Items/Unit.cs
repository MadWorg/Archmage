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
    class Unit
    {

        string name;
        bool drawn;
        int atk;
        int health;
        
        public Unit()
        {
            name = "enemy/plcUnit";
            drawn = true;
            health = 100;
            atk = 10;
        }

        public Unit(String [] data)
        {
            
            this.health = Int32.Parse(data[0]);
            this.atk = Int32.Parse(data[1]);
            this.name = data[2];
            drawn = true;
        }

        public string GetName()
        {
            return name;
        }

        public bool GetDrawn()
        {
            return drawn;
        }

        public void SetDrawn()
        {
            drawn = !drawn;
        }
    }
}