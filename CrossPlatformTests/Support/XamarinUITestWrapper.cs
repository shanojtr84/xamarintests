using CrossPlatformTests.Base;
using Xamarin.UITest;
using UIElement = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace CrossPlatformTests.Support
{
    public class XamarinUITestWrapper : BaseScreen
    {
        public XamarinUITestWrapper(IApp app, Platform platform) 
            : base(app, platform)
        {

        }

        public void TapOn(UIElement element)
        {
            app.Tap(element);
        }

        public void TypeText(UIElement element, string text)
        {
            app.EnterText(element, text);
        }

        public void DismissDeviceKeyboard()
        {
            app.DismissKeyboard();
        }



       

    }
}
