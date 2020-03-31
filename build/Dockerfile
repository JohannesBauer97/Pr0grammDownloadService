FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
WORKDIR /app
COPY ./publish .
EXPOSE 1040
ENV ASPNETCORE_URLS http://*:1040
ENTRYPOINT ["dotnet", "Pr0gramm.Download.Service.dll"]