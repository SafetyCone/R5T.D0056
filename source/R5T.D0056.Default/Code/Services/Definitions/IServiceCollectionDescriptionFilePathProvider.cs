using System;
using System.Threading.Tasks;


namespace R5T.D0056.Default
{
    public interface IServiceCollectionDescriptionFilePathProvider
    {
        Task<string> GetServiceCollectionDescriptionFilePath();
    }
}
