using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056
{
    /// <summary>
    /// Describes a <see cref="ServiceDescriptor/> to a <see cref="TextWriter"/>.
    /// </summary>
    public interface IServiceDescriptorDescriber
    {
        Task<string> Describe(ServiceDescriptor serviceDescriptor);
    }
}
