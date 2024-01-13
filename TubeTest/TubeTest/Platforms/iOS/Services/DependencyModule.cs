using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Services;
using TubeTest.Services.NativeProcess;

namespace TubeTest.Platforms.ios.Services
{
    internal class DependencyModule : IDependencyModule
    {
        public IServiceCollection Register(IServiceCollection services)
        {   
            services.AddSingleton<INativeProcessService, NativeProcessService>();
            return services;
        }
    }
}
