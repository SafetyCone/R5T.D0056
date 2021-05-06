using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056.Investigation
{
    public static class IServiceCollectionExtensions
    {
        public static Task Describe(this IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            return ServiceCollectionInvestigationHelper.DescribeServicesToFile(services, serviceCollectionDescriptionFilePath);
        }

        public static Task SerializeToJsonFile(this IServiceCollection services, string serviceCollectionDescriptionJsonFilePath)
        {
            return ServiceCollectionInvestigationHelper.SerializeToJsonFile(services, serviceCollectionDescriptionJsonFilePath);
        }
    }
}
