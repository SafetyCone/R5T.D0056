using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar;


namespace R5T.D0056
{
    public static class ServiceDescriptorHelper
    {
        public static string GetServiceTypeStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var output = serviceDescriptor.ServiceType.FullName;
            return output;
        }

        public static string GetImplementationTypeStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var output = serviceDescriptor.ImplementationType?.FullName ?? NullHelper.StandardStringRepresentation;
            return output;
        }

        public static string GetLifetimeStandardRepresentation(ServiceDescriptor serviceDescriptor)
        {
            var output = serviceDescriptor.Lifetime.ToStringStandard();
            return output;
        }
    }
}
