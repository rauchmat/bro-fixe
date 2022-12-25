using BroFixe.Domain.Model;

namespace BroFixe.Web.Api.Bros;

public static class BroMapper
{
    public static BroModel ToModel(Bro bro) => new BroModel(bro.Id, bro.Nickname, bro.Email, bro.AvatarUrl);
}