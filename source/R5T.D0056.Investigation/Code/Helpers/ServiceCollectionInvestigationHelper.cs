using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;

using R5T.D0056.Default;
using R5T.D0056.Json;


namespace R5T.D0056.Investigation
{
    public static class ServiceCollectionInvestigationHelper
    {
        public static async Task DescribeServicesToFile(IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            var temporaryServices = new ServiceCollection();

#pragma warning disable IDE0042 // Deconstruct variable declaration
            var serviceCollectionDescriberAction = temporaryServices.AddTextFileServiceCollectionDescriberAction(serviceCollectionDescriptionFilePath);
#pragma warning restore IDE0042 // Deconstruct variable declaration

            temporaryServices
                .Run(serviceCollectionDescriberAction._)
                ;

            using (var serviceProvider = temporaryServices.BuildServiceProvider())
            {
                var serviceCollectionDescriber = serviceProvider.GetRequiredService<IServiceCollectionDescriber>();

                await serviceCollectionDescriber.Describe(services);
            }
        }

        private static ServiceProvider GetJsonSerializationServiceProvider()
        {
            var services = new ServiceCollection();

            var serviceCollectionDescriptionFileSerializerAction = services.AddJsonServiceCollectionDescriptionFileSerializerAction();
            var serviceDescriptorDescriptionConverterAction = services.AddServiceDescriptorDescriptionConverterAction();

            services
                .Run(serviceCollectionDescriptionFileSerializerAction)
                .Run(serviceDescriptorDescriptionConverterAction)
                ;

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static async Task SerializeToJsonFile(IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            using (var serviceProvider = ServiceCollectionInvestigationHelper.GetJsonSerializationServiceProvider())
            {
                var serviceCollectionDescriptionFileSerializer = serviceProvider.GetRequiredService<IServiceCollectionDescriptionFileSerializer>();
                var serviceDescriptorDescriptionConverter = serviceProvider.GetRequiredService<IServiceDescriptorDescriptionConverter>();

                var descriptions = await serviceDescriptorDescriptionConverter.Convert(services);

                await serviceCollectionDescriptionFileSerializer.Serialize(serviceCollectionDescriptionFilePath, descriptions);
            }
        }

        public static async Task FindServicesIn01MissingFrom02(
            string serviceCollectionDescriptionFilePath01,
            string serviceCollectionDescriptionFilePath02,
            string differencesFilePath)
        {
            using (var serviceProvider = ServiceCollectionInvestigationHelper.GetJsonSerializationServiceProvider())
            {
                var serviceCollectionDescriptionFileSerializer = serviceProvider.GetRequiredService<IServiceCollectionDescriptionFileSerializer>();

                var descriptions01 = await serviceCollectionDescriptionFileSerializer.Deserialize(serviceCollectionDescriptionFilePath01);
                var descriptions02 = await serviceCollectionDescriptionFileSerializer.Deserialize(serviceCollectionDescriptionFilePath02);

                var in01MissingFrom02 = descriptions01.Except(descriptions02, new ServiceDescriptorDescriptionServiceTypeEqualityComparer());

                await serviceCollectionDescriptionFileSerializer.Serialize(differencesFilePath, in01MissingFrom02);
            }
        }
    }
}
