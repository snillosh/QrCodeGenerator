using QrCodeGenerator.Domain.Results;

namespace QrCodeGenerator.Application.Parsing;

public static class WebsiteParser
{
    public static WebsiteResult ParseWebsite(
        string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return new WebsiteResult(null, "Please enter a website.");
        }

        if (!Uri.TryCreate(input, UriKind.Absolute, out Uri? uri))
        {
            return new WebsiteResult(null, "That is not a valid URL. Please try again.");
        }

        if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
        {
            return new WebsiteResult(null, "That is not a valid URL. Please try again.");
        }

        return new WebsiteResult(input, null);
    }
}
