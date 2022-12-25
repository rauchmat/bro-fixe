namespace BroFixe.Web.Infrastructure.OpenApi;

public static class WebOpenApiDefinitions
{
    public static OpenApiDefinition UI { get; } = new("UI", "v1", "UI API",
        "REST API for Bro Fixe UI", "api.ts");

    public static IReadOnlyList<OpenApiDefinition> All { get; } = new[] {UI};
}