using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Services.NativeProcess;

namespace TubeTest.Platforms.ios.Services
{
    internal class NativeProcessService : INativeProcessService
    {
        public Task StartProcess(Func<Task> action)
        {
            throw new NotImplementedException();
        }
    }
}
