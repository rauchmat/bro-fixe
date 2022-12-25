using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BroFixe.Web.Infrastructure.Serialization;

public static class SerializationSettings
{
    public static JsonSerializerSettings Create()
    {
        var jsonSerializerSettings = new JsonSerializerSettings();
        Configure(jsonSerializerSettings);
        return jsonSerializerSettings;
    }

    public static JsonSerializerSettings Configure(JsonSerializerSettings settings)
    {
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        settings.NullValueHandling = NullValueHandling.Ignore;
        settings.DateParseHandling = DateParseHandling.None;
        settings.Converters.Add(new StringEnumConverter(camelCaseText: true));
        // settings.Converters.Add (new NodaPatternConverter<LocalTime> (TimeUtility.DefaultTimePattern));
        // settings.Converters.Add (new NodaPatternConverter<LocalDate> (TimeUtility.DefaultDatePattern));
        // settings.Converters.Add (new InstantJsonConverter());
        // settings.Converters.Add (new NodaPatternConverter<LocalDateTime> (TimeUtility.DefaultDateTimePattern));

        return settings;
    }
}