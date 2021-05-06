using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace R5T.D0056.Json
{
    public interface IServiceCollectionDescriptionFileSerializer
    {
        Task Serialize(string filePath, IEnumerable<ServiceDescriptorDescription> descriptions);
        Task<IEnumerable<ServiceDescriptorDescription>> Deserialize(string filePath);
    }
}
