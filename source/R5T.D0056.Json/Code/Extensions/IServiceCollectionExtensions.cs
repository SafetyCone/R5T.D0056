using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.D0056.Json
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="JsonServiceCollectionDescriptionFileSerializer"/> implementation of <see cref="IServiceCollectionDescriptionFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddJsonServiceCollectionDescriptionFileSerializer(this IServiceCollection services)
        {
            services.AddSingleton<IServiceCollectionDescriptionFileSerializer, JsonServiceCollectionDescriptionFileSerializer>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="JsonServiceCollectionDescriptionFileSerializer"/> implementation of <see cref="IServiceCollectionDescriptionFileSerializer"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IServiceCollectionDescriptionFileSerializer> AddJsonServiceCollectionDescriptionFileSerializerAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IServiceCollectionDescriptionFileSerializer>(() => services.AddJsonServiceCollectionDescriptionFileSerializer());

            return serviceAction;
        }
    }
}
