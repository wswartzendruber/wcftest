using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCfDemoServer;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app.UseServiceModel(builder =>
{
    builder
        .AddService<EchoService>((serviceOptions) => { })
        .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();

serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();
