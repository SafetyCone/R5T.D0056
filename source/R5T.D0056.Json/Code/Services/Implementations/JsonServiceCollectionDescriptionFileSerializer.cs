using System;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using R5T.Magyar.IO;

using System.Collections.Generic;


namespace R5T.D0056.Json
{
    public class JsonServiceCollectionDescriptionFileSerializer : IServiceCollectionDescriptionFileSerializer
    {
        public async Task Serialize(string filePath, IEnumerable<ServiceDescriptorDescription> descriptions)
        {
            var descriptionsInOrderArray = descriptions
                .OrderBy(x => x.ServiceType)
                .ToArray();

            var json = JsonConvert.SerializeObject(descriptionsInOrderArray);

            using (var streamWriter = StreamWriterHelper.NewWrite(filePath))
            {
                await streamWriter.WriteAsync(json);
            }
        }

        public async Task<IEnumerable<ServiceDescriptorDescription>> Deserialize(string filePath)
        {
            var jsonSerializer = new JsonSerializer();

            using (var streamReader = StreamReaderHelper.New(filePath))
            {
                var json = await streamReader.ReadToEndAsync();

                var serviceDescriptorDescriptions = JsonConvert.DeserializeObject<ServiceDescriptorDescription[]>(json);
                return serviceDescriptorDescriptions;
            }
        }
    }
}
