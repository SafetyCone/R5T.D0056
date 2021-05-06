using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Magyar;


namespace R5T.D0056
{
    public static class ServiceLifetimeExtensions
    {
        public static string ToStringStandard(this ServiceLifetime serviceLifetime)
        {
            switch(serviceLifetime)
            {
                case ServiceLifetime.Scoped:
                    return ServiceLifetimeHelper.ScopedStandardRepresentation;

                case ServiceLifetime.Singleton:
                    return ServiceLifetimeHelper.SingletonStandardRepresentation;

                case ServiceLifetime.Transient:
                    return ServiceLifetimeHelper.TransientStandardRepresentation;

                default:
                    throw EnumerationHelper.UnexpectedEnumerationValueException(serviceLifetime);
            }
        }
    }
}
