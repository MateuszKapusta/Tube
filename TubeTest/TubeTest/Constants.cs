using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeTest
{
    public static class Constants
    {
        public const int DELAY_BETWEEN_LOG_MESSAGES = 5000; // milliseconds
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
        public const string SERVICE_STARTED_KEY = "has_service_been_started";
        public const string BROADCAST_MESSAGE_KEY = "broadcast_message";
        public const string NOTIFICATION_BROADCAST_ACTION = "TubeTest.Notification.Action";

        public const string ACTION_START_SERVICE = "TubeTest.action.START_SERVICE";
        public const string ACTION_CLOSE_SERVICE = "TubeTest.action.CLOSE_SERVICE";
        public const string ACTION_STOP_MEDIA = "TubeTest.action.STOP_MEDIA";
        public const string ACTION_PLAY_MEDIA = "TubeTest.action.PLAY_MEDIA";
        public const string ACTION_MAIN_ACTIVITY = "TubeTest.action.MAIN_ACTIVITY";
    }
}
