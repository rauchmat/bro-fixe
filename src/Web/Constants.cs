namespace BroFixe.Web;

public abstract class Constants
{
    public static readonly string Namespace = typeof(Constants).Namespace!;

    public static readonly string AppName =
        Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
}