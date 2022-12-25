using System.ComponentModel.DataAnnotations;

namespace BroFixe.Domain.Model;

public class Bro : EntityBase
{
    [Required]
    [StringLength(50)]
    public string Nickname { get; set; }

    [Required]
    public string Email { get; set; }

    public string? AvatarUrl { get; set; }

    public Bro(string nickname, string email, string? avatarUrl = null)
    {
        Nickname = nickname;
        Email = email;
        AvatarUrl = avatarUrl;
    }
}