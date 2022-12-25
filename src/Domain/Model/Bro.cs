using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroFixe.Domain.Model;

public class Bro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nickname { get; set; } = default!;

    [Required]
    public string Email { get; set; } = default!;

    public string? AvatarUrl { get; set; }
}