using System.Collections;
using Autofac;
using Autofac.Core;

namespace BroFixe.Infrastructure.Utils;

public static class AutofacExtensions
{
    public static IReadOnlyCollection<object> ResolveAll(this IComponentContext componentContext, Type serviceType)
    {
        var enumerableType = typeof(IEnumerable<>).MakeGenericType(serviceType);
        var enumerable = (IEnumerable)componentContext.Resolve(enumerableType);

        return enumerable.OfType<object>().ToList();
    }

    public static bool IsRoot(this ILifetimeScope lifetimeScope)
    {
        return lifetimeScope is ISharingLifetimeScope sharingLifetimeScope
               && sharingLifetimeScope.RootLifetimeScope == sharingLifetimeScope;
    }
}