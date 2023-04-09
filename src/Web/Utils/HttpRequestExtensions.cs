namespace BroFixe.Web.Utils;

public static class HttpRequestExtensions
{
  public static bool IsMethod(this HttpRequest httpRequest, string method)
  {
    return string.Equals(httpRequest.Method.ToLowerInvariant(), method.ToLowerInvariant(), StringComparison.InvariantCultureIgnoreCase);
  }

  public static bool IsPost(this HttpRequest httpRequest)
  {
    return httpRequest.IsMethod(HttpMethods.Post);
  }

  public static bool IsPut(this HttpRequest httpRequest)
  {
    return httpRequest.IsMethod(HttpMethods.Put);
  }

  public static bool IsPatch(this HttpRequest httpRequest)
  {
    return httpRequest.IsMethod(HttpMethods.Patch);
  }

  public static bool IsDelete(this HttpRequest httpRequest)
  {
    return httpRequest.IsMethod(HttpMethods.Delete);
  }

  public static bool IsWriteMethod(this HttpRequest httpRequest)
  {
    return httpRequest.IsPost() || httpRequest.IsPut() || httpRequest.IsPatch() || httpRequest.IsDelete();
  }
}