using NSwag.Generation.AspNetCore;

namespace BroFixe.Web.Infrastructure.OpenApi;

public class OpenApiDefinition
{
  public string ApiGroupName { get; }
  public string Version { get; }
  public string Title { get; }
  public string Description { get; }

  public string? TypeScriptFileName { get; }

  public string DocumentName => $"{ApiGroupName}_{Version}";

  public Action<AspNetCoreOpenApiDocumentGeneratorSettings>? ConfigureGenerationSettings { get; set; }

  public OpenApiDefinition (string apiGroupName, string version, string title, string description, string? typeScriptFileName = null)
  {
    ApiGroupName = apiGroupName;
    Version = version;
    Title = title;
    Description = description;
    TypeScriptFileName = typeScriptFileName;
  }
}