using BroFixe.Web.Infrastructure.Serialization;
using Newtonsoft.Json;

namespace BroFixe.Web.Tests.Integration.Infrastructure.Serialization;

public abstract class BroFixeClientBase
{
    protected static void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
    {
        SerializationSettings.Configure(settings);
    }
}