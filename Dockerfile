FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
EXPOSE 80
WORKDIR /app
COPY ./app/publish/ .
ENTRYPOINT [ "dotnet", "CoreWCFDemoServer.dll" ]
