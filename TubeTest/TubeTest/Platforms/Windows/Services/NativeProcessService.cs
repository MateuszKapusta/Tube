using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Services.NativeProcess;

namespace TubeTest.Platforms.Windows.Services
{
    internal class NativeProcessService : INativeProcessService
    {
        public async Task StartProcess(Func<Task> action)
        {
            await action?.Invoke();
        }
    }
}
