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
using CrossPlatformTests.Support;

namespace CrossPlatformTests.Tests
{
    public class Test2:BaseTest
    {
        public Test2(Platform platform)
            : base(platform)
        {
            platform = Platform.Android;
        }


        [Test]
        public void Test11()
        {
            string title = "TestTitle";
            string desc = "Test Desc";
            extentTest.Log(Status.Info, "Click on Add item button");
            // app.Repl();
            HomeScreen homeScreen = new HomeScreen(app, platform);
            AddItemScreen addItemScreen = homeScreen.clickAdd();
            extentTest.Log(Status.Info, "Add title, description and save");
            homeScreen = addItemScreen.addItem(title, desc);
            extentTest.Log(Status.Info, "Verify item added");
            Assert.IsFalse(homeScreen.isItemAdded(title), "element not found");

        }

        [Test]
        public void Test12()
        {
         
            // app.Repl();
            HomeScreen homeScreen = new HomeScreen(app, platform);
            extentTest.Log(Status.Info, "Click on Add item button");
            AddItemScreen addItemScreen = homeScreen.clickAdd();
      

        }

        [Test]
        public void Test13()
        {
            // app.Repl();
            HomeScreen homeScreen = new HomeScreen(app, platform);
            extentTest.Log(Status.Info, "Click Add item button");
            AddItemScreen addItemScreen = homeScreen.clickAdd();

        }
    }
}
