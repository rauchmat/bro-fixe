using BroFixe.Web.Api.Bros;

namespace BroFixe.Web.Api.Events;

public record EventModel(Guid Id, string Title, string Location, string Start, BroModel Organizer,
    string? BackgroundUrl)
{
}