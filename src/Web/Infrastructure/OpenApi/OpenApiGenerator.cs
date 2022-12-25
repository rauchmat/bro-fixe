using System.Text;
using NJsonSchema.CodeGeneration.TypeScript;
using NSwag;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.TypeScript;
using NSwag.Generation;

namespace BroFixe.Web.Infrastructure.OpenApi;

public class OpenApiGenerator
{
    public static async Task GenerateApiClients(string dotNetDirectory, string typeScriptDirectory, IHost host)
    {
        var swaggerProvider = host.Services.GetRequiredService<IOpenApiDocumentGenerator>();
        foreach (var definition in WebOpenApiDefinitions.All)
        {
            var openApiDocument = await swaggerProvider.GenerateAsync(definition.DocumentName);
            var dotNetFilename = Path.Combine(dotNetDirectory, $"{definition.ApiGroupName}.cs");
            var @namespace = $"BroFixe.Essentials.Web.Tests.Integration.Api.{definition.ApiGroupName}";
            GenerateDotNetClient(dotNetFilename, @namespace, openApiDocument);

            if (definition.TypeScriptFileName != null)
            {
                var typescriptFilename = Path.Combine(typeScriptDirectory, definition.TypeScriptFileName);
                GenerateTypescriptClient(typescriptFilename, openApiDocument);
            }
        }
    }

    private static void GenerateDotNetClient(string targetFilename, string @namespace, OpenApiDocument openApiDocument)
    {
        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "{controller}Client",
            CSharpGeneratorSettings =
            {
                Namespace = @namespace,
                DateType = "NodaTime.LocalDate",
                DateTimeType = "NodaTime.LocalDateTime",
                TimeType = "NodaTime.LocalTime",
                TimeSpanType = "NodaTime.LocalTime",
                ArrayType = "System.Collections.Generic.IList",
                ArrayInstanceType = "System.Collections.Generic.List",
                RequiredPropertiesMustBeDefined =
                    false, // NOTE: Do not use this for production client builds. This only helps to generate invalid requests during testing.
            },
            DisposeHttpClient = false,
            ExceptionClass = "SwaggerException",
            UseHttpClientCreationMethod = false,
            HttpClientType = "System.Net.Http.HttpClient",
            UseHttpRequestMessageCreationMethod = false,
            UseBaseUrl = false,
            GenerateOptionalParameters = false,
            WrapResponses = false,
            ResponseClass = "SwaggerResponse",
            GenerateUpdateJsonSerializerSettingsMethod = false,
            ClientBaseClass = "BroFixe.Web.Tests.Integration.Infrastructure.Serialization.BroFixeClientBase"
        };

        var generator = new CSharpClientGenerator(openApiDocument, settings);
        var content = generator.GenerateFile();
        File.WriteAllText(targetFilename, content, Encoding.UTF8);
    }

    private static void GenerateTypescriptClient(string targetFilename, OpenApiDocument openApiDocument)
    {
        var settings = new TypeScriptClientGeneratorSettings
        {
            ClassName = "{controller}Client",
            Template = TypeScriptTemplate.Angular,
            InjectionTokenType = InjectionTokenType.InjectionToken,
            RxJsVersion = 7.5m,
            TypeScriptGeneratorSettings =
            {
                TypeScriptVersion = 4.8m,
                TypeStyle = TypeScriptTypeStyle.Interface, 
                DateTimeType = TypeScriptDateTimeType.String,
                MarkOptionalProperties = false
            },
        };

        var generator = new TypeScriptClientGenerator(openApiDocument, settings);
        var content = generator.GenerateFile();
        File.WriteAllText(targetFilename, content, Encoding.UTF8);
    }
}