using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model;

public class Bro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nickname { get; set; }

    public string Email { get; set; }

    public string AvatarUrl { get; set; }
}