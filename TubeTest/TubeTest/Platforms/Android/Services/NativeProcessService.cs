using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Com.Google.Android.Exoplayer2.Offline;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Platforms.Droid.Extensions;
using TubeTest.Services.NativeProcess;

namespace TubeTest.Platforms.Droid.Services
{
    internal class NativeProcessService : INativeProcessService
    {

        public void StartProcess(Type processName, string action = null, object data = null)
        {
            switch (processName.Name)
            {
                case nameof(MediaElement):
                    var bundle = new Bundle();
                    bundle.PutString(nameof(data), (string)data);
                    Platform.AppContext.StartForegroundServiceCompat<CutomVideoPlayerService>(action, bundle);
                    break;
            }
        }

        public void StopProcess(Type processName, string action = null)
        {
            switch (processName.Name)
            {
                case nameof(MediaElement):
                    var intent = new Intent(Platform.AppContext, typeof(CutomVideoPlayerService));
                    if (!string.IsNullOrEmpty(action))
                    {
                        intent.SetAction(action);
                    }
                    Platform.AppContext.StopService(intent);
                    break;
            }
        }

    }
}
