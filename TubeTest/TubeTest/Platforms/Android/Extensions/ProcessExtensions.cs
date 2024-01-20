using Android.App;
using Android.Content;
using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeTest.Platforms.Droid.Extensions
{
    public static class ProcessExtensions
    {
        public static void StartForegroundServiceCompat<T>(this Context context, string action = null, Bundle args = null) where T : Service
        {
            var intent = new Intent(context, typeof(T));
            if (!string.IsNullOrEmpty(action))
            {
                intent.SetAction(action);
            }

            if (args != null)
            {
                intent.PutExtras(args);
            }

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                context.StartForegroundService(intent);
            }
            else
            {
                context.StartService(intent);
            }
        }
    }
}
