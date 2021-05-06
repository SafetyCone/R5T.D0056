using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056
{
    public interface IServiceCollectionDescriber
    {
        Task Describe(IServiceCollection services);
    }
}
