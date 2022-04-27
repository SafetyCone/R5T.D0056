using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0064;


namespace R5T.D0056
{
    [ServiceDefinitionMarker]
    public interface IServiceDescriptorDescriptionConverter : IServiceDefinition
    {
        Task<IEnumerable<ServiceDescriptorDescription>> Convert(IServiceCollection services);
    }
}
