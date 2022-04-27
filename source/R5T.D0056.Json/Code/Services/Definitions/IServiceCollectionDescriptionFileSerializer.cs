using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0056.Json
{
    [ServiceDefinitionMarker]
    public interface IServiceCollectionDescriptionFileSerializer : IServiceDefinition
    {
        Task Serialize(string filePath, IEnumerable<ServiceDescriptorDescription> descriptions);
        Task<IEnumerable<ServiceDescriptorDescription>> Deserialize(string filePath);
    }
}
