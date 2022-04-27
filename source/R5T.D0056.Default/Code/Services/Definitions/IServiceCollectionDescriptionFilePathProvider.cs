using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0056.Default
{
    [ServiceDefinitionMarker]
    public interface IServiceCollectionDescriptionFilePathProvider : IServiceDefinition
    {
        Task<string> GetServiceCollectionDescriptionFilePath();
    }
}
