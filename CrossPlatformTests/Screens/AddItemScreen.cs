using System;
using Xamarin.UITest.Queries;
using CrossPlatformTests.Screens;
using Xamarin.UITest;
using System.Linq;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using CrossPlatformTests.Support;

namespace CrossPlatformTests.Screens
{
    public class AddItemScreen : XamarinUITestWrapper
    {
        public AddItemScreen(IApp app, Platform platform)
          : base(app, platform)
        {
        }

        // public UIElement TitleBox => x => x.Id("txtTitle");
        //  public UIElement DescriptionBox => x => x.Id("txtDesc");
       //  public UIElement SaveBtn => x => x.Id("save_button");

        public UIElement TitleBox{
            get{string text = platform == Platform.Android ? "txtTitle" : "Item Name";
                return x => x.Marked(text);}
        }
        public UIElement DescriptionBox {
            get{string text = platform == Platform.Android ? "txtDesc" : "Item Description";
                return x => x.Marked(text);}
        }

        public UIElement SaveBtn{
            get{ string identifier = platform == Platform.Android ? "save_button" : "Save Item";
                return x => x.Marked(identifier);}
        }

        internal HomeScreen addItem(String title, String description)
        {
            TypeText(TitleBox, title);
            DismissDeviceKeyboard();
            TypeText(DescriptionBox, description);
            DismissDeviceKeyboard();
            TapOn(SaveBtn);
            return new HomeScreen(app, platform);
        }

    }
}
