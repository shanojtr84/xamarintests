using System;
using Xamarin.UITest.Queries;
using CrossPlatformTests.Screens;
using Xamarin.UITest;
using System.Linq;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using CrossPlatformTests.Support;

namespace CrossPlatformTests.Screens
{
    public class HomeScreen:XamarinUITestWrapper
    {
        public HomeScreen(IApp app, Platform platform)
           : base(app, platform)
        {

        }

        public UIElement MoreBtn => x => x.Marked("More options");
       // public UIElement AddBtn => x => x.Marked("Add");

        public UIElement AddBtn
        {  get
            { string id = platform == Platform.Android ? "Add" : "Add Item";
                return x => x.Marked(id);
            }
        }

        internal AddItemScreen clickAdd()
        {
            if(platform==Platform.Android){
                TapOn(MoreBtn);
            }
            app.WaitForElement(AddBtn);
            TapOn(AddBtn);
            return new AddItemScreen(app,platform);
        }

        internal Boolean isItemAdded(String title)
        {
            app.WaitForElement(x => x.Marked(title));
            return app.Query(x => x.Marked(title)).Any();

        }
    }
}

