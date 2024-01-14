using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Util;
using AndroidX.Core.App;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using Java.Lang;
using Java.Util.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Messages;
using YoutubeExplode.Channels;
using AndroidApp = Android.App.Application;

namespace TubeTest.Platforms.Droid.Services
{
    [Service(ForegroundServiceType = ForegroundService.TypeMediaPlayback)]
    public class CutomVideoPlayerService : Service
    {
        bool isStarted;

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override IBinder? OnBind(Intent? intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent.Action.Equals(Constants.ACTION_START_SERVICE))
            {
                if (isStarted)
                {
                    Log.Info(nameof(StartCommandResult), "OnStartCommand: The service is already running.");
                }
                else
                {
                    Log.Info(nameof(StartCommandResult), "OnStartCommand: The service is starting.");
                    RegisterForegroundService();
                    isStarted = true;
                }
            }
            else if (intent.Action.Equals(Constants.ACTION_CLOSE_SERVICE))
            {
                Log.Info(nameof(StartCommandResult), "OnStartCommand: The service is stopping.");
                StopForeground(true);
                StopSelf();
                isStarted = false;

            }
            else if (intent.Action.Equals(Constants.ACTION_PLAY_MEDIA))
            {
                Log.Info(nameof(StartCommandResult), "OnStartCommand: Play the media.");
                WeakReferenceMessenger.Default.Send(new MediaPlayerMessage(new Models.PlayerStatus() { Play = true}));

            }
            else if (intent.Action.Equals(Constants.ACTION_STOP_MEDIA))
            {
                Log.Info(nameof(StartCommandResult), "OnStartCommand: Stop the media.");
                WeakReferenceMessenger.Default.Send(new MediaPlayerMessage(new Models.PlayerStatus() { Play = false }));
            }

            return base.OnStartCommand(intent, flags, startId);
        }

        PendingIntent BuildIntentToShowMainActivity()
        {
            var notificationIntent = new Intent(this, typeof(MainActivity));
            notificationIntent.SetAction(Constants.ACTION_MAIN_ACTIVITY);
            notificationIntent.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ClearTask);
            notificationIntent.PutExtra(Constants.SERVICE_STARTED_KEY, true);

            var pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, PendingIntentFlags.UpdateCurrent);
            return pendingIntent;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        void RegisterForegroundService()
        {

            var notification = new Notification.Builder(this, MainApplication.DefaultChannelId.ToString())
                .SetContentTitle("TubeTest")
                .SetContentText("Testing tube")
                .SetSmallIcon(Resource.Drawable.play_arrow)
                .SetContentIntent(BuildIntentToShowMainActivity())
                .SetOngoing(true)
                .AddAction(BuildStopServiceAction())
                .AddAction(BuildPlayTimerAction())
                .Build();


            // Enlist this instance of the service as a foreground service
            StartForeground(Constants.SERVICE_RUNNING_NOTIFICATION_ID, notification);
        }


        Notification.Action BuildPlayTimerAction()
        {
            var playTimerIntent = new Intent(this, GetType());
            playTimerIntent.SetAction(Constants.ACTION_PLAY_MEDIA);
            var restartTimerPendingIntent = PendingIntent.GetService(this, 0, playTimerIntent, 0);

            var builder = new Notification.Action.Builder(
                Resource.Drawable.exo_icon_pause
                , "Play"
                , restartTimerPendingIntent);

            return builder.Build();
        }

        Notification.Action BuildStopServiceAction()
        {
            var stopServiceIntent = new Intent(this, GetType());
            stopServiceIntent.SetAction(Constants.ACTION_STOP_MEDIA);
            var stopServicePendingIntent = PendingIntent.GetService(this, 0, stopServiceIntent, 0);

            var builder = new Notification.Action.Builder(Resource.Drawable.play_arrow,
                                                          "Stop",
                                                          stopServicePendingIntent);
            return builder.Build();

        }

    }
}
