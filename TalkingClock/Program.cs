using TimeToTextLibrary.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TalkingClock;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args).
        ConfigureServices((_, services) =>
        {
            services.AddSingleton<ITimeToTextConverter, TimeToTextConverter>();
            services.AddSingleton<App>();
        });
}

