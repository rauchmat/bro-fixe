using NJsonSchema;
using NJsonSchema.Generation;
using NJsonSchema.Generation.TypeMappers;
using NSwag.Generation.AspNetCore;

namespace BroFixe.Web.Infrastructure.OpenApi;

public static class SwaggerConfigurationExtensions
{
  public static void ConfigureSwagger(this IServiceCollection services, IReadOnlyList<OpenApiDefinition> openApiDefinitions)
  {
    foreach (var definition in openApiDefinitions)
      AddOpenApiDocument(definition);

    void AddOpenApiDocument(OpenApiDefinition definition)
    {
      services.AddOpenApiDocument(ConfigureOpenApiDocument);

      void ConfigureOpenApiDocument(AspNetCoreOpenApiDocumentGeneratorSettings settings)
      {
        settings.PostProcess = pp =>
        {
          pp.Info.Version = definition.Version;
          pp.Info.Title = definition.Title;
          pp.Info.Description = definition.Description;
        };
        settings.DocumentName = definition.DocumentName;
        settings.ApiGroupNames = new[] {definition.ApiGroupName};
        definition.ConfigureGenerationSettings?.Invoke(settings);
      }
    }
  }
}