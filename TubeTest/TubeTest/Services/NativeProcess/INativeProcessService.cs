using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeTest.Services.NativeProcess
{
    public interface INativeProcessService
    {

        Task StartProcess(Func<Task> action);
    }
}
