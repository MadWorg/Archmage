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
using Archmage.Entity;

namespace Archmage.SaveGame
{
    public class Rebuilder
    {

        Player player;
        Enemy enemy;
        string[] AllData;

        public Rebuilder(string data)
        {
            // 0 - player | 1 - enemy | 2 - level

            AllData = data.Split("|");

        }

        public Player BuildPlayer()
        {
            string[] pd = AllData[0].Split(";"); // parses player data

            // 0 color | 1 hp | 2 mana

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Rebuilt player!");
            Console.ResetColor();

            return new Player(pd[0], pd[1], pd[2]);
        }

        public Enemy BuildEnemy()
        {
            string[] ed = AllData[1].Split(";");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Rebuilt enemy!");
            Console.ResetColor();

            return new Enemy();
        }

        public void BuildLevel() // TODO: make this do anything
        {

        }
    }
}