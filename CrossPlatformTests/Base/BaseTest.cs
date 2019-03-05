using System;
using NUnit.Framework;
using Xamarin.UITest;
using CrossPlatformTests.Config;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System.IO;
using AventStack.ExtentReports.Reporter.Configuration;
using CrossPlatformTests.Support;

namespace CrossPlatformTests.Base
{
   // [TestFixture(Platform.Android)]
      [TestFixture(Platform.iOS)]
    public abstract class BaseTest
    {

        public IApp app;
        public Platform platform;
        public static ExtentReports ReportManager;
        public static ExtentTest extentTest;
        AutoUtills utills = new AutoUtills();

        protected BaseTest(Platform platform)
        {
            this.platform = platform;

        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            GetExtentReportInstance();
            extentTest = ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
            app = AppInitializer.StartApp(platform);
        }


        [TearDown]
        public void AfterTest()
        {   
            var status = TestContext.CurrentContext.Result.Status;
            string testName = TestContext.CurrentContext.Test.Name;
            LogExtentTestStatusToReport(status, testName);
            SaveExtentReport();
        }

       public ExtentReports GetExtentReportInstance(){

            if (ReportManager == null){
                string Platform = platform.ToString();
                //To create report directory and add HTML report into it
                string HtmlReportFullPath = utills.GetProjectPath() + "Reports/" + platform.ToString() + "_Test_Report.html";

                ReportManager = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
                htmlReporter.Configuration().DocumentTitle = platform.ToString() + " Automation Report";
                htmlReporter.Configuration().Encoding = "UTF-8";
                htmlReporter.Configuration().Theme = Theme.Dark;
                ReportManager.AddSystemInfo("Environment", "QA");
                ReportManager.AddSystemInfo("Tester", "Shanoj");
                ReportManager.AddSystemInfo("Team", "SDL");
                ReportManager.AddSystemInfo("Platform", platform.ToString());
                ReportManager.AttachReporter(htmlReporter);
            }
            return ReportManager;

        }

      public void SaveExtentReport(){

            ReportManager.Flush();
        }

       public void LogExtentTestStatusToReport(TestStatus status,string testName)
        {
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    extentTest.Log(logstatus, "Test " + logstatus + "ed");
                    string screenShotPath = utills.TakeScreenShot(testName,app, platform);
                    extentTest.Log(logstatus, "Refer to below Snapshot: " + AttachScreenShotToReport(screenShotPath));
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    extentTest.Log(logstatus, "Test " + logstatus + "ed");
                    break;
                default:
                    logstatus = Status.Pass;
                    extentTest.Log(logstatus, "Test " + logstatus + "ed");
                    break;
            }

        }


       public ExtentTest AttachScreenShotToReport(string screenShotPath)
        {
            return extentTest.AddScreenCaptureFromPath(new Uri(screenShotPath).LocalPath);
            
        }
    }

}