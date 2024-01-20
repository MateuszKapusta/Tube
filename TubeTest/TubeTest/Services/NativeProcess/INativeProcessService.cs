using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeTest.Services.NativeProcess
{
    public interface INativeProcessService
    {
        void StartProcess(Type processName, string action = null, object data = null);
        void StopProcess(Type processName, string action = null);
    }
}
