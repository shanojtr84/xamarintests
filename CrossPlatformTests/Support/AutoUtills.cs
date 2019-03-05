using System;
using System.IO;
using Xamarin.UITest;

namespace CrossPlatformTests.Support
{
    public class AutoUtills
    {
        public string TakeScreenShot(string testName,IApp app,Platform platform){
            var screen = app.Screenshot("Welcome Screen");
            int fileNamelength = screen.Name.Length;
            var fileName = screen.Name.Substring(fileNamelength - 1);
            string screenshotName = fileName.Replace("g", platform.ToString() + "_"+testName + "_" + string.Format("{0:dd-MM-yyyy_HH-mm-ss}", DateTime.Now) + ".png");
            var screenShotPath = Path.Combine(GetProjectPath() + "ScreenShots", screenshotName);

            if (File.Exists(screenShotPath))
            {
                File.Delete(screenShotPath);
            }
            screen.MoveTo(screenShotPath);

            return screenShotPath;
        }

        public string GetProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin", StringComparison.Ordinal));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;

        }
    }
}
