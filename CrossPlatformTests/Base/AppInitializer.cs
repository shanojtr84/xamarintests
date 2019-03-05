using System;
using System.IO;
using System.Linq;
using CrossPlatformTests.Config;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CrossPlatformTests.Base
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            // TODO: If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //

            //   #if ENABLE_TEST_CLOUD
            //   Xamarin.Calabash.Start();
            //   #endif

            AppConfigReader config = new AppConfigReader();

            string appBundle = config.GetAppPackage();

            if (platform == Platform.Android)
            {


                return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                    .InstalledApp(appBundle)
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .EnableLocalScreenshots()
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                //.AppBundle("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
                // .AppBundle("/Users/shanoj/Desktop/EAXamarinApp.ipa")
                //.DeviceIdentifier("4b07dfc8a642d8f9df1085139409668fde3244d5")
                // .DeviceIdentifier("6E7FF663-C3C4-447B-A314-ECBA34CDF0F3")
                .AppBundle("/Users/shanoj/Downloads/Xamarin.UITest-master/EAXamarinApp/EAXamarinApp.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone10.4-12.1/EAXamarinApp.iOS.app")
                //.AppBundle("/Users/shanoj/Downloads/Xamarin.UITest-master/EAXamarinApp/EAXamarinApp.iOS/bin/iPhone/Debug/device-builds/iphone10.2-12.1.4/EAXamarinApp.iOS.app")
                // .InstalledApp(appBundle)
                .StartApp();
        }
    }
}
