using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0064;


namespace R5T.D0056
{
    /// <summary>
    /// Describes a <see cref="ServiceDescriptor/> to a <see cref="TextWriter"/>.
    /// </summary>
    [ServiceDefinitionMarker]
    public interface IServiceDescriptorDescriber : IServiceDefinition
    {
        Task<string> Describe(ServiceDescriptor serviceDescriptor);
    }
}
