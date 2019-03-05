using System;
using System.Configuration;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using CrossPlatformTests.Screens;
using CrossPlatformTests.Base;
using AventStack.ExtentReports;

namespace CrossPlatformTests.Tests
{



    public class Test1 :BaseTest
    {
        public Test1(Platform platform)
            : base(platform)
        {
            platform = Platform.Android;
        }

        [Test]
        public void newTest()
        {
            string title = "TestTitle";
            string desc = "Test Desc";
            extentTest.Log(Status.Info, "Click on Add item button");
            // app.Repl();
            HomeScreen homeScreen = new HomeScreen(app,platform);
            AddItemScreen addItemScreen = homeScreen.clickAdd();
            extentTest.Log(Status.Info, "Add title, description and save");
            homeScreen = addItemScreen.addItem(title, desc);
            extentTest.Log(Status.Info, "Verify item added");
            Assert.IsTrue(homeScreen.isItemAdded(title), "element not found");

        }

        [Test]
        public void newTest2()
        {
           
            // app.Repl();
            HomeScreen homeScreen = new HomeScreen(app, platform);
            extentTest.Log(Status.Info, "Click on Add item button");
            AddItemScreen addItemScreen = homeScreen.clickAdd();

        }

        [Test]
        public void newTest3()
        {

            // app.Repl();
            HomeScreen homeScreen = new HomeScreen(app, platform);
            extentTest.Log(Status.Info, "Click on Add item button");
            AddItemScreen addItemScreen = homeScreen.clickAdd();
            extentTest.Log(Status.Info, "Verify add item screen displayed");
            Assert.IsTrue(homeScreen.isItemAdded("title"), "element not found");

        }
    }
}
