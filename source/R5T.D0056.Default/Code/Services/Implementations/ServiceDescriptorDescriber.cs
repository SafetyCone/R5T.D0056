using System;
using System.IO;
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

            stringBuilder
                .AppendLine("-----")
                .AppendLine($"Service Type: {serviceDescriptor.ServiceType.FullName}")
                .AppendLine($"Implementation Type: {(serviceDescriptor.ImplementationType == null ? "<null>" : serviceDescriptor.ImplementationType.FullName)}")
                .AppendLine($"{nameof(serviceDescriptor.Lifetime)}: {serviceDescriptor.Lifetime}")
                .AppendLine($"Implementation Instance: {(serviceDescriptor.ImplementationInstance == null ? "<null>" : serviceDescriptor.ImplementationInstance.ToString())}")
                .AppendLine($"Implementation Factory: {serviceDescriptor.ImplementationFactory}")
                ;

            var description = stringBuilder.ToString();
            return Task.FromResult(description);
        }
    }
}
