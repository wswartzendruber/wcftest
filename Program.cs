using Microsoft.AspNetCore.Http.Extensions;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCfDemoServer;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

builder.Services
    .AddServiceModelServices()
    .AddServiceModelMetadata()
    .AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app
    .MapWhen(context => context.Request.GetEncodedPathAndQuery() == "/EchoService?wsdl", WsdlMiddleware.Handle)
    .UseServiceModel(builder =>
    {
        builder
            .AddService<EchoService>((serviceOptions) => { })
            .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService");
    });

app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>().HttpGetEnabled = true;

app.Run();
