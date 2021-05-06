using System;
using System.Threading.Tasks;


namespace R5T.D0056.Default
{
    public class ConstructorBasedServiceCollectionDescriptionFilePathProvider : IServiceCollectionDescriptionFilePathProvider
    {
        private string DescriptionFilePath { get; }


        public ConstructorBasedServiceCollectionDescriptionFilePathProvider(
            string descriptionFilePath)
        {
            this.DescriptionFilePath = descriptionFilePath;
        }

        public Task<string> GetServiceCollectionDescriptionFilePath()
        {
            return Task.FromResult(this.DescriptionFilePath);
        }
    }
}
