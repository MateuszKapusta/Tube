using Android.App;
using Android.OS;
using Android.Runtime;
using TubeTest.Platforms.Android.Services;
using TubeTest.Platforms.Droid.Services;
using YoutubeExplode.Channels;

namespace TubeTest
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public static int DefaultChannelId { get; private set; }
        const string channelName = "Default";
        const string channelDescription = "The default channel for notifications.";

        public MainApplication(
            IntPtr handle
            , JniHandleOwnership ownership)
            : base(handle, ownership)
        {
            INotificationChannelService chanelService = new NotificationChannelService();
            DefaultChannelId = chanelService.CreateChannel(channelName, channelDescription);
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp(new DependencyModule());
    }
}
