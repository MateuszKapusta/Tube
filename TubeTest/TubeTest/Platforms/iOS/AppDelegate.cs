using Foundation;
using TubeTest.Platforms.ios.Services;

namespace TubeTest
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp(new DependencyModule());
    }
}
