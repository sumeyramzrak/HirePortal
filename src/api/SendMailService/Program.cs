using Hangfire;
using Hangfire.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHangfire(opt =>
        opt.UseSqlServerStorage("Server = localhost; Database = Teleperformance; User Id = sa; Password = 1q2w3e4R!"));
    })
    .Build();

await host.RunAsync();