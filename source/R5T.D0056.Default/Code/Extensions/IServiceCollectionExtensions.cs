using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.D0056.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ServiceDescriptorDescriber"/> implementation of <see cref="IServiceDescriptorDescriber"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddServiceDescriptorDescriber(this IServiceCollection services)
        {
            services.AddSingleton<IServiceDescriptorDescriber, ServiceDescriptorDescriber>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ServiceDescriptorDescriber"/> implementation of <see cref="IServiceDescriptorDescriber"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IServiceDescriptorDescriber> AddServiceDescriptorDescriberAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IServiceDescriptorDescriber>(() => services.AddServiceDescriptorDescriber());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedServiceCollectionDescriptionFilePathProvider"/> implementation of <see cref="IServiceCollectionDescriptionFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddConstructorBasedServiceCollectionDescriptionFilePathProvider(this IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            services.AddSingleton<IServiceCollectionDescriptionFilePathProvider>(new ConstructorBasedServiceCollectionDescriptionFilePathProvider(serviceCollectionDescriptionFilePath));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ConstructorBasedServiceCollectionDescriptionFilePathProvider"/> implementation of <see cref="IServiceCollectionDescriptionFilePathProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IServiceCollectionDescriptionFilePathProvider> AddConstructorBasedServiceCollectionDescriptionFilePathProviderAction(this IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            var serviceAction = ServiceAction.New<IServiceCollectionDescriptionFilePathProvider>(() => services.AddConstructorBasedServiceCollectionDescriptionFilePathProvider(
                serviceCollectionDescriptionFilePath));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="ServiceCollectionDescriber"/> implementation of <see cref="IServiceCollectionDescriber"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddServiceCollectionDescriber(this IServiceCollection services,
            IServiceAction<IServiceCollectionDescriptionFilePathProvider> serviceCollectionDescriptionFilePathProviderAction,
            IServiceAction<IServiceDescriptorDescriber> serviceDescriptorDescriberAction)
        {
            services
                .AddSingleton<IServiceCollectionDescriber, ServiceCollectionDescriber>()
                .Run(serviceCollectionDescriptionFilePathProviderAction)
                .Run(serviceDescriptorDescriberAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ServiceCollectionDescriber"/> implementation of <see cref="IServiceCollectionDescriber"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IServiceCollectionDescriber> AddServiceCollectionDescriberAction(this IServiceCollection services,
            IServiceAction<IServiceCollectionDescriptionFilePathProvider> serviceCollectionDescriptionFilePathProviderAction,
            IServiceAction<IServiceDescriptorDescriber> serviceDescriptorDescriberAction)
        {
            var serviceAction = ServiceAction.New<IServiceCollectionDescriber>(() => services.AddServiceCollectionDescriber(
                serviceCollectionDescriptionFilePathProviderAction,
                serviceDescriptorDescriberAction));

            return serviceAction;
        }

        public static
            (
            IServiceAction<IServiceCollectionDescriber> _,
            IServiceAction<IServiceCollectionDescriptionFilePathProvider> ServiceCollectionDescriptionFilePathProviderAction,
            IServiceAction<IServiceDescriptorDescriber> ServiceDescriptorDescriberAction
            )
        AddServiceCollectionDescriberAction(this IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            var serviceCollectionDescriptionFilePathProviderAction = services.AddConstructorBasedServiceCollectionDescriptionFilePathProviderAction(serviceCollectionDescriptionFilePath);
            var serviceDescriptorDescriberAction = services.AddServiceDescriptorDescriberAction();

            var serviceCollectionDescriberAction = services.AddServiceCollectionDescriberAction(
                serviceCollectionDescriptionFilePathProviderAction,
                serviceDescriptorDescriberAction);

            return
                (
                serviceCollectionDescriberAction,
                serviceCollectionDescriptionFilePathProviderAction,
                serviceDescriptorDescriberAction
                );
        }
    }
}
