using Project.SQS.Worker;
using Project.SQS.Worker.Model;

IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureWebHostDefaults(webHostBuilder =>
     {
         webHostBuilder.UseKestrel(kestrelServerOptions =>
         {
             kestrelServerOptions.ListenLocalhost(5000); // this will be a config value
         }).UseStartup<Startup>();
     })
    .ConfigureServices((context, services) =>
    {
        services.Configure<SqsOptions>(context.Configuration.GetSection("SqsOptions"));
        services.AddSingleton<ISqsClientFactory, SqsClientFactory>();
        services.AddSingleton<ISqsService, SqsService>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
