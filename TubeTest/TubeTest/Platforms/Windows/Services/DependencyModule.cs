using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubeTest.Services.NativeProcess;
using Microsoft.Extensions.DependencyInjection;
using TubeTest.Services;

namespace TubeTest.Platforms.Windows.Services
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
