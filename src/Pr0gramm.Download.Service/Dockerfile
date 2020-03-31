FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 1040
ENV ASPNETCORE_URLS http://*:1040
ENTRYPOINT ["dotnet", "Pr0gramm.Download.Service.dll"]