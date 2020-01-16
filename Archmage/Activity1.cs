using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace Archmage
{

    [Activity(Label = "Archmage"
        , MainLauncher = true
        , Icon = "@drawable/archmage_icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout)]

    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {

        Game1 g;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            g = new Game1();
            SetContentView((View)g.Services.GetService(typeof(View)));
            g.Run();
        }

        protected override void OnStop()
        {
            System.Console.WriteLine("Bananabread test line");
            g.OnExit("Bananabread");
            System.Console.WriteLine("DONE SAVING GAME PROGRESS!");
            base.OnStop();
        }

    }
}

