using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubeTest.Services
{
    public interface IDependencyModule
    {
        IServiceCollection Register(IServiceCollection services);
    }
}
