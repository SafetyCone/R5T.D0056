using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056
{
    public interface IServiceDescriptorDescriptionConverter
    {
        Task<IEnumerable<ServiceDescriptorDescription>> Convert(IServiceCollection services);
    }
}
