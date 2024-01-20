using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeTest.Platforms.Android.Services
{
    internal interface INotificationChannelService
    {
        public int CreateChannel(string name, string description);
    }
}
