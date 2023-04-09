using BroFixe.Infrastructure.Data.UnitOfWork;
using BroFixe.Web.Utils;
using JetBrains.Annotations;

namespace BroFixe.Web.Infrastructure.UnitOfWork;

public class UnitOfWorkMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public UnitOfWorkMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    [UsedImplicitly]
    public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork)
    {
        await _requestDelegate.Invoke(httpContext);

        if (ShouldCommit(httpContext))
            await unitOfWork.Complete();
    }

    private bool ShouldCommit(HttpContext httpContext)
    {
        return httpContext.Response.StatusCode >= 200 && httpContext.Response.StatusCode < 300 &&
               httpContext.Request.IsWriteMethod();
    }
}