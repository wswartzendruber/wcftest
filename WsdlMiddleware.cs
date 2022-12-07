namespace CoreWCfDemoServer
{
    internal static class WsdlMiddleware
    {
        internal static void Handle(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Condition is fulfilled");
            });
        }
    }
}
