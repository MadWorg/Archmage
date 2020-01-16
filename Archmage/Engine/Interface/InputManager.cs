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
using Microsoft.Xna.Framework.Input.Touch;


namespace Archmage.Engine.Interface
{
    public class InputManager
    {

        protected TouchCollection tc;
        protected TouchCollection ti;

        public InputManager(TouchCollection tc)
        {
            this.tc = tc;
        }

        
        public TP Input()
        {

            ti = TouchPanel.GetState();

            foreach (TouchLocation tl in ti)
            {
                if (tl.State == TouchLocationState.Pressed)
                {                   
                    return new TP("P", tl.Position); // pressed
                }
                else if (tl.State == TouchLocationState.Moved)
                {
                    return new TP("M", tl.Position); // moved
                }
                else if (tl.State == TouchLocationState.Released)
                {
                    return new TP("R", tl.Position); // released
                }

            }

            return new TP("F", new Vector2(-1,-1)); // invalid input
        }
        
        // old input management

        /*
        public string checkInput()  
        {
            //tc = TouchPanel.GetState();
            ti = TouchPanel.GetState();

            foreach (TouchLocation tl in ti)
            {
                if(tl.State == TouchLocationState.Pressed)
                {
                    return "P"; // pressed
                }
                else if(tl.State == TouchLocationState.Moved)
                {
                    return "M"; // moved
                }
                else if(tl.State == TouchLocationState.Released)
                {
                    return "R"; // released
                }
                
            }

            return "None";
        }

        public Vector2 locInput()
        {
            //tc = TouchPanel.GetState();

            // call if you need input location

            ti = TouchPanel.GetState();

            foreach (TouchLocation tl in ti)
            {
                if (tl.State == TouchLocationState.Pressed)
                {
                    return tl.Position;
                }
            }

            return new Vector2(-1, -1);

        }
        */

    }
}