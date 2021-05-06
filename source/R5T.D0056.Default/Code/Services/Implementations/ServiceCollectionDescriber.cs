using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar.IO;


namespace R5T.D0056.Default
{
    public class ServiceCollectionDescriber : IServiceCollectionDescriber
    {
        private IServiceCollectionDescriptionFilePathProvider ServiceCollectionDescriptionFilePathProvider { get; }
        private IServiceDescriptorDescriber ServiceDescriptorDescriber { get; }


        public ServiceCollectionDescriber(
            IServiceCollectionDescriptionFilePathProvider serviceCollectionDescriptionFilePathProvider,
            IServiceDescriptorDescriber serviceDescriptorDescriber)
        {
            this.ServiceCollectionDescriptionFilePathProvider = serviceCollectionDescriptionFilePathProvider;
            this.ServiceDescriptorDescriber = serviceDescriptorDescriber;
        }

        public async Task Describe(IServiceCollection services)
        {
            var servicesInOrder = services.OrderBy(x => x.ServiceType.FullName);

            var serviceCollectionDescriptionFilePath = await this.ServiceCollectionDescriptionFilePathProvider.GetServiceCollectionDescriptionFilePath();

            using (var fileWriter = StreamWriterHelper.NewWrite(serviceCollectionDescriptionFilePath))
            {
                foreach (var serviceDescriptor in servicesInOrder)
                {
                    var description = await this.ServiceDescriptorDescriber.Describe(serviceDescriptor);

                    await fileWriter.WriteLineAsync(description);
                }
            }
        }
    }
}
