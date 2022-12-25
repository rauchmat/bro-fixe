using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroFixe.Domain.Model;

public class Fixe : EntityBase
{
    private Bro? _organizer;

    [Required]
    public string Title { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    public DateTime Start { get; set; }

    public Guid OrganizerId { get; set; }

    public Bro Organizer
    {
        get => _organizer ?? throw new InvalidOperationException("Uninitialized property: " + nameof(Organizer));
        set => _organizer = value;
    }

    public string? BackgroundUrl { get; set; }

    public Fixe(string title, string location, DateTime start, Bro organizer, string? backgroundUrl = null)
        : this(title, location, start, backgroundUrl)
    {
        Organizer = organizer;
        OrganizerId = organizer.Id;
    }

    private Fixe(string title, string location, DateTime start, string? backgroundUrl = null)
    {
        Title = title;
        Location = location;
        Start = start;
        BackgroundUrl = backgroundUrl;
    }
}