using Microsoft.AspNetCore.Mvc;

namespace BroFixe.Web.Infrastructure.OpenApi;

public class UiApiAttribute : ApiExplorerSettingsAttribute
{
    public UiApiAttribute()
    {
        GroupName = WebOpenApiDefinitions.UI.ApiGroupName;
    }
}