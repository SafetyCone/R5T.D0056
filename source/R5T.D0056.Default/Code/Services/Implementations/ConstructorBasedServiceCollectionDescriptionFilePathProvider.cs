using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0056.Default
{
    [ServiceImplementationMarker]
    public class ConstructorBasedServiceCollectionDescriptionFilePathProvider : IServiceCollectionDescriptionFilePathProvider, IServiceImplementation
    {
        private string DescriptionFilePath { get; }


        public ConstructorBasedServiceCollectionDescriptionFilePathProvider(
            [NotServiceComponent] string descriptionFilePath)
        {
            this.DescriptionFilePath = descriptionFilePath;
        }

        public Task<string> GetServiceCollectionDescriptionFilePath()
        {
            return Task.FromResult(this.DescriptionFilePath);
        }
    }
}
