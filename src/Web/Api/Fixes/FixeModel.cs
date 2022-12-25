using BroFixe.Web.Api.Bros;

namespace BroFixe.Web.Api.Fixes;

public record FixeModel(Guid Id, string Title, string Location, DateTime Start, BroModel Organizer,
    string? BackgroundUrl)
{
}