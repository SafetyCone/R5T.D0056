using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056
{
    public class ServiceDescriptorDescription
    {
        public string ServiceType { get; set; }
        public string ImplementationType { get; set; }
        public ServiceLifetime ServiceLifetime { get; set; }
    }
}
