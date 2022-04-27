using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.T0064;


namespace R5T.D0056
{
    [ServiceDefinitionMarker]
    public interface IServiceCollectionDescriber : IServiceDefinition
    {
        Task Describe(IServiceCollection services);
    }
}
