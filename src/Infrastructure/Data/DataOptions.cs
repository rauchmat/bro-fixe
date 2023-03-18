namespace BroFixe.Infrastructure.Data;

public class DataOptions
{
    public const string SectionName = "Data";

    public string ConnectionString { get; set; } = default!;
}