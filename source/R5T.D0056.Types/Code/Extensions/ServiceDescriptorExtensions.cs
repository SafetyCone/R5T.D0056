using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056
{
    public static class ServiceDescriptorExtensions
    {
        public static ServiceDescriptorDescription ToServiceDescriptorDescription(this ServiceDescriptor serviceDescriptor)
        {
            var serviceTypeStandardRepresentation = serviceDescriptor.GetServiceTypeStandardRepresentation();
            var implementationTypeStandardRepresentation = serviceDescriptor.GetImplementationTypeStandardRepresentation();

            var serviceDescriptorDescription = new ServiceDescriptorDescription
            {
                ImplementationType = implementationTypeStandardRepresentation,
                ServiceType = serviceTypeStandardRepresentation,
                ServiceLifetime = serviceDescriptor.Lifetime,
            };
            return serviceDescriptorDescription;
        }
    }
}
