using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Services.NativeProcess;
using static System.Collections.Specialized.BitVector32;

namespace TubeTest.Platforms.Windows.Services
{
    internal class NativeProcessService : INativeProcessService
    {
        public void StartProcess(Type processName, string action = null, object data = null)
        {
            throw new NotImplementedException();
        }

        public void StopProcess(Type processName, string action = null)
        {
            throw new NotImplementedException();
        }
    }
}
