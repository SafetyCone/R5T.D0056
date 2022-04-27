using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0064;


namespace R5T.D0056.Default
{
    [ServiceImplementationMarker]
    public class ServiceDescriptorDescriptionConverter : IServiceDescriptorDescriptionConverter, IServiceImplementation
    {
        public Task<IEnumerable<ServiceDescriptorDescription>> Convert(IServiceCollection services)
        {
            var output = services.Select(x => x.ToServiceDescriptorDescription());

            return Task.FromResult(output);
        }
    }
}
