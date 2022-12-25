using BroFixe.Domain.Model;
using BroFixe.Web.Api.Bros;

namespace BroFixe.Web.Api.Fixes;

public static class FixeMapper
{
    public static FixeModel ToModel(Fixe fixe) => new FixeModel(fixe.Id, fixe.Title, fixe.Location,
        fixe.Start, BroMapper.ToModel(fixe.Organizer), fixe.BackgroundUrl);
}