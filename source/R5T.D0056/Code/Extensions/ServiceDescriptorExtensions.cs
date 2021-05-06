using System;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056
{
    public static class ServiceDescriptorExtensions
    {
        public static string GetServiceTypeStandardRepresentation(this ServiceDescriptor serviceDescriptor)
        {
            var output = ServiceDescriptorHelper.GetServiceTypeStandardRepresentation(serviceDescriptor);
            return output;
        }

        public static string GetImplementationTypeStandardRepresentation(this ServiceDescriptor serviceDescriptor)
        {
            var output = ServiceDescriptorHelper.GetImplementationTypeStandardRepresentation(serviceDescriptor);
            return output;
        }

        public static string GetLifetimeStandardRepresentation(this ServiceDescriptor serviceDescriptor)
        {
            var output = ServiceDescriptorHelper.GetLifetimeStandardRepresentation(serviceDescriptor);
            return output;
        }
    }
}
