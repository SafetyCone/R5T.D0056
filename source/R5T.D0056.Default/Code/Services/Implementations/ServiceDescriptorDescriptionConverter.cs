using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056.Default
{
    public class ServiceDescriptorDescriptionConverter : IServiceDescriptorDescriptionConverter
    {
        public Task<IEnumerable<ServiceDescriptorDescription>> Convert(IServiceCollection services)
        {
            var output = services.Select(x => x.ToServiceDescriptorDescription());

            return Task.FromResult(output);
        }
    }
}
