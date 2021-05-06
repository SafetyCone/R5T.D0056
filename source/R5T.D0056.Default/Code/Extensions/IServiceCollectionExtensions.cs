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
        /// Adds the <see cref="TextFileServiceCollectionDescriber"/> implementation of <see cref="IServiceCollectionDescriber"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddTextFileServiceCollectionDescriber(this IServiceCollection services,
            IServiceAction<IServiceCollectionDescriptionFilePathProvider> serviceCollectionDescriptionFilePathProviderAction,
            IServiceAction<IServiceDescriptorDescriber> serviceDescriptorDescriberAction)
        {
            services
                .AddSingleton<IServiceCollectionDescriber, TextFileServiceCollectionDescriber>()
                .Run(serviceCollectionDescriptionFilePathProviderAction)
                .Run(serviceDescriptorDescriberAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="TextFileServiceCollectionDescriber"/> implementation of <see cref="IServiceCollectionDescriber"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IServiceCollectionDescriber> AddTextFileServiceCollectionDescriberAction(this IServiceCollection services,
            IServiceAction<IServiceCollectionDescriptionFilePathProvider> serviceCollectionDescriptionFilePathProviderAction,
            IServiceAction<IServiceDescriptorDescriber> serviceDescriptorDescriberAction)
        {
            var serviceAction = ServiceAction.New<IServiceCollectionDescriber>(() => services.AddTextFileServiceCollectionDescriber(
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
            AddTextFileServiceCollectionDescriberAction(this IServiceCollection services, string serviceCollectionDescriptionFilePath)
        {
            var serviceCollectionDescriptionFilePathProviderAction = services.AddConstructorBasedServiceCollectionDescriptionFilePathProviderAction(serviceCollectionDescriptionFilePath);
            var serviceDescriptorDescriberAction = services.AddServiceDescriptorDescriberAction();

            var serviceCollectionDescriberAction = services.AddTextFileServiceCollectionDescriberAction(
                serviceCollectionDescriptionFilePathProviderAction,
                serviceDescriptorDescriberAction);

            return
                (
                serviceCollectionDescriberAction,
                serviceCollectionDescriptionFilePathProviderAction,
                serviceDescriptorDescriberAction
                );
        }

        /// <summary>
        /// Adds the <see cref="ServiceDescriptorDescriptionConverter"/> implementation of <see cref="IServiceDescriptorDescriptionConverter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddServiceDescriptorDescriptionConverter(this IServiceCollection services)
        {
            services.AddSingleton<IServiceDescriptorDescriptionConverter, ServiceDescriptorDescriptionConverter>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ServiceDescriptorDescriptionConverter"/> implementation of <see cref="IServiceDescriptorDescriptionConverter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IServiceDescriptorDescriptionConverter> AddServiceDescriptorDescriptionConverterAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IServiceDescriptorDescriptionConverter>(() => services.AddServiceDescriptorDescriptionConverter());
            return serviceAction;
        }
    }
}
