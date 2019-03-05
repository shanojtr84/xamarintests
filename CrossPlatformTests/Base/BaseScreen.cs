using System;
using NUnit.Framework;

using Xamarin.UITest;
using Xamarin.UITest.Queries;
namespace CrossPlatformTests.Base
{
    public class BaseScreen{

        protected readonly IApp app;
        protected readonly Platform platform;

        protected BaseScreen(IApp app, Platform platform)
        {
            this.app = app;

            this.platform = platform;

        }

    }
}
