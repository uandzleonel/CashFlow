using System.Globalization;

namespace CashFlow.API.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        CultureInfo cultureInfo;

        if (!string.IsNullOrWhiteSpace(requestedCulture)
            && supportedLanguages.Exists(lang => lang.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }
        else
        {
            cultureInfo = new CultureInfo("pt-BR");
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
