using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using MsftGps.MarketplaceAnalytics.Services;

[assembly: FunctionsStartup(typeof(MsftGps.MarketplaceAnalytics.Startup))]

namespace MsftGps.MarketplaceAnalytics
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IConfidentialClientApplication>((s) =>
            {
                return ConfidentialClientApplicationBuilder.Create(Environment.GetEnvironmentVariable("ClientId")).WithClientSecret(Environment.GetEnvironmentVariable("ClientSecret")).Build();
            });
            builder.Services.AddSingleton<IAnalyticsService,AnalyticsService>();
        }
    }
}