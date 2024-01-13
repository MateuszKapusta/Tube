using Android.App;
using Android.Runtime;
using TubeTest.Platforms.Android.Services;

namespace TubeTest
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp(new DependencyModule());
    }
}
