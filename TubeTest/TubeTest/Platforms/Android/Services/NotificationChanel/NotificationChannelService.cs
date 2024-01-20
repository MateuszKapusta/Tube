using Android.App;
using Android.Content;
using Android.OS;

namespace TubeTest.Platforms.Android.Services
{
    internal class NotificationChannelService : INotificationChannelService
    {
        public int CreateChannel(string channelName, string channelDescription)
        {

            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return 0;
            }


            var notificationManager = (NotificationManager)Platform.AppContext.GetSystemService(Context.NotificationService);
            var allChannels = notificationManager.NotificationChannels;
            var newChannelNumber = allChannels == null ? 1 : allChannels.Count + 1;

            var channel = new NotificationChannel(newChannelNumber.ToString(), channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };

            notificationManager.CreateNotificationChannel(channel);
            return newChannelNumber;
        }
    }
}
