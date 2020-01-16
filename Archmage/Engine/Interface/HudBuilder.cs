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

namespace Archmage.Engine.Interface
{
    class HudBuilder
    {

        public HudBuilder()
        {

        }

        public void buildUI(string conf)
        {

            List<Button> buttons = new List<Button>();

            try
            {
                string line;

                System.IO.StreamReader file = new System.IO.StreamReader(conf);

                while((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    //build interface
                    // make new class for interface parts, make button inherit from it
                }

                file.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        public void Draw()
        {

        }


    }
}