using System;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0056.Default
{
    public class ServiceDescriptorDescriber : IServiceDescriptorDescriber
    {
        public Task<string> Describe(ServiceDescriptor serviceDescriptor)
        {
            var stringBuilder = new StringBuilder();

            var serviceTypeStandardRepresentation = serviceDescriptor.GetServiceTypeStandardRepresentation();
            var implementationTypeStandardRepresentation = serviceDescriptor.GetImplementationTypeStandardRepresentation();
            var lifetimeStandardRepresentation = serviceDescriptor.GetLifetimeStandardRepresentation();

            stringBuilder
                .AppendLine("-----")
                .AppendLine($"Service Type: {serviceTypeStandardRepresentation}")
                .AppendLine($"Implementation Type: {implementationTypeStandardRepresentation}")
                .AppendLine($"{nameof(serviceDescriptor.Lifetime)}: {lifetimeStandardRepresentation}")
                .AppendLine($"Implementation Instance: {serviceDescriptor.ImplementationInstance?.ToString() ?? "<null>"}")
                .AppendLine($"Implementation Factory: {serviceDescriptor.ImplementationFactory}")
                ;

            var description = stringBuilder.ToString();
            return Task.FromResult(description);
        }
    }
}
